using System.IO.Compression;
using Api_Tienda.Data;
using Api_Tienda.Dtos;
using Api_Tienda.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Tienda.Repository
{
    public sealed class MangaService : IMangaService
    {
        private readonly Context context;
        public MangaService(Context _context)
        {
            this.context = _context;
        }
        public void AddManga(postMangaDto obj)
        {
            var model = new manga(obj.titulo, obj.precio, obj.idAutor, obj.idEditorial, new List<mangaDetails>());
            context.Mangas.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {

            var model = context.Mangas.First(x => x.idManga == id);
            context.Mangas.Remove(model);
            context.SaveChanges();
        }

        public List<getMangaDto> GetAll()
        {
            var list = GetData();
            var mandar = new List<getMangaDto>();

            foreach (var item in list)
            {
                var model = new getMangaDto(item.idManga, item.titulo, item.precio, item.autor.nombre, item.editorial.nombre, item.mangasDetails);
                mandar.Add(model);
            }
            return mandar;
        }

        public getMangaDto GetById(int id)
        {
            var get = GetData().FirstOrDefault(x => x.idManga == id);
            var model = new getMangaDto(get.idManga, get.titulo, get.precio, get.autor.nombre, get.editorial.nombre, get.mangasDetails);
            return model;
        }

        public void Update(postMangaDto obj)
        {
            var model = new manga(obj.idPostMangaDto,obj.titulo, obj.precio, obj.idAutor, obj.idEditorial, new List<mangaDetails>());
            context.Mangas.Update(model);
            context.SaveChanges();
        }

        private List<manga> GetData() => context.Mangas.Include(x => x.autor).Include(x => x.editorial).Include(x => x.mangasDetails).ToList();
    }
}