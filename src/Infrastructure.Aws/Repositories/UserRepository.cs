using AutoMapper;
using EfficientDynamoDb;
using Pickles.Domain.Entities;
using Pickles.Domain.Infrastructure;
using Pickles.Domain.Infrastructure.Repositories;
using Pickles.Domain.Models;

namespace Pickles.Infrastructure.Aws.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMapper _mapper;
    
    private readonly IDynamoDbContext _dbContext;
    private readonly IIdGenerator _idGenerator;

    public UserRepository(IMapper mapper, IDynamoDbContext dbContext, IIdGenerator idGenerator)
    {
        _mapper = mapper;
        _dbContext = dbContext;
        _idGenerator = idGenerator;
    }
    public async Task<User> Add(User user)
    {
        var entity = _mapper.Map<UserEntity>(user);
        
        entity.Id = _idGenerator.GenerateUniqueString();
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
    
    public async Task<User> Get(string id)
    {
        var keys = UserEntity.GetKeys(id);
        var item = await _dbContext.GetItemAsync<UserEntity>(keys.pk, keys.sk);
        return item is null ? new User() : _mapper.Map<User>(item);
    }
    
}