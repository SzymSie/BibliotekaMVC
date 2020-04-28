using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    public class JsonBookRepository : IBookRepository
    {
        string jsonPath = @".\books.json";

        //public IEnumerable<Book> AllBooks =>
        public List<Book> AllBooks =>
            JsonSerializer.Deserialize<List<Book>>(File.ReadAllText(jsonPath));

        public Book GetBookByISBN(int ISBN)
        {
            return AllBooks.FirstOrDefault(book => book.ISBN == ISBN);
        }
        public Book Add(Book newBook)
        {
            AllBooks.Add(newBook);
            return newBook;
        }
    }
}
