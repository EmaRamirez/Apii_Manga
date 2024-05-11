using Api_Tienda.Dtos;
using Api_Tienda.Models;
using Api_Tienda.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.Web.CodeGeneration;

namespace Api_Tienda.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class mangaDetailController : Controller
    {
        private readonly IMDetailsService mangaDetailService;
        public mangaDetailController(IMDetailsService _mangaDetailService)
        {
            this.mangaDetailService = _mangaDetailService;
        }
        [HttpGet]
        // http://localhost:5265/api/mangaDetail
        public IActionResult GetAllMangas()
        {
            return Ok(mangaDetailService.GetAll());
        }
        [HttpGet("{id}", Name = "ObtenerMangaDetails")]
        // http://localhost:5265/api/mangaDetail/id

        public IActionResult GetManga(int id)
        {
            return Ok(mangaDetailService.GetById(id));
        }
        [HttpPost]
        // http://localhost:5265/api/mangaDetail
        public IActionResult AddManga([FromForm] mangaDetails_Post obj)
        {
            //VER QUE UNA VEZ ESTE MANDO LA PETICION SEA LA RUTA CORRESPONDIENTE
            string ruta = "C:/Users/emanu/OneDrive/Escritorio/Api_Tienda/Api_Tienda/Images";
            string ubicacion = Path.Combine(ruta, obj.imagen.FileName);

            try
            {
                using (FileStream newImage = System.IO.File.Create(ubicacion))
                {
                    obj.imagen.CopyTo(newImage);
                    newImage.Flush();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var url = ubicacion;


            var model = new mangaDetails(obj.tomoNro, obj.reseña, url, obj.idManga);


            mangaDetailService.AddDetail(model);
            return new CreatedAtRouteResult("ObtenerMangaDetails", new { id = model.idMDetail }, obj);

        }
        [HttpDelete]
        // http://localhost:5265/api/mangaDetail?id=3
        public IActionResult DeleteDetailManga(int id)
        {
            mangaDetailService.Delete(id);
            return Ok("Se realizo con exito");
        }

        [HttpPatch]
        // http://localhost:5265/api/mangaDetail
        public IActionResult UpdateMangaDetail([FromForm] mangaDetails_Post obj)
        {

            string ruta = "C:/Users/emanu/OneDrive/Escritorio/Api_Tienda/Api_Tienda/Images";
            string ubicacion = Path.Combine(ruta, obj.imagen.FileName);
            try
            {
                using (FileStream newfile = System.IO.File.Create(ubicacion))
                {
                    obj.imagen.CopyTo(newfile);
                    newfile.Flush();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            var model = new mangaDetails(obj.idMangaDetail, obj.tomoNro, obj.reseña, ubicacion, obj.idManga);
            mangaDetailService.Update(model);
            return Ok();
        }


    }


}