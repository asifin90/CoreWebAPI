using MobileAppAPI.Models;
using MobileAppAPI.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppAPI.Repository.Implementation
{
    public class EmpDbRepository : IEmployee
    {
        EmployeeDbContext _dbContext;
        public EmpDbRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(Employee entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(Employee entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int Id)
        {
            var emp = _dbContext.employee.Where(p => p.Id == Id).FirstOrDefault();
            _dbContext.employee.Remove(emp);
            _dbContext.SaveChanges();
        }

        public Employee GetUserById(int Id)
        {
            return _dbContext.employee.Where(p => p.Id == Id).FirstOrDefault();
        }

        public List<Employee> GetUsers()
        {
            return _dbContext.employee.ToList();
        }

        public int GetLatestIdInserted()
        {
            return _dbContext.employee.Max(p => p.Id);
        }
    }
}
