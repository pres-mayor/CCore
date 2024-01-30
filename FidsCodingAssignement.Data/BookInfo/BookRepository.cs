using TestProject.DTO.Book;
using Newtonsoft.Json;

namespace TestProject.Data.BookInfo
{
    public class BookRepository : IBookRepository
    {
        readonly string jsonContent = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory() + "\\Data", @"rawData.json"));

        public IEnumerable<BookInfoDTO>? GetBooks()
        {
            IEnumerable<BookInfoDTO>? bookList = JsonConvert.DeserializeObject<IEnumerable<BookInfoDTO>>(jsonContent);
            return bookList;
        }

        public BookInfoDTO? GetBookById(int id)
        {
            IEnumerable<BookInfoDTO>? bookList = JsonConvert.DeserializeObject<IEnumerable<BookInfoDTO>>(jsonContent);
            return bookList?.FirstOrDefault(book => book.Id == id);
        }

        public IEnumerable<BookInfoDTO>? GetBooksByTitle(string filter)
        {
            IEnumerable<BookInfoDTO>? bookList = JsonConvert.DeserializeObject<IEnumerable<BookInfoDTO>>(jsonContent);
            return bookList?.Where(book => book.Title.Contains(filter));
        }

        public IEnumerable<BookInfoDTO>? GetBooksByDescription(string filter)
        {
            IEnumerable<BookInfoDTO>? bookList = JsonConvert.DeserializeObject<IEnumerable<BookInfoDTO>>(jsonContent);
            return bookList?.Where(book => book.Description.Contains(filter));
        }

    }
}
