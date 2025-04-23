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
                Services = p.PersonServices.Select(ps => new Service
                {
                    Id = ps.Service.Id,
                    Title = ps.Service.Title,
                    Description = ps.Service.Description
                }).ToList()
            }).ToListAsync();
            if (persons == null || persons.Count == 0)
            {
                return NotFound(new { message = "No persons found." });
            }

            return Ok(persons);
        }

        [HttpGet("{id}/LInk", Name = "GetPersonById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Person>> GetLink(int id)
        {
            var person = await context.Links.Where(p => p.PersonServices.PersonId == id).ToListAsync();

            if (person == null)
            {
                return NotFound(new { message = $"Person with ID {id} not found." });
            }

            return Ok(person);
        }
    }
}
