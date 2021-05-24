using CoreWebAPI.Models;
using CoreWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI.Controllers
{
    [Route("api/genresResult")]
    public class GenreWithActionResultController : Controller
    {
        private readonly IGenreRepository _genre;
        public GenreWithActionResultController(IGenreRepository genre)
        {
            _genre = genre;
        }

        [HttpGet] // api/genres Or
        [HttpGet("list")] // api/genres/list
        // Do not mix synchromouse with asynchronous.
        // It help to create responsive application
        public async Task<ActionResult<List<Genre>>> Get()
        {
            return await _genre.GetAllGenre();
        }

        [HttpGet("{Id}")] // another way is to pass Id as route : api/genres/1
        public ActionResult<Genre> Get(int Id, string name)
        {
            var genre = _genre.GetGenreById(Id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        //Or

        //[HttpGet("{Id}")] 
        //public IActionResult Get(int Id)
        //{
        //    var genre = _genre.GetGenreById(Id);
        //    if (genre == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok("Asif"); // you can return any type not only Genre, with ActionResult<Type> it give an error if different type return with Ok
        //}

        [HttpPost]
        public void Post()
        {

        }

        [HttpPut]
        public void Put()
        {

        }

        [HttpDelete]
        public void Delete()
        {

        }
    }
}
