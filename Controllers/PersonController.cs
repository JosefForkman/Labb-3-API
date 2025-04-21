using System.Threading.Tasks;
using Labb_3_API.Data;
using Labb_3_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb_3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController(DBContext context) : ControllerBase
    {

        [HttpGet(Name = "GetAllPersons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ICollection<Person>>> Get()
        {
            var persons = await context.Persons.ToListAsync();
            if (persons == null || persons.Count == 0)
            {
                return NotFound(new { message = "No persons found." });
            }

            return Ok(persons);
        }
    }
}
