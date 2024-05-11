using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Api_Tienda.Dtos;
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
        // http://localhost:5265/api/autor
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
        // http://localhost:5265/api/autor/1

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


        // http://localhost:5265/api/autor
        [HttpPost]
        public IActionResult AddAutor([FromBody] autorDto obj)
        {

            if (obj.name.GetType() != typeof(string))
            {
                return BadRequest("El valor recibido no es valido");
            }
            else if (obj.name.Length < 3)
            {
                return BadRequest("El nombre tiene que tener mas caracteres");
            }

            autorService.AddAutor(obj);
            return new CreatedAtRouteResult("ObtenerAutor", new { id = obj.idAutorDto }, obj);
        }
        [HttpDelete]
        // http://localhost:5265/api/autor?id=5
        public IActionResult DeleteAutor(int id)
        {
            if (id.GetType() != typeof(int))
            {
                return BadRequest();
            }
            autorService.Delete(id);
            return Ok();
        }


        [HttpPatch]
        // http://localhost:5265/api/autor
        public IActionResult UpdateAutor([FromBody] autorDto obj)
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