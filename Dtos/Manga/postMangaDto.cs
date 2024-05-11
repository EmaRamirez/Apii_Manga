using Api_Tienda.Models;

namespace Api_Tienda.Dtos
{
    public sealed class postMangaDto
    {
        public int idPostMangaDto { get; set; }
        public string titulo { get; set; }
        public int precio { get; set; }
        public int cantidadTomos { get; set; }
        public int idAutor { get; set; }

        public int idEditorial { get; set; }
        
    }
}