using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestProject.DTO;
using TestProject.Data.BookInfo;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestProject.Model;

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
        public Result GetBooks([FromQuery] int page = 1, [FromQuery] int pagesize = 10)
        {
            var books = _bookRepository?.GetAllBooks();
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

            return new Result { currentPage = page, pageSize = pagesize, totalPage = totalPages, results = result };
        }

        [HttpGet]
        [Route("GetBookById")]
        public Book? GetBookById(int id)
        {
            var book = _bookRepository?.GetBookById(id);

            if (book == null)
                return null;

            Book result = new()
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
        public Result? GetBooksByTitle([FromQuery] int page = 1, [FromQuery] int pagesize = 10, [FromQuery] string title = "")
        {
            var books = _bookRepository?.GetBooksByTitle(title);
            var query = books?.AsQueryable();
            var totalCount = query?.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pagesize);

            var bookList = query?.Skip((page - 1) * pagesize).Take(pagesize).ToList();


            IEnumerable<Book>? result = bookList?.Select(x => new Book
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Category = x.CategoryId.ToString(),
                PublishDateUtc = x.PublishDateUtc
            });

            return new Result { currentPage = page, pageSize = pagesize, totalPage = totalPages, results = result };
        }

        [HttpGet]
        [Route("GetBooksByDescription")]
        public Result GetBooksByDescription([FromQuery] int page = 1, [FromQuery] int pagesize = 10, [FromQuery] string description = "")
        {
            var books = _bookRepository?.GetBooksByDescription(description);
            var query = books?.AsQueryable();
            var totalCount = query?.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pagesize);

            var bookList = query?.Skip((page - 1) * pagesize).Take(pagesize).ToList();


            IEnumerable<Book>? result = bookList?.Select(x => new Book
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Category = x.CategoryId.ToString(),
                PublishDateUtc = x.PublishDateUtc
            });

            return new Result { currentPage = page, pageSize = pagesize, totalPage = totalPages, results = result };
        }

    }
}
