using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Actor
    {
        [Key, Required]
        public int id { get; set; }

        [Required, StringLength(128)]
        public string firstName { get; set; }

        [Required, StringLength(128)]
        public string lastName { get; set; }
    }
}
