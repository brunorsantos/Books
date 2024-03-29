﻿using AutoMapper;
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
    [BooksResultFilter]
    public class BookCollections : ControllerBase
    {
        private IBooksRepository _booksRepository;
        private IMapper _mapper;

        public BookCollections(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
            _mapper = mapper;
        }

        // api/bookcollections/(id1,id2) 
        [HttpGet("({bookIds})", Name = "GetBookCollection")]
        public async Task<IActionResult> GetBookCollection(
            [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> bookIds)
        {
            var bookEntities = await _booksRepository.GetBooksAsync(bookIds);

            if (bookIds.Count() != bookEntities.Count())
            {
                return NotFound();
            }

            return Ok(bookEntities);
        }


        [HttpPost]
        public async Task<IActionResult> CreatBookCollection([FromBody] IEnumerable<BookForCreation> bookCollection)
        {


            var bookEntities = _mapper.Map<IEnumerable<Entities.Book>>(bookCollection);

            foreach (var bookEntity in bookEntities)
            {
                _booksRepository.AddBook(bookEntity);
            }

            await _booksRepository.SaveChangesAsync();

            var bookEntitiesReturn = await _booksRepository.GetBooksAsync(bookEntities.Select(b => b.Id).ToList());

            var bookIds = string.Join(",", bookEntitiesReturn.Select(a => a.Id));

            return CreatedAtRoute("GetBookCollection",
              new { bookIds },
              bookEntitiesReturn);

       
        }
    }
        
}
