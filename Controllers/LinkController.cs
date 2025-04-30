using Labb_3_API.Data;
using Labb_3_API.DTO;
using Labb_3_API.Mapping;
using Labb_3_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb_3_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LinkController(DBContext context) : ControllerBase
{
    [HttpGet(Name = "GetLink")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ICollection<LinkRespond>>> GetLink()
    {
        var links = await context.Links.Select(link => link.MapToDTO()).ToListAsync();

        if (links == null || links.Count == 0)
        {
            return NotFound(new { message = "No links found." });
        }

        return Ok(links);
    }

    [HttpPost(Name = "AddLinkToPerson")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LinkRespond>> AddLinkToPerson([FromBody] LinkRequest link)
    {
        if (link == null || link.PersonId == 0 || link.IntrestId == 0 || link.Url == null)
        {
            return BadRequest(new { message = "Need to provide a id greater than 0" });
        }

        var personIntrest = await context.PersonIntrests.FirstOrDefaultAsync(personInterest => personInterest.PersonId == link.PersonId && personInterest.IntrestId == link.IntrestId);
        if (personIntrest == null)
        {
            return NotFound(new { message = "Person interest not found." });
        }

        var newLink = new Link
        {
            Title = link.Title,
            Url = link.Url,
            PersonIntrestId = personIntrest.Id
        };

        context.Links.Add(newLink);
        await context.SaveChangesAsync();

        return Created();
    }
}
