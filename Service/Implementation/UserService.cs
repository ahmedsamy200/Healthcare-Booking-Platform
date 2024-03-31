using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly ApplicationDbContext _dbContext;

        public UserService(IRepository<User> repository, ApplicationDbContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        public async Task<bool> AddUser(User user)
        {
            try
            {
                user.IsActive = true;
                var result = await _repository.Add(user);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var result = await _repository.GetById(id);
                if (result == null)
                {
                    return false;
                }
                result.IsActive = false;
                await _repository.Update(result);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                return  _repository.GetAll().Result.Where(x=>x.IsActive == true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                if (id > 0)
                {

                    var result = _repository.GetAll().Result.FirstOrDefault(x=>x.Id == id && x.IsActive == true);
                    return result;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<User>> GetUserByName(string name)
        {
            try
            {
                if (name != null)
                {
                    var users = await _repository.GetAll();
                    var result = users.Where(x => x.name.Contains(name) && x.IsActive == true);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> IsExist(User user)
        {
            try
            {
                if (user.email != null)
                {
                    var result = _repository.GetAll().Result.FirstOrDefault(x => x.email == user.email && x.Id != user.Id && x.IsActive == true);
                    if (result != null)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> Login(User user)
        {
            try
            {
                var users = await _repository.GetAll();
                var result = users.FirstOrDefault(x => x.email == user.email && x.password == user.password && x.IsActive == true);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                var result = await _repository.GetById(user.Id);
                if (result != null)
                {
                    result.name = user.name;                 
                    result.phone = user.phone;
                    result.email = user.email;

                    await _repository.Update(result);
                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
