using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    public class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public int ISBN { get; set; }
        public string lastRentalDate { get; set; }
        public string borrowerName { get; set; }
    }
}
