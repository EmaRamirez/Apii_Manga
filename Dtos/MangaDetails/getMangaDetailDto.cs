namespace Api_Tienda.Dtos
{
    public class getMangaDetailDto
    {
        public getMangaDetailDto() { }
        public getMangaDetailDto(int id, int tomo, string reseña, string url)
        {
            this.idGetMangaDetailDto = id;
            this.nroTomo = tomo;
            this.reseña = reseña;
            this.url = url;
            // this.mangaka = autor;
        }

        public int idGetMangaDetailDto { get; set; }
        public int nroTomo { get; set; }
        public string reseña { get; set; }
        public string url { get; set; }
        // public string mangaka { get; set; }
    }
}