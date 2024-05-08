using Api_Tienda.Models;

namespace Api_Tienda.Repository
{
    public interface IMangaService
    {
        List<manga> GetAll();
         manga GetById(int id);
        void Update(manga obj);
        void Delete(int id);

        void AddManga(manga obj);
    }
}