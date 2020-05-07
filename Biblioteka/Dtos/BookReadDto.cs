using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Dtos
{
    public class BookReadDto
    {
        public int ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string LastRentalDate { get; set; }
        //public string BorrowerName { get; set; }
    }
}
