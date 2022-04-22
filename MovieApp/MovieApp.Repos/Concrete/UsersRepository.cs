using MovieApp.Core;
using MovieApp.Dal;
using MovieApp.Entities.Concrete;
using MovieApp.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Repos.Concrete
{
    public class UsersRepository : BaseRepository<Users>,IUsersRepository
    {
        public UsersRepository(Context db) : base(db)
        {
        }
    }
}
