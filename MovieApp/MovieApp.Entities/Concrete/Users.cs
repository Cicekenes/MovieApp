using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Entities.Concrete
{
    public class Users:Base
    {
        public Users()
        {
            Comments=new HashSet<Comments>();
        }
        public string? UserName { get; set; }
        public string ?Mail { get; set; }
        public DateTime Birthdate { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool IsDeleted { get; set; } // Hesap Dondurma...
        [ForeignKey("CommentId")]
        public ICollection<Comments> ?Comments { get; set; } //1-n
        public int CommentId { get; set; }
    }
}
