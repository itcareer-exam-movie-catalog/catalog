using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Author
    {
        [Key, Required]
        public int id { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }
    }
}
