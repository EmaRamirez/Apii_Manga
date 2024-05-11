
namespace Api_Tienda.Dtos
{
    public sealed class editorialDto
    {
        public editorialDto() { }
        public editorialDto(string nombre)
        {
            this.name = nombre;
        }
        public editorialDto(int id, string nombre) : this(nombre)
        {
            this.idEditorialDto = id;
        }
        public int idEditorialDto { get; set; }

        public string name { get; set; }
    }
}