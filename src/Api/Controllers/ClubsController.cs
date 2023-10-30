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
    public async Task<ActionResult<Player>> AddPlayer(string clubId, [FromBody]Player player)
    {
        //NOTE:  Storing the many to many Player <-> Club relationship
        //  Can do it in a Dynamo table  with both IDs as pk, sk
        //  player-123, club-456
        // and also the inversion
        //  club-456, player-123
        // Can also be done with Dynamo's index feature
        // Also, a Club Aggregate can store a list of player
        // likewise a Player Aggregate can store a list of clubs
        Console.WriteLine($"Adding player: {player.ToJson()} to club {clubId}");
        return player;
    }
    
    [HttpDelete("{clubId}/{playerId}")]
    public async Task<ActionResult> RemovePlayer(string clubId, string playerId)
    {
        Console.WriteLine($"Removing player: {playerId} from club {clubId}");
        return new OkResult();
    }
}