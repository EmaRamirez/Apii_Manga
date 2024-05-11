using Api_Tienda.Dtos;


namespace Api_Tienda.Repository
{
    public interface IMDetailsService
    {
        List<getMangaDetailDto> GetAll();
        getMangaDetailDto GetById(int id);
        void AddDetail(mangaDetails_Post obj);
        void Delete(int id);

        void Update(mangaDetails_Post obj);
    }
}