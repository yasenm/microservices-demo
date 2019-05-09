using System.Collections.Generic;
using System.Threading.Tasks;

namespace UsersApi.Services
{
    public interface IUserService
    {
        T Get<T>(string id);
        IEnumerable<T> Get<T>();
        Task<bool> AddOrUpdate<T>(T user);
    }
}
