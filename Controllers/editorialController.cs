using Api_Tienda.Dtos;
using Api_Tienda.Repository;
using Microsoft.AspNetCore.Mvc;


namespace Api_Tienda.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class editorialController : Controller
    {
        private readonly IEditorialService servEditorial;
        public editorialController(IEditorialService _servEditorial)
        {
            this.servEditorial = _servEditorial;
        }

        [HttpGet]
        // http://localhost:5265/api/editorial
        public IActionResult GetAll()
        {
            var value = servEditorial.GetAll();
            if (value is null)
            {
                return NotFound();
            }

            return Ok(value);
        }
        [HttpGet("{id}", Name = "ObtenerEditorial")]
        // http://localhost:5265/api/editorial/1

        public IActionResult GetEditorial(int id)
        {
            var model = servEditorial.GetById(id);
            return Ok(model);
        }

        [HttpPost]
        // http://localhost:5265/api/editorial
        public IActionResult AddEditorial([FromBody] editorialDto obj)
        {

            servEditorial.AddEditorial(obj);

            return new CreatedAtRouteResult("ObtenerEditorial", new { id = obj.idEditorialDto }, obj);
        }

        [HttpDelete("/editorial/{id}")]
        // http://localhost:5265/editorial/2
        public IActionResult DeleteEditorial(int id)
        {
            servEditorial.Delete(id);
            return Accepted();
        }
        [HttpPatch]
        // http://localhost:5265/api/editorial
        public IActionResult UpdateEditorial([FromBody] editorialDto obj)
        {
            servEditorial.Update(obj);
            return Ok();
        }

    }
}