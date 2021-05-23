using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileAppAPI;
using MobileAppAPI.Controllers;
using MobileAppAPI.Models;
using AutoMapper;
using Moq;
using MobileAppAPI.Repository.Interface;
using System.Collections.Generic;
using MobileAppAPI.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {

        public IMapper BuildMapp()
        {
            var config = new MapperConfiguration( option =>
            {
                option.AddProfile(new AutoMapperProfile());
            });
            return config.CreateMapper();
        }


        [TestMethod]
        public void TestMethod1()
        {
            IEmployee _repo;
            DbContextOptions<EmployeeDbContext> dbContextOptions = new DbContextOptionsBuilder<EmployeeDbContext>().Options;
            var emp = new List<Employee>() 
            { 
                new Employee() { FirstName = "Asif", LastName = "Sayyad", Id = 1, Address = "Pune", Email = "asif@gamil.com" },
                new Employee() { FirstName = "Asif1", LastName = "Sayyad", Id = 2, Address = "Pune1", Email = "asif1@gamil.com" },
            };
            var mapper = BuildMapp();
            var empMock = new Mock<IEmployee>();
            empMock.Setup(p => p.GetUsers()).Returns(emp);
            _repo = empMock.Object;

            var empCon = new EmployeeController(_repo, mapper);
            //var empCon = new EmployeeController(new EmpDbRepository(new EmployeeDbContext(dbContextOptions)), mapper);
            int count = empCon.Get().Count;

        }

        [TestMethod]
        public void TestMethod2()
        {
            var mapper = BuildMapp();
            DbContextOptions<EmployeeDbContext> dbContextOptions = new DbContextOptionsBuilder<EmployeeDbContext>().UseSqlServer<EmployeeDbContext>("Server=(localdb)\\mssqllocaldb;Database=EmployeeDB;Trusted_Connection=True;MultipleActiveResultSets=true").Options;
            var empCon = new EmployeeController(new EmpDbRepository(new EmployeeDbContext(dbContextOptions)), mapper);
            int count = empCon.Get().Count;

        }
    }
}
