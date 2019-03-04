using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Category
    {
        [Key, Required]
        public int id { get; set; }

        [Required]
        public string name { get; set; }
    }
}
