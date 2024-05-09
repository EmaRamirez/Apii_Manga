namespace Api_Tienda.Dtos
{
    public class getMandaDto
    {
        public int Idmanga { get; set; }
        public string titulo { get; set; }
        public int price { get; set; }
        public string mangaka { get; set; }
        public string editorial { get; set; }
        public List<details> mangas { get; set; } = new List<details>();

    }



    public class details
    {
        public int idMangaDetails { get; set; }
        public int tomoNro { get; set; }
        public string reseña { get; set; }
        public string url { get; set; }

    }
}