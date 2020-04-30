using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    public interface IBookRepository
    {
        IEnumerable<Book> AllBooks();
        Book Add(Book newBook);
    }
}
