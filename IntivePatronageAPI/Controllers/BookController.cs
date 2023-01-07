using IntivePatronageAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntivePatronageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BookController : ControllerBase
    {
        private readonly LibraryContext _dbContext;

        public BookController(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/Book
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            if(_dbContext.books == null)
            {
                return NotFound();
            }
            return await _dbContext.books.ToListAsync();
        }

        // GET: api/Book/title
        [HttpGet("{title}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByTitle(string title)
        {
            if(_dbContext.books == null)
            {
                return NotFound();
            }

            var books = await _dbContext.books.Where(x => x.title.Contains(title)).ToListAsync();
            if (books == null)
            {
                return NotFound();
            }
            return books;
        }

        // POST: api/Book
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _dbContext.books.Add(book);
            
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(PostBook), new { id = book.id }, book);
        }

        // UPDATE: api/Book

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.id)
            {
                return BadRequest();
            }

            _dbContext.Entry(book).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (_dbContext.books == null)
            {
                return NotFound();
            }
            var book = await _dbContext.books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _dbContext.books.Remove(book);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(long id)
        {
            return (_dbContext.books?.Any(e => e.id == id)).GetValueOrDefault();
        }

    }

}
