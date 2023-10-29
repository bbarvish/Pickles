using Microsoft.AspNetCore.Mvc;
using Pickles.Domain.Models;

namespace Pickles.Api.Controllers;

[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Player>> Get()
    {
        return new List<Player>();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Player>> Get(string id)
    {
        return new Player
        {
            Id = id
        };
    }
    
    [HttpGet("{id}/clubs")]
    public async Task<ActionResult<Club>> GetClubsForPlayer(string id)
    {
        //All clubs this player belongs to 
        return new Club()
        {
        };
    }
    
    [HttpPost()]
    public async Task<ActionResult<Player> >Add([FromBody]Player player)
    {
        return player;
    }
}