using AutoMapper;
using Biblioteka.Dtos;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            // Source -> Target
            CreateMap<Book, BookReadDto>();     // get
            CreateMap<BookCreateDto, Book>();   // create
            CreateMap<BookUpdateDto, Book>();   // put
            CreateMap<Book, BookUpdateDto>();   // patch
        }
    }
}
