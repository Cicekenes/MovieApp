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
    public class SeriesRepository : BaseRepository<Series>,ISeriesRepository
    {
        Context _context;
        public SeriesRepository(Context db) : base(db)
        {
            _context = db;
        }

        public List<SeriesList> SeriesGetAll()
        {
            return Set().Select(s => new SeriesList
            {
                Id = s.Id,
                Name = s.SeriesName,
                CategoryName = s.Category.CategoryName,
                Actors = s.Actors.ToList(),
                Imdb = s.ImdbScore,
                Languages = s.Languages,
                Seasons = s.Seasons,
                Times = s.Times,
                Year = s.Year
            }).ToList();
        }
    }
}
