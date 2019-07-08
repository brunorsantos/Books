using AutoMapper;
using Books.api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.api
{
    public class BooksProfile : Profile
    {

        public BooksProfile()
        {
            CreateMap<Book, Models.Book>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}" ));

            CreateMap<Models.BookForCreation, Entities.Book>();
        }
    }
}
