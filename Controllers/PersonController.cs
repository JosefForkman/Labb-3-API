using Labb_3_API.Data;
using Labb_3_API.DTO;
using Labb_3_API.Mapping;
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
        public async Task<ActionResult<ICollection<PersonRespond>>> Get()
        {
            var persons = await context.Persons
                .Include(person => person.PersonIntrests)
                    .ThenInclude(personIntrest => personIntrest.Intrest)
                .Include(person => person.PersonIntrests)
                    .ThenInclude(personIntrest => personIntrest.Links)
                .Select(person => person.MapToDTO())
                .ToListAsync();

            if (persons == null || persons.Count == 0)
            {
                return NotFound(new { message = "No persons found." });
            }

            return Ok(persons);
        }

        [HttpGet("{PersonId}/Link", Name = "GetPersonById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LinkRespond>> GetPersonLink(int PersonId)
        {
            if (PersonId == 0)
            {
                return BadRequest(new { message = "Need to provide a id grether when 0" });
            }
            var person = await context.Links
                .Where(link => link.PersonIntrests.PersonId == PersonId)
                .Select(link => link.MapToDTO())
                .ToListAsync();

            if (person == null || person.Count == 0)
            {
                return NotFound(new { message = $"Person with ID {PersonId} not found." });
            }

            return Ok(person);
        }

        [HttpGet("{PersonId}/Intrest", Name = "GetIntrestByPersonId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ICollection<IntrestRespond>>> GetPersonIntrest(int PersonId)
        {
            if (PersonId == 0)
            {
                return BadRequest(new { message = "Need to provide a id grether when 0" });
            }
            var person = await context.PersonIntrests
                .Where(personInterest => personInterest.PersonId == PersonId)
                .Select(personIntrest => personIntrest.Intrest.MapToDTO())
                .ToListAsync();

            if (person == null || person.Count == 0)
            {
                return NotFound(new { message = $"Person with ID {PersonId} not found." });
            }

            return Ok(person);
        }
    }
}
