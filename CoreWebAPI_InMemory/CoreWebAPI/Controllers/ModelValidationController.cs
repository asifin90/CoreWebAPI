using CoreWebAPI.Models;
using CoreWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI.Controllers
{
    [Route("api/genreRes")]
    public class ModelValidationController : Controller
    {
         private readonly IGenreRepository _genre;
        public ModelValidationController(IGenreRepository genre)
        {
            _genre = genre;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            return await _genre.GetAllGenre();
        }

        [HttpGet("{Id}")]
        public ActionResult<Genre> Get(int Id, [FromHeader]string name)
        {
            if (ModelState.IsValid)
            {
                var genre = _genre.GetGenreById(Id);
                if (genre == null)
                {
                    return NotFound();
                }
                return Ok(genre);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpPost]
        public ActionResult Post([FromBody] Genre entity)
        {
            if (ModelState.IsValid)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(ModelState);
            }
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
