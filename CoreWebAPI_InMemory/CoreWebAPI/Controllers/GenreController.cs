using CoreWebAPI.Models;
using CoreWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI.Controllers
{
    //[Route("api/[controller]")] // if you update controller all existing client should update based on updated controller name hence many of people avaoid this and use simple text.
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _genre;
        public GenresController(IGenreRepository genre)
        {
            _genre = genre;
        }

        [HttpGet] // api/genres Or
        [HttpGet("list")] // api/genres/list
        public List<Genre> Get()
        {
            return null; //_genre.GetAllGenre();
        }

        //[HttpGet("ById")] // api/genres/ById
        // api/genres came from route attribute declared above controller and ById is from above HttpGet attribute and combine both becomes route for this method.
        //[HttpGet("{Id}")] // another way is to pass Id as route : api/genres/1
        [HttpGet("{Id:int}/{name=Action}")] // Id:int make sure parameter pass as int and not other type, if int not defined client can pass other type but Id parameter consider as 0 in that case.
        public Genre Get(int Id, string name)
        {
            var genre = _genre.GetGenreById(Id);
            if(genre == null)
            {
                //return NotFound();
            }
            return genre;
        }


        [HttpPost]
        public void Post(User entity)
        {

        }


        [HttpDelete]
        public void Delete(int Id)
        {

        }
    }
}
