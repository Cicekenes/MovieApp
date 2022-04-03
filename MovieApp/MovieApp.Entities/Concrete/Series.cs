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
        [ForeignKey("CategoryId")] //
        public ICollection<Categories> ?Categories { get; set; } //n to n
        public int CategoryId { get; set; }

    }
}
