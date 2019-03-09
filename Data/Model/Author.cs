﻿using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Author
    {
        [Key, Required]
        public int id { get; set; }

        [Required, StringLength(128)]
        public string firstName { get; set; }

        [Required, StringLength(128)]
        public string lastName { get; set; }
    }
}
