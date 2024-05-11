namespace Api_Tienda.Dtos
{
    public class autorDto
    {
        public autorDto()
        {

        }
        public autorDto(string name)
        {
            this.name = name;
        }
        public autorDto(int idDto, string name) : this(name)
        {
            this.idAutorDto = idDto;
        }
        public int idAutorDto { get; set; }
        public string name { get; set; }
    }
}