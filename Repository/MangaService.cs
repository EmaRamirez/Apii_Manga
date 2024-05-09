using System.IO.Compression;
using Api_Tienda.Data;
using Api_Tienda.Dtos;
using Api_Tienda.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Tienda.Repository
{
    public class MangaService : IMangaService
    {
        private readonly Context context;
        public MangaService(Context _context)
        {
            this.context = _context;
        }
        public void AddManga(manga obj)
        {
            context.Mangas.Add(obj);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Mangas.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<getMandaDto> GetAll()
        {
            var list = GetData();
            var mandar = new List<getMandaDto>();
            var model = new getMandaDto();

            foreach (var item in list)
            {
                model.Idmanga = item.idManga;
                model.titulo = item.titulo;
                model.price = item.precio;
                model.mangaka = item.autor.nombre;
                model.editorial = item.editorial.nombre;

                for (var i = 0; i < item.mangasDetails.Count(); i++)
                {
                    var add = new details();
                    add.idMangaDetails = item.mangasDetails[i].idMDetail;
                    add.tomoNro = item.mangasDetails[i].tomoNro;
                    add.reseña = item.mangasDetails[i].reseña;
                    add.url = item.mangasDetails[i].url;
                    model.mangas.Add(add);
                }
                mandar.Add(model);
            }
            return mandar;
        }



        public manga GetById(int id) => context.Mangas.Include(x => x.autor).Include(x => x.editorial).FirstOrDefault(x => x.idManga == id);


        public void Update(manga obj)
        {
            context.Mangas.Update(obj);
            context.SaveChanges();
        }


        private List<manga> GetData() => context.Mangas.Include(x => x.autor).Include(x => x.editorial).Include(x => x.mangasDetails).ToList();
    }
}