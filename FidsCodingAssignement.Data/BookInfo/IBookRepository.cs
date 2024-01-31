using TestProject.Data.Entities;
using TestProject.DTO.Book;

namespace TestProject.Data.BookInfo
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookInfoDTO>>? GetBooks();
        IEnumerable<BookInfoDTO>? GetAllBooks();
        BookInfoDTO? GetBookById(int id);
        IEnumerable<BookInfoDTO>? GetBooksByTitle(string filter);
        IEnumerable<BookInfoDTO>? GetBooksByDescription(string filter);
    }
}