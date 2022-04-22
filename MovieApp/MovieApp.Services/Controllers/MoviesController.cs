using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Entities.Concrete;
using MovieApp.Uow;

namespace MovieApp.Services.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        IUnitOfWork _uow;
        public MoviesController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpGet(Name = "GetAllMovies")]
        public IEnumerable<Movies> GetAllMovies()
        {
            return _uow._moviesRepository.List();
        }
        [HttpPost(Name = "AddMovies")]
        public Movies AddMovies([FromBody] Movies movies)
        {
            _uow._moviesRepository.Create(movies);
            _uow.Save();
            return movies;
        }
        [HttpPut(Name = "UpdateMovies")]
        public Movies UpdateMovies([FromBody] Movies movies)
        {
            _uow._moviesRepository.Update(movies);
            _uow.Save();
            return movies;
        }

    }
}
