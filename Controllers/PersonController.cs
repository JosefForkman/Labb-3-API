using Labb_3_API.Data;
using Labb_3_API.DTO;
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
            var persons = await context.Persons.Select(p => new Person
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                BirthDate = p.BirthDate,
                Email = p.Email,
                PhoneNumber = p.PhoneNumber,
                Intrests = p.PersonIntrests.Select(ps => new IntrestRespond
                {
                    Id = ps.Intrest.Id,
                    Title = ps.Intrest.Title,
                    Description = ps.Intrest.Description
                }).ToList()
            }).ToListAsync();
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
        public async Task<ActionResult<LinkRespondDTO>> GetPersonLink(int PersonId)
        {
            if (PersonId == 0)
            {
                return BadRequest(new { message = "Need to provide a id grether when 0" });
            }
            var person = await context.Links
                .Where(p => p.PersonIntrests.PersonId == PersonId)
                .Select(p => new LinkRespondDTO
                {
                    Id = p.Id,
                    Title = p.Title,
                    Url = p.Url
                })
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
                .Where(p => p.PersonId == PersonId)
                .Select(p => new IntrestRespond
                {
                    Id = p.Intrest.Id,
                    Title = p.Intrest.Title,
                    Description = p.Intrest.Description
                })
                .ToListAsync();

            if (person == null || person.Count == 0)
            {
                return NotFound(new { message = $"Person with ID {PersonId} not found." });
            }

            return Ok(person);
        }
    }
}
