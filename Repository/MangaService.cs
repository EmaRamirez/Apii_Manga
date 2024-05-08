using System.IO.Compression;
using Api_Tienda.Data;
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

        public List<manga> GetAll() => context.Mangas.Include(x => x.autor).Include(x => x.editorial).Include(x => x.mangasDetails).ToList();



        public manga GetById(int id) => context.Mangas.Include(x => x.autor).Include(x => x.editorial).FirstOrDefault(x => x.idManga == id);


        public void Update(manga obj)
        {
            context.Mangas.Update(obj);
            context.SaveChanges();
        }
    }
}