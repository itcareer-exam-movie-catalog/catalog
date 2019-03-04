using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Publisher
    {
        [Key, Required]
        public int id { get; set; }

        [Required]
        public string name { get; set; }
    }
}
