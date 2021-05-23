using MobileAppAPI.Models;
using MobileAppAPI.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppAPI.Repository.Implementation
{
    public class EmployeeRepository : IEmployee
    {
        List<Employee> _lstUsers;
        public EmployeeRepository()
        {
            _lstUsers = new List<Employee>() {
                new Employee {Id=1, FirstName="Raju", LastName="NandKishor", Address="Mumbai", Email="Raju@gmail.com" },
                new Employee {Id=2, FirstName="Asif", LastName="Sayyad", Address="Pune", Email="Asif@gmail.com" }
             };
        }
        public List<Employee> GetUsers()
        {
            return _lstUsers;
        }

        public Employee GetUserById(int Id)
        {
            return _lstUsers.Where(p => p.Id == Id).FirstOrDefault();
        }

        public void AddUser(Employee entity)
        {
            _lstUsers.Add(entity);
        }

        public void DeleteUser(int Id)
        {
            var entity = _lstUsers.Where(p => p.Id == Id).FirstOrDefault();
            _lstUsers.Remove(entity);
        }

        public int GetLatestIdInserted()
        {
            throw new NotImplementedException();
        }
        public void UpdateUser(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
