using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Genre
    {
        [Key, Required]
        public int id { get; set; }

        [Required]
        public string name { get; set; }
    }
}
