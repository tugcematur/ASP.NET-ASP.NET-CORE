using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.Data;
using AdvancedRepository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Repository.Classes
{
    public class AuthRepos : IAuthRepos
    {

        Users _users;
        SirketContext _db;
        public AuthRepos(Users users, SirketContext db)
        {
            _users = users;
            _db = db;
        }

  

        public void Register(string UserName, string Password)
        {
            _users.UserName = UserName;
            _users.Password = BCrypt.Net.BCrypt.HashPassword(Password);  // Güvenlik açığını önlemek içinadmin bile göremeyecek
            _users.Role = "User";
            _db.Set<Users>().Add(_users);
            _db.SaveChanges();

         
        }





        public void Logout()
        {
            throw new NotImplementedException();
        }

        public Users Login(string UserName, string Password)
        {
            var user = _db.Set<Users>().Find(UserName);

            if (user != null)
            {
                bool verified = BCrypt.Net.BCrypt.Verify(Password, user.Password);

                if (verified)
                    return user;
                else return null;
            }

            else
                return null;
        }
    }
}
