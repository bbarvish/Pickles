using AutoMapper;
using Pickles.Domain.Events;
using Pickles.Domain.Infrastructure;
using Pickles.Domain.Infrastructure.Repositories;
using Pickles.Domain.Models;

namespace Pickles.Domain.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMessagingService _messagingService;
    private readonly IMapper _mapper;


    public UserService(IUserRepository userRepository, IMessagingService messagingService, IMapper mapper, IIdGenerator idGenerator)
    {
        _userRepository = userRepository;
        _messagingService = messagingService;
        _mapper = mapper;
    }
    public async Task<User> Add(User user)
    {
        var result = await _userRepository.Add(user);
        var toPublish = _mapper.Map<UserCreated>(user);
        await _messagingService.Publish(toPublish);
        return result;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _userRepository.GetAll();
    }
    
    public async Task<User> Get(string id)
    {
        return await _userRepository.Get(id);
    }
}