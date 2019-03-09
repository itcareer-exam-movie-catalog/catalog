using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Movie
    {
        [Key, Required]
        public int id { get; set; }

        [Required, StringLength(128)]
        public string title { get; set; }

        [Required]
        public int directorId { get; set; }

        [Required]
        public int publicationYear { get; set; }

        [Required, StringLength(128)]
        public string actorIds { get; set; }

        [Required, StringLength(128)]
        public string categoryIds { get; set; }

        [Required]
        public decimal price { get; set; }

        public byte[] photo { get; set; }
    }
}
