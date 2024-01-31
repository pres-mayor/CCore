using TestProject.DTO.Book;
using Newtonsoft.Json;
using TestProject.Data.Entities;
using static System.Reflection.Metadata.BlobBuilder;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Data.BookInfo
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksContext? _context = null;
        private readonly IMapper _mapper;

        public BookRepository(BooksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookInfoDTO>?> GetBooks()
        {
            var books = await _context.Books.ToListAsync();
            return _mapper.Map<IList<BookInfoDTO>>(_context.Books.ToList());
        }

        public IEnumerable<BookInfoDTO>? GetAllBooks()
        {
            var books = GetBooks().Result;
            var result = _mapper.Map<IList<BookInfoDTO>>(books);
            return result;
        }

        public BookInfoDTO? GetBookById(int id)
        {
            var book = GetBooks().Result?.FirstOrDefault(x => x.Id == id);
            var result = _mapper.Map<BookInfoDTO>(book);
            return book;
        }

        public IEnumerable<BookInfoDTO>? GetBooksByTitle(string filter)
        {
            var books = GetBooks().Result?.Where(x => x.Title.Contains(filter));
            var result = _mapper.Map<IList<BookInfoDTO>>(books);
            return result;
        }

        public IEnumerable<BookInfoDTO>? GetBooksByDescription(string filter)
        {
            var books = GetBooks().Result?.Where(x => x.Description.Contains(filter));
            var result = _mapper.Map<IList<BookInfoDTO>>(books);
            return result;
        }

    }
}
