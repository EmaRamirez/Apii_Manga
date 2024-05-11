using Api_Tienda.Dtos;
using Api_Tienda.Models;
using Api_Tienda.Repository;
using Microsoft.AspNetCore.Mvc;


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
        public IActionResult AddManga([FromBody] postMangaDto obj)
        {
            if (!ModelState.IsValid)
            {
                return NotFound("no funciona");
            }

            mangaService.AddManga(obj);
            return Ok();
        }
        [HttpPatch]
        // http://localhost:5265/manga
        public IActionResult UpdateManga([FromBody] postMangaDto obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            mangaService.Update(obj);
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

}