using Microsoft.AspNetCore.Mvc;
using Pickles.Domain.Models;

namespace Pickles.Api.Controllers;

[Route("api/[controller]")]
public class ClubsController : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Club>> Get()
    {
        return new List<Club>();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Club>> Get(string id)
    {
        return new Club
        {
            Id = id
        };
    }
    
    [HttpPost]
    public async Task<ActionResult<Club> >Add([FromBody]Club club)
    {
        Console.WriteLine($"Adding club: {club.ToJson()}");
        return club;
    }
    
    [HttpPost("{clubId}/player")]
    public async Task<ActionResult<Player> >AddPlayer(string clubId, [FromBody]Player player)
    {
        Console.WriteLine($"Adding player: {player.ToJson()} to club {clubId}");
        return player;
    }
}