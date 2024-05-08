using Api_Tienda.Data;
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
        public void AddAutor(autor obj)
        {
            context.Add(obj);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Autores.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<autor> GetAll() => context.Autores.ToList();


        public autor GetById(int id) => context.Autores.FirstOrDefault(x => x.idAutor == id);


        public void Update(autor obj)
        {
            context.Autores.Update(obj);
            context.SaveChanges();
        }
    }
}