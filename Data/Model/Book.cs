﻿using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Book
    {
        [Key, Required]
        public int id { get; set; }

        [Required, StringLength(128)]
        public string title { get; set; }

        [Required]
        public int authorId { get; set; }

        [Required]
        public int publisherId { get; set; }

        [Required]
        public int pages { get; set; }

        [Required]
        public int publicationYear { get; set; }

        [Required, StringLength(128)]
        public string categoryIds { get; set; }

        [Required]
        public decimal price { get; set; }

        public byte[] photo { get; set; }
    }
}
