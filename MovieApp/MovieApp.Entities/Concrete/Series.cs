using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Entities.Concrete
{
    public class Series:Base
    {
        public Series()
        {
            Categories=new HashSet<Categories>();
        }
        public string ?SeriesName { get; set; }
        public DateTime Year { get; set; }
        public ICollection<Categories> ?Categories { get; set; } //n to n
        public ICollection<Actors>? Actors { get; set; }
        public Categories Category { get; set; }
        public int Seasons { get; set; }
        public decimal ImdbScore { get; set; }
        public int Times { get; set; }
        public string Languages { get; set; }
    }
}
