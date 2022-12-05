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

        //public List<User> GetActiveUsers()
        //{
        //   
        //}
        //public User GetUserById(String email)
        //{

        //}
        public User GetById(string jmbg)
        {
            return repostory.GetById(jmbg);
        }
        public void Delete(string email)
        {
             repostory.Delete(email);
        }



        public List<User> GetAll()
        {
            return repostory.GetAll();
        }

        public void Add(User user)
        {
            repostory.Add(user);
        }

          public void Update(User user)
        {

            repostory.Update(user);
        }

        //public void Delete(string email)
        //{
        //    repostory.Delete(email);
        //}
    }
}

