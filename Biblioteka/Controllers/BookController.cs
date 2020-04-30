using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteka.Models;
using Biblioteka.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteka.Controllers
{
    [Route("book/list")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.AllBooks();
        }

        [HttpPost]
        public ActionResult AddBook([FromForm]Book book)
        {
            _bookRepository.Add(book);
            return Redirect("/home/list");
        }
    }
}
