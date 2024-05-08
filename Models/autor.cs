using System.ComponentModel.DataAnnotations;

namespace Api_Tienda.Models
{
    public class autor
    {
        public autor() { }
        public autor(int id)
        {
            this.idAutor = id;
        }
        public autor(int id, string nombre) : this(id)
        {
            this.nombre = nombre;
        }
        public autor(string nombre)
        {
            this.nombre = nombre;
        }
        [Key]
        public int idAutor { get; set; }
        public string nombre { get; set; }
        public virtual List<manga> mangas { get; set; } = new List<manga>();
    }
}