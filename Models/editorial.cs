using System.ComponentModel.DataAnnotations;

namespace Api_Tienda.Models
{
    public class editorial
    {
        public editorial()
        {

        }
        public editorial(int id)
        {
            this.idEditorial = id;
        }
        public editorial(int id, string nombre) : this(id)
        {
            this.nombre = nombre;
        }
        public editorial(string nombre)
        {
            this.nombre = nombre;
        }
        [Key]
        public int idEditorial { get; set; }
        public string nombre { get; set; }

        public virtual List<manga> mangas { get; set; } = new List<manga>();
    }
}