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
            SqlCommand cmd = new SqlCommand("INSERT INTO Usercina VALUES (@Email,@Password,@FirstName,@LastName,@JMBG,@gender,@usertype,@address,@isactive);", con);
            cmd.Parameters.AddWithValue("@Email", user.Email );
            cmd.Parameters.AddWithValue("@Password", user.Password );
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName );
            cmd.Parameters.AddWithValue("@LastName", user.LastName );
            cmd.Parameters.AddWithValue("@Jmbg", user.JMBG);
            cmd.Parameters.AddWithValue("@Gender", user.Gender.ToString() );
            cmd.Parameters.AddWithValue("@UserType", user.UserType.ToString() );
            cmd.Parameters.AddWithValue("@Address", user.Address.Id );
            cmd.Parameters.AddWithValue("@IsActive", user.IsActive.ToString());
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

        public void Update(User user)
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Usercina set email = @Email,Password=@Password,FirstName=@FirstName,LastName=@LastName,gender=@gender,usertype=@usertype,address=@address,isactive=@isactive);", con);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
           // cmd.Parameters.AddWithValue("@Jmbg", user.JMBG);
            cmd.Parameters.AddWithValue("@Gender", user.Gender.ToString());
            cmd.Parameters.AddWithValue("@UserType", user.UserType.ToString());
            cmd.Parameters.AddWithValue("@Address", user.Address.Id);
            cmd.Parameters.AddWithValue("@IsActive", user.IsActive.ToString());
            cmd.ExecuteNonQuery();
            con.Close();

        }

  
    }
}
