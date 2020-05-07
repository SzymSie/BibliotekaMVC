using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Data
{
    public class SqlLibraryRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public SqlLibraryRepository(LibraryContext context)
        {
            _context = context;
        }

        public void CreateBook(Book book)
        {
            if(book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            _context.Books.Add(book);
        }

        public void DeleteBook(Book book)
        {
            if(book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            _context.Books.Remove(book);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookByISBN(int ISBN)
        {
            return _context.Books.FirstOrDefault(p => p.ISBN == ISBN);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void UpdateBook(Book book)
        {
            // Nothing is needed because of dbContext, it's implemented like that
        }
    }
}
