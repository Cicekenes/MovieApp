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
        }
        public string? MovieName { get; set; }
        public DateTime Year { get; set; }
        public ICollection<Categories>? Categories { get; set; } // N to N



    }
}
