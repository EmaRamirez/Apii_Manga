using Api_Tienda.Data;
using Api_Tienda.Dtos;
using Api_Tienda.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Tienda.Repository
{
    public class AutorService : IAutorService
    {
        private readonly Context context;

        public AutorService(Context _context)
        {
            this.context = _context;
        }
        public void AddAutor(autorDto obj)
        {
            var model = new autor(obj.name);
            context.Autores.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            // var model = GetById(id);
            var delete = GetData().First(x => x.idAutor == id);
            context.Autores.Remove(delete);
            context.SaveChanges();
        }

        public List<autorDto> GetAll()
        {
            var data = GetData();
            var model = new List<autorDto>();
            foreach (var item in data)
            {
                var add = new autorDto(item.idAutor, item.nombre);
                model.Add(add);
            }
            return model;
        }


        public autorDto GetById(int id)
        {
            var data = GetData().First(x => x.idAutor == id);
            var model = new autorDto(data.idAutor, data.nombre);
            return model;
        }


        public void Update(autorDto obj)
        {
            var model = new autor(obj.idAutorDto, obj.name);
            context.Autores.Update(model);
            context.SaveChanges();
        }

        private List<autor> GetData() => context.Autores.ToList();
    }
}