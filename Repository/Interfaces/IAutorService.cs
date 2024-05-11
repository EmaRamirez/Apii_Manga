using Api_Tienda.Dtos;
using Api_Tienda.Models;

namespace Api_Tienda.Repository
{
    public interface IAutorService
    {
        List<autorDto> GetAll();
        autorDto GetById(int id);
        void Delete(int id);
        void Update(autorDto obj);
        void AddAutor(autorDto obj);
    }
}