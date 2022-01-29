using CleanCQRS.Domain.Models.Book;
using CleanCQRS.Models.Commands.Book;
using CleanCQRS.Models.Queries.Book.GetBookById;
using CleanCQRS.Models.Queries.Book.GetBooks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanCQRS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseApiController
    {
        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetBooksRequest()));
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] BookModel book)
        {
            var response = await Mediator.Send(
                new CreateBookCommand()
                {
                    Title = book.Title,
                    Author = book.Author,
                    Category = book.Category,
                    Publisher = book.Publisher,
                    PublishedDate = book.PublishedDate
                });

            if (response.Succeeded)
                return Ok(await Mediator.Send(new GetBookByIdRequest() { Id = response.Id }));

            return Ok(response);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
