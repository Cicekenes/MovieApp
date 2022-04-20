using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Entities.Concrete
{
    public class Comments:Base
    {
        public string ?Description { get; set; }
        public decimal Score { get; set; }
        [ForeignKey("UserId")]
        public Users ?Users { get; set; }
        public int UserId { get; set; }
    }
}
