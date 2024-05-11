using Api_Tienda.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Tienda.Repository
{
    public interface IEditorialService
    {
        List<editorial> GetAll();
        editorial GetById(int id);
        void AddEditorial(editorial obj);
        void Update(editorial obj);
        void Delete(int id);

    }


}