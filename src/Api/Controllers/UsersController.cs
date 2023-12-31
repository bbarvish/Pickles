using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Pickles.Api.Extensions;
using Pickles.Domain.Events;
using Pickles.Domain.Infrastructure;
using Pickles.Domain.Models;
using Pickles.Domain.Services;

namespace Pickles.Api.Controllers;

[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IEventStore _eventStore;
    private readonly IMapper _mapper;
    private readonly UserService _userService;
    private readonly IValidator<User> _validator;


    public UsersController(IEventStore eventStore, IMapper mapper, UserService userService, IValidator<User> validator)
    {
        _eventStore = eventStore;
        _mapper = mapper;
        _userService = userService;
        _validator = validator;
    }
    
    // GET api/users
    [HttpGet]
    public async Task<IEnumerable<User>> Get()
    {
        return await _userService.GetAll();
    }

    // GET api/users/bob@bobmarley.com
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> Get(string id)
    {
        var result = await _userService.Get(id);

        if (result is null)
        {
            return NotFound($"No user with email {id}");
        }
        
        return result;
    }
    
    // GET api/player/5
    [HttpPost]
    public async Task<ActionResult<User> >Add([FromBody]User user)
    {
        //HACK: to test it out
        var id = Guid.NewGuid().ToString("N");
        var e = _mapper.Map<UserCreated>(user);
        await _eventStore.Save(e, id, user.GetType().FullName, null);
        
        var validationResult = await _validator.ValidateAsync(user);

        if (validationResult.IsValid)
        {
            Console.WriteLine("IsValid");
            var result = await _userService.Add(user);
            return result;   
        }
        else
        {
            validationResult.AddToModelState(this.ModelState);
            return BadRequest(ModelState);
        }
    }
}