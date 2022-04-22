using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Entities.Concrete;
using MovieApp.Uow;

namespace MovieApp.Services.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        IUnitOfWork _uow;
        public SeriesController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpGet(Name = "GetAllSeries")]
        public IEnumerable<Series> GetAllSeries()
        {
            return _uow._seriesRepository.List();
        }
        [HttpPost(Name = "AddSeries")]
        public Series AddSeries([FromBody] Series series)
        {
            _uow._seriesRepository.Create(series);
            _uow.Save();
            return series;
        }
        [HttpPut(Name = "UpdateSeries")]
        public Series UpdateSeries([FromBody] Series series)
        {
            _uow._seriesRepository.Update(series);
            _uow.Save();
            return series;
        }
    }
}
