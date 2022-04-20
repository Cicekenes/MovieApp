using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Entities.Concrete
{
    public class Actors:Base
    {
        public Actors()
        {
            Series=new HashSet<Series>();
            Movies = new HashSet<Movies>();
        }
        public string ?ActorName { get; set; }
        public string ?Description { get; set; }
        public string ?Image { get; set; }
        public ICollection<Series> ?Series { get; set; } //n to n
        public ICollection<Movies> ?Movies { get; set; }// n to n
        public bool Status { get; set; }

    }
}
