using Microsoft.EntityFrameworkCore;

namespace IntivePatronageAPI.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        { 
        }
        public DbSet<Author> authors { get; set; } = null!;
        public DbSet<Book> books { get; set; } = null!;
        public DbSet<BookAuthor> bookAuthors { get; set; } = null!;
    }
}
