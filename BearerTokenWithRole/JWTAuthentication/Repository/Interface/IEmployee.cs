using JWTAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication.Repository.Interface
{
    public interface IEmployee
    {
        List<Employee> GetUsers();

        Employee GetUserById(int Id);

        void AddUser(Employee entity);

        void DeleteUser(int Id);

        int GetLatestIdInserted();

        void UpdateUser(Employee entity);
    }
}
