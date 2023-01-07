using IntivePatronageAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntivePatronageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly LibraryContext _dbContext;
        public AuthorController(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Author
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            if (_dbContext.authors == null)
            {
                return NotFound();
            }
            return await _dbContext.authors.ToListAsync();
        }

        // GET: api/Author/firstName
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthor(string name)
        {
            if (_dbContext.authors == null)
            {
                return NotFound();
            }
            
            var authors = await _dbContext.authors.Where(n => n.firstName == name || n.lastName == name).ToListAsync();
            if (authors == null)
            {
                return NotFound();
            }

            return authors;
        }

        // POST: api/Author
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            _dbContext.authors.Add(author);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(PostAuthor), new { id = author.id }, author);
        }
    }
}
