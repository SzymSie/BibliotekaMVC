﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteka.Models;
using Biblioteka.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteka.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public ViewResult List()
        {
            //ViewBag.HeaderOfThePage = "Library";
            //return View(_bookRepository.AllBooks);
            BooksListViewModel booksListViewModel = new BooksListViewModel();
            booksListViewModel.Books = _bookRepository.AllBooks;
            booksListViewModel.HeaderOfThePage = "Library";
            return View(booksListViewModel);
        }
    }
}