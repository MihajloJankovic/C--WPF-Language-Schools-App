using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchools.Models;

namespace LanguageSchools.Services
{
    interface IUserService
    {
        User GetById(string jmbg);
        void Delete(string email);
        List<User> GetAll();
   //     List<User> GetActiveUsers();
        void Add(User user);
        List<User> GetSch(String tekst);
   //     User GetUserById(String email);
   //     void Update(string email, User user);
   //     void Delete(string email);
    }
}
