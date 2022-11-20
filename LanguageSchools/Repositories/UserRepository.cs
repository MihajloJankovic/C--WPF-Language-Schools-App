using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using LanguageSchools.Models;
using LanguageSchools.CustomExceptions;
using System.Data.SqlClient;

namespace LanguageSchools.Repositories
{
    class UserRepository : IUserRepository
    {
       
        public void Add(User user)
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO user VALUES (@Language);", con);
            cmd.Parameters.AddWithValue("Language", newUser.Email);
            cmd.ExecuteNonQuery();
            con.Close();
            
        }

        //public void Delete(string email)
        //{
        // 
        //}

        //public List<User> GetAll()
        //{
        //   
        //}

        //public User GetById(string email)
        //{
        //    
        //}

        //public void Update(string email, User updatedUser)
        //{

        //}

  
    }
}
