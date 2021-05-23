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
    public class EmployeeController : Controller
    {
        IEmployee _user;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployee user, IMapper mapper)
        {
            _user = user;
            this._mapper = mapper;
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(ListEmployee), 200)]
        [HttpGet]
        public List<ListEmployee> Get()
        {
            var emps = _user.GetUsers();
            var empsVM = _mapper.Map<List<ListEmployee>>(emps);
            return empsVM;
        }

        [HttpGet("{Id}", Name ="GetUser")]
        public Employee Get(int Id)
        {
            return _user.GetUserById(Id);
        }

        [HttpPost]
        public ActionResult Post([FromForm]Employee entity)
        {
            //var emp = _mapper.Map<Employee>(entity);
            _user.AddUser(entity);
            entity.Id = _user.GetLatestIdInserted();
            return new CreatedAtRouteResult("GetUser", new { id = entity.Id }, entity);
        }


        [HttpPut]
        public IActionResult Put(int Id, Employee entity)
        {
            var emp = _user.GetUserById(Id);
            emp.FirstName = entity.FirstName;
            emp.LastName = entity.LastName;
            emp.Email = entity.Email;
            emp.Address= entity.Address;
            _user.UpdateUser(emp);
            return NoContent();
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
