using Api_Tienda.Models;

namespace Api_Tienda.Dtos
{
    public sealed class getMangaDto
    {
        public getMangaDto() { }
        public getMangaDto(int id, string title, int price, string autor, string edit, List<mangaDetails> list)
        {
            this.Idmanga = id;
            this.titulo = title;
            this.price = price;
            this.mangaka = autor;
            this.editorial = edit;
            this.mangas = AddDetails(list);
        }
        public int Idmanga { get; set; }
        public string titulo { get; set; }
        public int price { get; set; }
        public string mangaka { get; set; }
        public string editorial { get; set; }
        public List<detailDto> mangas { get; set; } = new List<detailDto>();

        private List<detailDto> AddDetails(List<mangaDetails> item)
        {
            var list = new List<detailDto>();
            for (var i = 0; i < item.Count(); i++)
            {
                var model = new detailDto(item[i].idMDetail, item[i].tomoNro, item[i].reseña, item[i].url);
                list.Add(model);
            }
            return list;
        }
    }

}