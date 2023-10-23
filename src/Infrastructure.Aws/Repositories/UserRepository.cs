using AutoMapper;
using EfficientDynamoDb;
using Pickles.Domain.Entities;
using Pickles.Domain.Infrastructure.Repositories;
using Pickles.Domain.Models;

namespace Pickles.Infrastructure.Aws.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMapper _mapper;
    
    private readonly IDynamoDbContext _dbContext;
    public UserRepository(IMapper mapper, IDynamoDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }
    public async Task<User> Add(User user)
    {
        var entity = _mapper.Map<UserEntity>(user);
        entity.AddedOn = DateTime.UtcNow;
        entity.SetKeys();

        await _dbContext.PutItemAsync(entity);
        
        return _mapper.Map<User>(entity);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        var result = new List<User>();
        
        var scan = _dbContext.Scan<UserEntity>();
            
        await foreach (var item in scan.ToAsyncEnumerable())
        {
            result.Add(_mapper.Map<User>(item));
        }

        return result;
    }
    
    public async Task<User> Get(string emailAddress)
    {
        var emailParts = UserEntity.ParseEmail(emailAddress);
        var item = await _dbContext.GetItemAsync<UserEntity>(emailParts.domain, emailParts.userName);
        return item is null ? new User() : _mapper.Map<User>(item);
    }
    
}