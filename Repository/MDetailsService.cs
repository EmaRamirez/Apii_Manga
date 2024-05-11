
using Api_Tienda.Data;
using Api_Tienda.Dtos;
using Api_Tienda.Models;

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
        public List<getMangaDetailDto> GetAll()
        {
            var data = GetData();
            var model = new List<getMangaDetailDto>();
            foreach (var item in data)
            {
                var add = new getMangaDetailDto(item.idMDetail, item.tomoNro, item.reseña, item.url);
                model.Add(add);
            }
            return model;
        }

        public getMangaDetailDto GetById(int id)
        {
            var data = GetData().First(x => x.idMDetail == id);
            var model = new getMangaDetailDto(data.idMDetail, data.tomoNro, data.reseña, data.url);
            return model;
        }
        public void AddDetail(mangaDetails_Post obj)
        {
            var model = new mangaDetails(obj.tomoNro, obj.reseña, obj.url, obj.idManga);
            model.mangaInfo = context.Mangas.First(x => x.idAutor == obj.idManga);
            context.MangaDetails.Add(model);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var model = GetData().First(x => x.idMDetail == id);
            context.MangaDetails.Remove(model);
            context.SaveChanges();
        }

        public void Update(mangaDetails_Post obj)
        {
            var model = new mangaDetails(obj.idMangaDetail, obj.tomoNro, obj.reseña, obj.url, obj.idManga);
            model.mangaInfo = context.Mangas.First(x => x.idManga == obj.idManga);
            context.MangaDetails.Update(model);
            context.SaveChanges();
        }

        private List<mangaDetails> GetData() => context.MangaDetails.Include(x => x.mangaInfo).ToList();
    }
}


