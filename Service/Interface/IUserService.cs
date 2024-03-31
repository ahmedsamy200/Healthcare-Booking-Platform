using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserService
    {
        Task<bool> AddUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<User> Login(User user);

        Task<IEnumerable<User>> GetUserByName(string name);
        Task<bool> IsExist(User user);
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsers();
    }
}
