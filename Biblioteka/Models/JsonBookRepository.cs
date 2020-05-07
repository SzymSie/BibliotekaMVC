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
        private string jsonPath = @".\books.json";


        //public IEnumerable<Book> AllBooks =>
        public IEnumerable<Book> GetAllBooks()
        {
            using (var jsonFileReader = File.OpenText(jsonPath))
            {
                return JsonSerializer.Deserialize<Book[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public Book GetBookByISBN(int ISBN)
        {
            throw new NotImplementedException();
        }

        public void CreateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(Book book)
        {
            throw new NotImplementedException();
        }


        //public Book Add(Book newBook)
        //{
        //    List<Book> books = AllBooks().ToList();
        //    books.Add(newBook);
        //    File.WriteAllText(jsonPath, JsonSerializer.Serialize(books));
        //    return newBook;
        //}
    }
}
