using CoreWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI.Services
{
    public interface IUserRepository
    {
        Task AddUser(User entity);
        Task<List<User>> getAllUsers();
        Task<User> GetUserById(int Id);
    }
    public class UserRepository : IUserRepository
    {
        List<User> _lstUsers; 

        public UserRepository()
        {
            _lstUsers = new List<User>()
            {
                new User(){ Id=1, FirstName="Asif", LastName="Sayyad", Age=31, EmailId="Asif@gmail.com", Address="Pune" },
                new User(){ Id=2, FirstName="John", LastName="Potter", Age=31, EmailId="John@gmail.com", Address="Sydney" },
                new User(){ Id=3, FirstName="Peter", LastName="Granger", Age=31, EmailId="Peter@gmail.com", Address="New York" }
            };   
        }

        public async Task<List<User>> getAllUsers()
        {
            Task.Delay(1000);
            return _lstUsers;
        }

        public async Task<User> GetUserById(int Id)
        {
            Task.Delay(1000);
            return _lstUsers.FirstOrDefault(p=>p.Id == Id);
        }

        public async Task AddUser(User entity)
        {
            _lstUsers.Add(entity);
        }
    }
}
