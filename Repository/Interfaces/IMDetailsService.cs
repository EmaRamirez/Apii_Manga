using Api_Tienda.Models;

namespace Api_Tienda.Repository
{
    public interface IMDetailsService
    {
        List<mangaDetails> GetAll();
        mangaDetails GetById(int id);
        void AddDetail(mangaDetails obj);
        void Delete(int id);

        void Update(mangaDetails obj);
    }
}