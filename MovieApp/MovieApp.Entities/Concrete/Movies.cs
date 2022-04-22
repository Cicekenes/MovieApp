using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Entities.Concrete
{
    public class Movies : Base
    {
        public Movies()
        {
            Categories=new HashSet<Categories>();
            Actors=new HashSet<Actors>();
        }
        public string? MovieName { get; set; }
        public DateTime Year { get; set; }
        public ICollection<Categories>? Categories { get; set; } // N to N
        public ICollection<Actors> ?Actors { get; set; }
        public Categories Category { get; set; } // dataya ulaşma
        public decimal ImdbScore { get; set; }
        public int Times { get; set; }
        public string Languages { get; set; }
    }
}
