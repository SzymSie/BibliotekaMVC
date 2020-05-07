using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Dtos
{
    public class BookUpdateDto
    {
        //public int ISBN { get; set; }
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string LastRentalDate { get; set; }
        [Required]
        public string BorrowerName { get; set; }
    }
}
