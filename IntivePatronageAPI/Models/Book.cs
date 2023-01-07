using System.ComponentModel.DataAnnotations;

namespace IntivePatronageAPI.Models
{
    public class Book
    {
        [Key]
        public int id { get; set; }
        [StringLength(100)]
        public string title { get; set; }
        public string description { get; set; }
        public decimal rating { get; set; }
        [StringLength(13)]
        public string ISBN { get; set; }
        public DateTime publicationDate { get; set; }
    }
}
