using Api_Tienda.Data;
using Api_Tienda.Dtos;
using Api_Tienda.Models;


namespace Api_Tienda.Repository
{
    public class EditorialService : IEditorialService
    {

        private readonly Context context;

        public EditorialService(Context _context)
        {
            this.context = _context;
        }
        public void AddEditorial(editorialDto obj)
        {
            var model = new editorial(obj.name);

            context.Editoriales.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var edi = GetData().First(x => x.idEditorial == id);
            context.Editoriales.Remove(edi);
            context.SaveChanges();


        }

        public List<editorialDto> GetAll()
        {
            var data = GetData();
            var model = new List<editorialDto>();
            foreach (var item in data)
            {
                var add = new editorialDto(item.idEditorial, item.nombre);
                model.Add(add);
            }
            return model;
        }


        public editorialDto GetById(int id)
        {
            var data = GetData().First(x => x.idEditorial == id);
            var model = new editorialDto(data.idEditorial, data.nombre);
            return model;
        }


        public void Update(editorialDto obj)
        {
            var model = new editorial(obj.idEditorialDto, obj.name);

            context.Editoriales.Update(model);
            context.SaveChanges();
        }

        private List<editorial> GetData() => context.Editoriales.ToList();

    }
}