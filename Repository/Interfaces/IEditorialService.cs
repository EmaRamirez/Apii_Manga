using Api_Tienda.Dtos;

namespace Api_Tienda.Repository
{
    public interface IEditorialService
    {
        List<editorialDto> GetAll();
        editorialDto GetById(int id);
        void AddEditorial(editorialDto obj);
        void Update(editorialDto obj);
        void Delete(int id);

    }


}