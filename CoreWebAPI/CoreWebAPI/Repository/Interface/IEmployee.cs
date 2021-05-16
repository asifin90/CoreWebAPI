using MobileAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppAPI.Repository.Interface
{
    public interface IEmployee
    {
        List<Employee> GetUsers();

        Employee GetUserById(int Id);

        void AddUser(Employee entity);

        void DeleteUser(int Id);
    }
}
