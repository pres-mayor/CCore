using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestProject.DTO;
using TestProject.Data.BookInfo;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FidsCodingAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IConfiguration _configuration;

        public BooksController(ILogger<BooksController> logger, IBookRepository bookRepository, IConfiguration configuration)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetBooks")]
        public IEnumerable<Book> Get([FromQuery] int page = 1, [FromQuery] int pagesize = 10)
        {
            var books = _bookRepository.GetBooks();
            var query = books?.AsQueryable();

            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pagesize);

            query = query.Skip((page - 1) * pagesize).Take(pagesize);


            IEnumerable<Book> result = query.Select(x => new Book
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Category = x.CategoryId.ToString(),
                PublishDateUtc = x.PublishDateUtc
            });

            return result;
        }

        [HttpGet]
        [Route("GetBookById")]
        public Book GetFlightByFlightNumber(int id)
        {
            var book = _bookRepository.GetBookById(id);
            Book result = new Book
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Category = book.CategoryId.ToString(),
                PublishDateUtc = book.PublishDateUtc
            };

            return result;
        }

        [HttpGet]
        [Route("GetBooksByTitle")]
        public IEnumerable<Book> GetBooksByTitle([FromQuery] int page = 1, [FromQuery] int pagesize = 10, [FromQuery] string title = "")
        {
            var books = _bookRepository.GetBooksByTitle(title);
            var query = books?.AsQueryable();

            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pagesize);

            query = query.Skip((page - 1) * pagesize).Take(pagesize);


            IEnumerable<Book> result = query.Select(x => new Book
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Category = x.CategoryId.ToString(),
                PublishDateUtc = x.PublishDateUtc
            });

            return result;
        }

        [HttpGet]
        [Route("GetBooksByDescription")]
        public IEnumerable<Book> GetBooksByDescription([FromQuery] int page = 1, [FromQuery] int pagesize = 10, [FromQuery] string title = "")
        {
            var books = _bookRepository.GetBooksByDescription(title);
            IEnumerable<TestProject.DTO.Book.BookInfoDTO>? query = null;

            query = PaginateResults(page, pagesize, books);

            IEnumerable<Book> result = query.Select(x => new Book
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Category = x.CategoryId.ToString(),
                PublishDateUtc = x.PublishDateUtc
            });

            return result;
        }

        private static IQueryable<TestProject.DTO.Book.BookInfoDTO> PaginateResults(int page, int pagesize, IEnumerable<TestProject.DTO.Book.BookInfoDTO>? query)
        {
            query = query?.Skip((page - 1) * pagesize).Take(pagesize);
            return query.AsQueryable();
        }

    }
}
