using MovieApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Repos.Abstract
{
    public interface IAuthRepository
    {
        void Register(Users user, string Password); // Kayıt Olma işlemi
        Users Login(string userName,string Password); //Giriş yapma işlemi
        void Logout();
    }
}
