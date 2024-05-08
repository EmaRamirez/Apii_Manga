using Api_Tienda.Data;
using Api_Tienda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Tienda.Repository
{

    public class MDetailsService : IMDetailsService
    {
        private readonly Context context;
        public MDetailsService(Context _context)
        {
            this.context = _context;
        }
        public List<mangaDetails> GetAll() => context.MangaDetails.ToList();
        public mangaDetails GetById(int id) => 
        context.MangaDetails.FirstOrDefault(x => x.idMDetail == id);
        public void AddDetail(mangaDetails obj)
        {
            
            var con = new manga();
            con = context.Mangas.Include(x => x.editorial).ToList().First(x => x.idManga == 1);
            obj.mangaInfo = con;
            context.MangaDetails.Add(obj);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context.MangaDetails.Remove(GetById(id));
        }

        public void Update(mangaDetails obj)
        {
            context.MangaDetails.Update(obj);
        }
    }
}


