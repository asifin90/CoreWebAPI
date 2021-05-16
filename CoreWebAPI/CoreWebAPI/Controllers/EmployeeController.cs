using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobileAppAPI.Models;
using MobileAppAPI.Repository.Interface;
using MobileAppAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MobileAppAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployee _user;

        public EmployeeController(IEmployee user)
        {
            _user = user;
        }

        [HttpGet]
        public List<Employee> Get()
        {
            return _user.GetUsers();
        }

        [HttpGet("{Id}", Name ="GetUser")]
        public Employee Get(int Id)
        {
            return _user.GetUserById(Id);
        }

        [HttpPost]
        public ActionResult Post(Employee entity)
        {
            _user.AddUser(entity);
            return new CreatedAtRouteResult("GetUser", new { id = entity.Id }, entity);
        }

        [HttpDelete]
        public void Delete(int Id)
        {
            _user.DeleteUser(Id);
        }


        //[HttpGet("{id:int}")]
        //public string Index(string Id, [FromHeader] string name)
        //{
        //    return $"Employee Id : {Id} and Name : {name}";
        //}
    }
}
