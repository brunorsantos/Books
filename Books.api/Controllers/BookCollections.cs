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
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBooksRepository _booksRepository;
        private IMapper _mapper;

        public BooksController(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
            _mapper = mapper;
        }

        [HttpGet]
        [BooksResultFilter]
        public async Task<IActionResult> GetBooks()
        {
            var bookEntities = await _booksRepository.GetBooksAsync();

            return Ok(bookEntities);
        }
        [HttpGet]
        [BookResultFilter]
        [Route("{id}", Name = "GetBook" )]
        public async Task<IActionResult> GetBook(Guid id)
        {
            var bookEntity = await _booksRepository.GetBookAsync(id);
            if (bookEntity == null)
            {
                return NotFound();
            }

            return Ok(bookEntity);
        }

        [HttpPost]
        [BookResultFilter]
        public async Task<IActionResult> CreateBook([FromBody]BookForCreation book)
        {
            var bookEntity = _mapper.Map<Entities.Book>(book);
            _booksRepository.AddBook(bookEntity);
            await _booksRepository.SaveChangesAsync();


            await _booksRepository.GetBookAsync(bookEntity.Id);

            return CreatedAtRoute("GetBook", new {id = bookEntity.Id }, bookEntity);
        }
    }
}
