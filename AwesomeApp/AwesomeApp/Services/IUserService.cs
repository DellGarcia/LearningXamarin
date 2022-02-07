using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AwesomeApp.Models;

namespace AwesomeApp.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(Guid id);

        Task AddUser(User user);

        Task SaveUser(User user);

        Task DeleteUser(User user);
    }
}
