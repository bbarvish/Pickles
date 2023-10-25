using Pickles.Domain.Models;

namespace Pickles.Domain.Infrastructure.Repositories;

public interface IUserRepository
{
    Task<User> Add(User user);
    Task<IEnumerable<User>> GetAll();
    Task<User> Get(string id);
}