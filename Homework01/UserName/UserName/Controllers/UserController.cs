using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UserName.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            return StatusCode(StatusCodes.Status200OK, StaticDb.UserName);
        }

        [HttpGet("{index}")]
        public ActionResult<string> Get(int index)
        {
            try
            {
                if (index < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, $"The index has negative value!");
                }

                if (index >= StaticDb.UserName.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"There is no username with index {index}");
                }

                return StatusCode(StatusCodes.Status200OK, StaticDb.UserName[index]);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        

        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                using(StreamReader reader = new StreamReader(Request.Body))
                {
                    string user = reader.ReadToEnd();
                    StaticDb.UserName.Add(user);
                    return StatusCode(StatusCodes.Status201Created, "The username was created");
                }
            }
            catch (Exception e)
            {
                //to-do log e
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(Request.Body))
                {
                    string requestBody = streamReader.ReadToEnd();
                    int index = Int32.Parse(requestBody);
                    if (index < 0)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, "The index has negative value!");
                    }

                    if (index >= StaticDb.UserName.Count)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, $"There is no username with index {index}");
                    }

                    StaticDb.UserName.RemoveAt(index);
                    return StatusCode(StatusCodes.Status204NoContent, "The username was deleted");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }
    }
}
