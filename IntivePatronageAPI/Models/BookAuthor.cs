using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntivePatronageAPI.Models
{
    [Keyless]
    public class BookAuthor
    {
        [ForeignKey("book")]
        public int bookId { get; set; }
        [ForeignKey("author")]
        public int authorId { get; set; }

        public virtual Book book { get; set; }
        public virtual Author author { get; set; }
    }
}
