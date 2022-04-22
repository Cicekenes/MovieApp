using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Entities.Concrete;
using MovieApp.Uow;

namespace MovieApp.Services.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        IUnitOfWork _uow;
        public ActorsController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        [HttpGet(Name = "GetAllActors")]
        public IEnumerable<Actors> GetAllActors()
        {
            return _uow._actorsRepository.List();
        }

        [HttpPost(Name = "AddActor")]
        public Actors AddActor([FromBody] Actors actors)
        {
            _uow._actorsRepository.Create(actors);
            _uow.Save();
            return actors;
        }

        [HttpPut(Name = "UpdateActor")]
        public Actors UpdateActor([FromBody] Actors actors)
        {
            _uow._actorsRepository.Update(actors);
            _uow.Save();
            return actors;
        }

        // 1-1
        [HttpDelete(Name = "DeleteActor")]
        public bool DeleteActor([FromBody] Actors actors)
        {
            actors.Status = false;
            _uow._actorsRepository.Update(actors);
            _uow.Save();
            return true;
        }
    }
}
