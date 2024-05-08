using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api_Tienda.Controllers;

namespace Api_Tienda.Models
{
    public class mangaDetails
    {
        public mangaDetails() { }
        public mangaDetails(int tomonro, string reseña, string url,
         int mangaid)
        {
            this.tomoNro = tomonro;
            this.reseña = reseña;
            this.url = url;
            this.idManga = idManga;

        }

        [Key]
        public int idMDetail { get; set; }
        public int tomoNro { get; set; }
        public string reseña { get; set; }
        public string url { get; set; }
        public int idManga { get; set; }
        public virtual manga mangaInfo { get; set; } = new manga();
        [NotMapped]
        public IFormFile imagen { get; set; }

    }
}