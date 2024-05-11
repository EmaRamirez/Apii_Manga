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
        public int Idmanga { get; }
        public string titulo { get; }
        public int price { get; }
        public string mangaka { get; }
        public string editorial { get; }
        public List<detailDto> mangas { get; } = new List<detailDto>();

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