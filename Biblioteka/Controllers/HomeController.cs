using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Biblioteka.Models;
using Biblioteka.ViewModels;

namespace Biblioteka.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookRepository _bookRepository;

        public HomeController(ILogger<HomeController> logger,
            IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult List()
        {
            BooksListViewModel booksListViewModel = new BooksListViewModel();
            booksListViewModel.Books = _bookRepository.GetAllBooks();
            booksListViewModel.HeaderOfThePage = "Library";
            return View(booksListViewModel);
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        [Route("AddNew")]
        [HttpGet]
        public IActionResult AddNew()
        {
            return View();
        }
    }
}
