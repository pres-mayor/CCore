using AutoMapper;
using TestProject.DTO.Book;

namespace TestProject
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Data.Entities.Book, BookInfoDTO>();
        }

    }
}
