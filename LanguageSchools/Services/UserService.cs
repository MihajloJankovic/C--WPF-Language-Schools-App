using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchools.Models;
using LanguageSchools.CustomExceptions;
using LanguageSchools.Repositories;

namespace LanguageSchools.Services
{
    class UserService : IUserService
    {
        private IUserRepository repostory;

        public UserService()
        {   
            repostory = new UserRepository();
        }

        public List<User> GetActiveUsers()
        {
           
        }
        public User GetUserById(String email)
        {

        }

        public List<User> GetAll()
        {
            return repostory.GetAll();
        }

        public void Add(User user)
        {
            repostory.Add(user);
        }

        public void Update(string email, User user)
        {
            repostory.Update(email, user);
        }

        public void Delete(string email)
        {
            repostory.Delete(email);
        }
    }
}
