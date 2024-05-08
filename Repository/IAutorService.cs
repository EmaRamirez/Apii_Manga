using Api_Tienda.Models;

namespace Api_Tienda.Repository
{
    public interface IAutorService
    {
        List<autor> GetAll();
        autor GetById(int id);
        void Delete(int id);
        void Update(autor obj);
        void AddAutor(autor obj);
    }
}