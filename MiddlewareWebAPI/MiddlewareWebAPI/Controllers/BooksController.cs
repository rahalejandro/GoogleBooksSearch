using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiddlewareWebAPI.Model;
using MiddlewareWebAPI.Service;

namespace MiddlewareWebAPI.Controllers
{
    public class BooksController : ControllerBase
    {
        private readonly IBooksMiddlewareService _bookService;

        public BooksController(IBooksMiddlewareService bookService)
        {
            _bookService = bookService;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks(string query)
        {
            var response = await _bookService.SearchBooks(query);
            var books = response.ToList();
            return books;
        }

        // GET: api/Books/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Books
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
