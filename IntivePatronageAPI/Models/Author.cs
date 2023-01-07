using System.ComponentModel.DataAnnotations;

namespace IntivePatronageAPI.Models
{
    public class Author
    {
        [Key]
        public int id { get; set; }
        [StringLength(50)]
        public string firstName { get; set; }
        [StringLength(50)]
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public bool gender { get; set; }

    }
}
