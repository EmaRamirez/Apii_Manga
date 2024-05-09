using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Api_Tienda.Models;
using Api_Tienda.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Api_Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class autorController : Controller
    {
        private readonly IAutorService autorService;
        public autorController(IAutorService _autorService)
        {
            this.autorService = _autorService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var model = autorService.GetAll();
            if (model.IsNullOrEmpty())
            {
                return NotFound("La base de datos es nula");
            }
            return Ok(model);
        }

        [HttpGet("{id}", Name = "ObtenerAutor")]
        public IActionResult GetAuto(int id)
        {
            if (id.GetType() != typeof(int))
            {
                return BadRequest();
            }
            var model = autorService.GetById(id);
            return Ok(model);
        }



        [HttpPost]
        public IActionResult AddAutor([FromBody] string obj)
        {

            if (obj.GetType() != typeof(string))
            {
                return BadRequest("El valor recibido no es valido");
            }
            else if (obj.Length < 3)
            {
                return BadRequest("El nombre tiene que tener mas caracteres");
            }
            var model = new autor(obj);
            autorService.AddAutor(model);
            return new CreatedAtRouteResult("ObtenerAutor", new { id = model.idAutor }, model);
        }
        [HttpDelete]
        public IActionResult DeleteAutor(int id)
        {
            if (id.GetType() != typeof(int))
            {
                return BadRequest();
            }
            autorService.Delete(id);
            return Ok();
        }

        // [HttpPut]
        [HttpPatch]
        public IActionResult UpdateAutor([FromBody] autor obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("El objeto enviado es invalido");
            }
            autorService.Update(obj);
            return NoContent();
        }

    }
}