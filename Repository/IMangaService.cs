using Api_Tienda.Dtos;
using Api_Tienda.Models;

namespace Api_Tienda.Repository
{
    public interface IMangaService
    {
        List<getMangaDto> GetAll();
         getMangaDto GetById(int id);
        void Update(manga obj);
        void Delete(int id);

        void AddManga(manga obj);
    }
}