using MovieApp.Core;
using MovieApp.Dal;
using MovieApp.Dto;
using MovieApp.Entities.Concrete;
using MovieApp.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Repos.Concrete
{
    public class MoviesRepository : BaseRepository<Movies>,IMoviesRepository
    {
        Context _context;
        public MoviesRepository(Context db) : base(db)
        {
            _context = db;
        }

        public List<MoviesList> GetMoviesLists()
        {
            return Set().Select(x => new MoviesList
            {
                Id = x.Id,
                Name=x.MovieName,
                CategoryNames=x.Categories.ToList(),
                Actors=x.Actors.ToList(),
                Imdb=x.ImdbScore,
                Languages=x.Languages,
                Times=x.Times,
                Year=x.Year
            }).ToList();
        }
    }
}
