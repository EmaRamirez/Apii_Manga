using Api_Tienda.Models;
using Api_Tienda.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Api_Tienda.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class mangaController : Controller
    {

        private readonly IMangaService mangaService;

        public mangaController(IMangaService _mangaService)
        {
            this.mangaService = _mangaService;
        }

        [HttpGet]
        public IActionResult GetAllManga()
        {
            var model = mangaService.GetAll();
            return Ok(model);
        }
        [HttpGet("{id}", Name = "ObtenerManga")]
        public IActionResult GetManga(int id)
        {
            var Model = mangaService.GetById(id);
            return Ok(Model);
        }

        [HttpPost]
        public IActionResult AddManga([FromBody] datos obj)
        {
            if (!ModelState.IsValid)
            {
                return NotFound("no funciona");
            }
            var model = new manga(obj.titulo, obj.precio, obj.idAutor,
             obj.idEditorial, obj.mangasDetails);



            mangaService.AddManga(model);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateManga([FromBody] manga obj)
        {
            mangaService.Update(obj);
            return Accepted();

        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            mangaService.Delete(id);
            return Ok();
        }
    }

    public class datos()
    {
        public int idManga { get; set; }
        public string titulo { get; set; }
        public int precio { get; set; }
        public int cantidadTomos { get; set; }
        public int idAutor { get; set; }

        public int idEditorial { get; set; }
        public virtual List<mangaDetails> mangasDetails { get; set; } = new List<mangaDetails>();
    }


}