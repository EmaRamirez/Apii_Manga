using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Api_Tienda.Models;
using Api_Tienda.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            return Ok(model);
        }

        [HttpGet("/Autor/{id}", Name = "ObtenerAutor")]
        public IActionResult GetAuto(int id)
        {
            var model = autorService.GetById(id);
            return Ok(model);
        }
        [HttpPost]
        public IActionResult AddAutor([FromBody] string obj)
        {
            var model = new autor(obj);
            autorService.AddAutor(model);
            return new CreatedAtRouteResult("ObtenerAutor", new { id = model.idAutor }, model);
        }
        [HttpDelete]
        public IActionResult DeleteAutor(int id)
        {
            autorService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateAutor([FromBody] autor obj)
        {
            autorService.Update(obj);
            return NoContent();
        }

    }
}