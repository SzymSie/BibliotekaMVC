using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    public interface IBookRepository
    {
        bool SaveChanges();

        IEnumerable<Book> GetAllBooks();
        Book GetBookByISBN(int ISBN);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}
