
using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;



namespace Api_Tienda.Models
{
    public class manga
    {

        public manga() { }


        public manga(string titulo, int precio, int autor,
         int editorial, List<mangaDetails> mangas)
        {
            this.titulo = titulo;
            this.precio = precio;
            this.idAutor = autor;
            this.idEditorial = editorial;
            this.QuantityMangas(mangas);
        }
        public manga(int id, string titulo, int precio, int autor,
         int editorial, List<mangaDetails> mangas) : this(titulo, precio, autor,
          editorial, mangas)
        {
            this.idManga = id;
        }
        [Key]
        public int idManga { get; set; }
        public string titulo { get; set; }
        public int precio { get; set; }
        public int cantidadTomos { get; set; }

        public int idAutor { get; set; }
        public virtual autor autor { get; set; } = default!;
        public int idEditorial { get; set; }
        public virtual editorial editorial { get; set; } = default!;
        public virtual List<mangaDetails> mangasDetails { get; set; } = new List<mangaDetails>();

        private void QuantityMangas(List<mangaDetails> mangas)
        {
            if (mangas.IsNullOrEmpty())
            {
                this.cantidadTomos = 1;


            }
            else
            {
                this.cantidadTomos = mangas.Count() + 1;
            }

        }
    }

}