using CoreWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI.Services
{

    public interface IGenreRepository
    {
        Task<List<Genre>> GetAllGenre();
        Genre GetGenreById(int Id);
    }

    public class GenreRepository : IGenreRepository
    {
        List<Genre> _genreList;
        public GenreRepository()
        {
            _genreList = new List<Genre>()
            {
                new Genre(){ Id=1, Name="Comedy"},
                new Genre(){ Id=2, Name="Drama"}
            };
        }

        public async Task<List<Genre>> GetAllGenre()
        {
            Task.Delay(2000);
            return _genreList;
        }
        
        public Genre GetGenreById(int Id)
        {
            return _genreList.FirstOrDefault(p => p.Id == Id);
        }
    }
}
