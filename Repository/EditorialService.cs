using System.Net;
using Api_Tienda.Data;
using Api_Tienda.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Api_Tienda.Repository
{
    public class EditorialService : IEditorialService
    {

        private readonly Context context;

        public EditorialService(Context _context)
        {
            this.context = _context;
        }
        public void AddEditorial(editorial obj)
        {
            // var valu = 
            context.Editoriales.Add(obj);
            context.SaveChanges();
            // return valu.ToString();

        }

        public void Delete(int id)
        {
            var edi = GetById(id);
            context.Editoriales.Remove(edi);
            context.SaveChanges();


        }

        public List<editorial> GetAll() 
        {
            return context.Editoriales.ToList();
        } 


        public editorial GetById(int id) => context.Editoriales.FirstOrDefault(x => x.idEditorial == id);


        public void Update(editorial obj)
        {

            context.Editoriales.Update(obj);
            context.SaveChanges();
        }
    }
}