using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Biblioteka.Dtos;
using Biblioteka.Models;
using Biblioteka.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteka.Controllers
{
    [Route("books")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<BookReadDto>> GetAllBooks()
        {
            var books = _bookRepository.GetAllBooks();
            return Ok(_mapper.Map<IEnumerable<BookReadDto>>(books));
        }

        [HttpGet("{ISBN}", Name="GetBookByISBN")]
        public ActionResult <BookReadDto> GetBookByISBN(int ISBN)
        {
            var book = _bookRepository.GetBookByISBN(ISBN);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BookReadDto>(book));
        }

        [HttpPost]
        public ActionResult <BookReadDto> CreateBook(BookCreateDto bookCreateDto)
        {
            var bookModel = _mapper.Map<Book>(bookCreateDto);
            _bookRepository.CreateBook(bookModel);
            _bookRepository.SaveChanges();

            var bookReadDto = _mapper.Map<BookReadDto>(bookModel);

            return CreatedAtRoute(nameof(GetBookByISBN), new { ISBN = bookReadDto.ISBN }, bookReadDto);
            //return Ok(bookReadDto);
        }

        [HttpPut("{ISBN}")]
        public ActionResult UpdateBook(int ISBN, BookUpdateDto bookUpdateDto)
        {
            var bookModelFromRepository = _bookRepository.GetBookByISBN(ISBN);
            if(bookModelFromRepository == null)
            {
                return NotFound();
            }

            _mapper.Map(bookUpdateDto, bookModelFromRepository);

            _bookRepository.UpdateBook(bookModelFromRepository);

            _bookRepository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{ISBN}")]
        public ActionResult PartialBookUpdate(int ISBN, JsonPatchDocument<BookUpdateDto> patchDoc)
        {
            var bookModelFromRepository = _bookRepository.GetBookByISBN(ISBN);
            if (bookModelFromRepository == null)
            {
                return NotFound();
            }

            var bookToPatch = _mapper.Map<BookUpdateDto>(bookModelFromRepository);
            patchDoc.ApplyTo(bookToPatch, ModelState);
            if(!TryValidateModel(bookToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(bookToPatch, bookModelFromRepository);

            _bookRepository.UpdateBook(bookModelFromRepository);
            _bookRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{ISBN}")]
        public ActionResult DeleteBook(int ISBN)
        {
            var bookModelFromRepository = _bookRepository.GetBookByISBN(ISBN);
            if (bookModelFromRepository == null)
            {
                return NotFound();
            }

            _bookRepository.DeleteBook(bookModelFromRepository);
            _bookRepository.SaveChanges();

            return NoContent();
        }
    }
}
