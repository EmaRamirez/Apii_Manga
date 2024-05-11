namespace Api_Tienda.Dtos
{
    public class mangaDetails_Post
    {
        public int idMangaDetail { get; set; }
        public int tomoNro { get; set; }
        public string reseña { get; set; }
        public int idManga { get; set; }
        public IFormFile imagen { get; set; }
    }
}