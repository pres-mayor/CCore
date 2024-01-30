using TestProject.DTO.Book;

namespace TestProject.Data.BookInfo
{
    public interface IBookRepository
    {
        IEnumerable<BookInfoDTO>? GetBooks();
        BookInfoDTO? GetBookById(int id);
        IEnumerable<BookInfoDTO>? GetBooksByTitle(string filter);
        IEnumerable<BookInfoDTO>? GetBooksByDescription(string filter);
    }
}