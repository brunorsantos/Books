using AutoMapper;
using Books.api.Filters;
using Books.api.Models;
using Books.api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.api.Controllers
{
    [Route("api/bookcollections")]
    [ApiController]
    public class BookCollections : ControllerBase
    {
        private IBooksRepository _booksRepository;
        private IMapper _mapper;

        public BookCollections(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
            _mapper = mapper;
        }

        [HttpPost]
        [BooksResultFilter]
        public async Task<IActionResult> CreatBookCollection([FromBody] IEnumerable<BookForCreation> bookCollection)
        {


            var bookEntities = _mapper.Map<IEnumerable<Entities.Book>>(bookCollection);

            foreach (var bookEntity in bookEntities)
            {
                _booksRepository.AddBook(bookEntity);
            }

            await _booksRepository.SaveChangesAsync();

            return Ok();
        }
    }
        
}
