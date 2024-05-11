namespace Api_Tienda.Dtos
{
    public sealed class detailDto
    {
        public detailDto() { }
        public detailDto(int id, int tomo, string reseña, string url)
        {
            this.idMangaDetails = id;
            this.tomoNro = tomo;
            this.reseña = reseña;
            this.url = url;
        }
        public int idMangaDetails { get; set; }
        public int tomoNro { get; set; }
        public string reseña { get; set; }
        public string url { get; set; }

    }
}