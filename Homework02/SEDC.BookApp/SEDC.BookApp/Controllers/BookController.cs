using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDC.BookApp.Models;

namespace SEDC.BookApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Book> Get()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, StaticDb.Books);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpGet("queryString")]
        public ActionResult<Book> GetByIndex(int index)
        {
            try
            {
                if (index < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request, the index can not be negative!");
                }
                if (index >= StaticDb.Books.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Resource with index {index} does not exist!");
                }

                return StatusCode(StatusCodes.Status200OK, StaticDb.Books[index]);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpGet("filter")]
        public ActionResult<List<Book>> FilterBooksFromQuery(string author, string tittle)
        {
            try
            {
                if (string.IsNullOrEmpty(author) && string.IsNullOrEmpty(tittle))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "You have to send at least one filter parameter!");
                }

                if (string.IsNullOrEmpty(author))
                {
                    List<Book> bookDb = StaticDb.Books.Where(x => x.Tittle.ToLower().Contains(tittle.ToLower())).ToList();
                    return StatusCode(StatusCodes.Status200OK, bookDb);
                }
                if (string.IsNullOrEmpty(tittle))
                {
                    List<Book> bookDb = StaticDb.Books.Where(x => x.Author.ToLower().Contains(author.ToLower())).ToList();
                    return StatusCode(StatusCodes.Status200OK, bookDb);
                }

                List<Book> filterBook = StaticDb.Books.Where(x =>
                        x.Author.ToLower().Contains(author.ToLower()) && x.Tittle.ToLower().Contains(tittle.ToLower()))
                    .ToList();
                return StatusCode(StatusCodes.Status200OK, filterBook);


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }
        [HttpGet("postBooks")]
        public IActionResult PostNote([FromQuery] Book book)
        {
            return Ok();
        }

        [HttpPost("postBook")]
        public IActionResult PostBook([FromBody] Book book)
        {
            try
            {
                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created, "Book was added");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }
        [HttpPost("listOfTitles")]
        public ActionResult<List<string>> PostBooks([FromBody] List<Book> books)
        {
            try
            {
                List<string> titles = books.Select(x => x.Tittle).ToList();
                return StatusCode(StatusCodes.Status200OK, titles);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }
    }
}
