using Microsoft.AspNetCore.Mvc;
using ManagementSystemAPI.Core.Models;
using ManagementSystemAPI.Data.Repositories;
using ManagementSystemAPI.Core.Models.Domain;
using ManagementSystemAPI.Data.Interfaces.ManagementSystemAPI.Data.Repositories;

namespace ManagementSystemAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _repository.GetAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _repository.GetById(id);
            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            var created = await _repository.Create(book);
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Book book)
        {
            if (id != book.Id)
                return BadRequest("ID mismatch");

            var updated = await _repository.Update(book);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.Delete(id);
            if (!result) return NotFound();

            return Ok();
        }
    }
}