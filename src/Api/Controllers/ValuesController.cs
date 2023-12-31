﻿using Microsoft.AspNetCore.Mvc;
using Pickles.Domain.Services;

namespace Pickles.Api.Controllers;

[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    private readonly ValuesService _valuesService;

    public ValuesController(ValuesService valuesService)
    {
        _valuesService = valuesService;
    }
    
    // GET api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<string> Get(int id)
    {
        var result = await _valuesService.Get(id);
        return result;
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody]string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}