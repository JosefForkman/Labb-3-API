using Labb_3_API.Data;
using Labb_3_API.DTO;
using Labb_3_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb_3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntrestController(DBContext context) : ControllerBase
    {
        [HttpGet(Name = "GetAllServices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ICollection<IntrestRespond>>> Get()
        {
            var Intrests = await context.Intrests
                .Select(intrest => new IntrestRespond 
                    { 
                        Id = intrest.Id,
                        Title = intrest.Title, 
                        Description = intrest.Description 
                    })
                .ToListAsync();
            if (Intrests == null || Intrests.Count == 0)
            {
                return NotFound(new { message = "No services found." });
            }

            return Ok(Intrests);
        }
        [HttpPost("{PersonId}", Name = "AddIntrestToPerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IntrestRespond>> AddIntrestToPerson([FromBody] IntrestRequest intrest, int PersonId)
        {
            if (PersonId == 0 || intrest == null)
            {
                return BadRequest(new { message = "Need to provide a id grether when 0" });
            }

            var person = await context.Persons.FindAsync(PersonId);
            if (person == null)
            {
                return NotFound(new { message = "Person not found." });
            }
            var intrestAllreadyExists = await context.Intrests.FirstOrDefaultAsync(i => i.Title == intrest.Title);
            if (intrestAllreadyExists == null)
            {
                var newIntrest = new Intrest
                {
                    Title = intrest.Title,
                    Description = intrest.Description
                };
                context.Intrests.Add(newIntrest);
                await context.SaveChangesAsync();
                
                intrestAllreadyExists = newIntrest;
            }

            var personIntrest = new PersonIntrest
            {
                Person = person,
                Intrest = intrestAllreadyExists
            };


            context.PersonIntrests.Add(personIntrest);
            await context.SaveChangesAsync();
            
            var intrestRespond = new IntrestRespond
            {
                Id = intrestAllreadyExists.Id,
                Title = intrestAllreadyExists.Title,
                Description = intrestAllreadyExists.Description
            };
            return CreatedAtAction(nameof(Get), new { id = intrestRespond.Id }, intrestRespond);
        }
    }
}
