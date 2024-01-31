using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data.Entities
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options) 
        {
        }

        public DbSet<Book> Books { get; set;}
        public DbSet<Category> Categories { get; set;}
    }
}
