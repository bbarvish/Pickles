using Microsoft.AspNetCore.Mvc;
using Pickles.Domain.Models;

namespace Pickles.Api.Controllers;

[Route("api/[controller]")]
public class LeaguesController : ControllerBase
{
    
    [HttpGet]
    public async Task<ActionResult<List<League>>> GetAll()
    {
        return new ActionResult<List<League>>(new List<League>
        {
        });

    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<League>> Get(string id)
    {
        return new League
        {
            Id = id
        };
    }
    
    [HttpPost]
    public async Task<ActionResult<League>> Add([FromBody]League item)
    {
        return item;
    }
    
    [HttpPost("{id}/match")]
    public async Task<ActionResult<Match>> AddMatch([FromBody]Match item)
    {
        //Add match to league
        return item;
    }
    
    [HttpPut("{id}/match")]
    public async Task<ActionResult<Match>> UpdateMatch([FromBody]Match item)
    {
        //Add match to league
        return item;
    }
}