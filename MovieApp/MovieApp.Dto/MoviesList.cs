using MovieApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Dto
{
    public class MoviesList
    {
        public int Id { get; set; }
        public string Name { get; set; } // Title and name
        public DateTime Year { get; set; }
        public List<Categories> ?CategoryNames { get; set; }
        public List<Actors> Actors { get; set; }
        public int Times { get; set; }
        public string Languages { get; set; }
        public decimal Imdb { get; set; }
    }
}
