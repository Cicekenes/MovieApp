using MovieApp.Dal;
using MovieApp.Entities.Concrete;
using MovieApp.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Repos.Concrete
{
    public class AuthRepository : IAuthRepository
    {
        Context _db;
        public AuthRepository(Context db,Users users)
        {
            _db = db;
            
        }
        public Users Login(string userName, string Password)
        {
            //Giriş yapma işlemi
            Users ?users=_db.Set<Users>().FirstOrDefault(x=>x.UserName==userName);
            if (users==null)
            {
                return null;
            }
            else
            {
                if (!VerifyPassWord(Password,users.PasswordHash,users.PasswordSalt))
                {
                    return null;
                }
                else
                {
                    return users;
                }
            }

        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public void Register(Users _users, string Password) //Kayıt olma
        {
            byte[] passwordSalt, passwordHash;
            CreateHashPassword(Password, out passwordHash, out passwordSalt );
            _users.PasswordHash= passwordHash;
            _users.PasswordSalt= passwordSalt;

            _db.Set<Users>().Add(_users);
            _db.SaveChanges();

        }

        private void CreateHashPassword(string password,out byte[] passwordHash,out byte[] passwordSalt) // password şifreleme
        {
            var hmac= new HMACSHA512(); // password encryption
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

     

        private bool VerifyPassWord(string password, byte[] userPasswordHash, byte[] userPasswordSalt)
        {
            //Giriş yaparken password doğrulama işlemidir
            var hmac = new HMACSHA512(userPasswordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != userPasswordHash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
