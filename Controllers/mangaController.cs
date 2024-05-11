using Api_Tienda.Models;
using Api_Tienda.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Api_Tienda.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // SI BORRAMOS UNA MANGA, SE VAN A BORRAR TODOS LOS MANGAS DETAIS QUE ESTEN RELACIONADOS
    public class mangaController : Controller
    {

        private readonly IMangaService mangaService;

        public mangaController(IMangaService _mangaService)
        {
            this.mangaService = _mangaService;
        }

        [HttpGet]
        // http://localhost:5265/manga
        public IActionResult GetAllManga()
        {
            var model = mangaService.GetAll();
            return Ok(model);
        }
        [HttpGet("{id}", Name = "ObtenerManga")]
        // http://localhost:5265/manga/2
        public IActionResult GetManga(int id)
        {
            var Model = mangaService.GetById(id);
            return Ok(Model);
        }

        [HttpPost]
        // http://localhost:5265/manga
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
        [HttpPatch]
        // http://localhost:5265/manga
        public IActionResult UpdateManga([FromBody] datos obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var model = new manga(obj.idManga, obj.titulo, obj.precio, obj.idAutor,
                         obj.idEditorial, obj.mangasDetails);

            mangaService.Update(model);
            return Accepted();

        }
        [HttpDelete]
        // http://localhost:5265/manga?id=5
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