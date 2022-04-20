using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Entities.Concrete
{
    public class Categories : Base
    {
        public Categories()
        {
            Movies = new HashSet<Movies>();
            Series = new HashSet<Series>();
        }
        public string? CategoryName { get; set; }
        public bool Status { get; set; }
        public ICollection<Movies>? Movies { get; set; } // N to N
        public ICollection<Series>? Series { get; set; } // n to n
        public Movies? Movie { get; set; }

    }
}
