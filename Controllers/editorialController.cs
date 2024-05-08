

using System.Text.Json.Serialization;
using Api_Tienda.Models;
using Api_Tienda.Repository;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Mono.TextTemplating;

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
        public IActionResult GetAll()
        {
            var value = servEditorial.GetAll();
            if (value is null)
            {
                return NotFound();
            }

            return Ok(value);
        }
        [HttpGet("/editorial/{id}", Name = "ObtenerEditorial")]

        public IActionResult GetEditorial(int id)
        {
            var model = servEditorial.GetById(id);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult AddEditorial([FromBody] editorial obj)
        {
            var model = new editorial(obj.nombre);
            servEditorial.AddEditorial(model);

            return new CreatedAtRouteResult("ObtenerEditorial", new { id = model.idEditorial }, model);
        }

        [HttpDelete("/editorial/{id}")]
        public IActionResult DeleteEditorial(int id)
        {
            servEditorial.Delete(id);
            return Accepted();
        }
        [HttpPut]
        public IActionResult UpdateEditorial([FromBody] editorial obj)
        {
            var model = new editorial(obj.idEditorial, obj.nombre);
            servEditorial.Update(model);
            return Ok();
        }

    }
}