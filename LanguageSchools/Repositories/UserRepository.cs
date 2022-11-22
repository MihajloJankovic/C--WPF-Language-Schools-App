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
using System.Data.Common;

namespace LanguageSchools.Repositories
{
    class UserRepository : IUserRepository
    {
        public AddressRepository repostoryadres;

        public UserRepository()
        {
            repostoryadres = new AddressRepository();
        }
        public void Add(User user)
        {
            repostoryadres.Add(user.Address);
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

        public void Delete(string email)
        {
        
        }

        public List<User> GetAll()
        {
            List<User> list = new List<User>();
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from usercina where usertype = 'PROFESSOR';", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {    //Every new row will create a new dictionary that holds the columns
               
                User user = new User(); 
                user.Email=reader["email"].ToString();
                user.Password = reader["Password"].ToString();
                user.FirstName = reader["FirstName"].ToString();
                user.LastName = reader["LastName"].ToString();
                user.JMBG= reader["Jmbg"].ToString();
                user.Gender = Enum.Parse<EGender>(reader["Gender"].ToString());
                user.UserType = Enum.Parse<EUserType>(reader["UserType"].ToString());
                int adres =Convert.ToInt32(reader["Address"].ToString());
                


                SqlConnection con1 = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("select * from Address where id = "+adres.ToString()+";", con1);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                while (reader1.Read())
                {
                    user.Address = new Address();
                    user.Address.Id = adres;
                    user.Address.Street = reader1["street"].ToString();
                    user.Address.StreetNumber= reader1["number"].ToString();
                    user.Address.City = reader1["city"].ToString();
                    user.Address.Country = reader1["country"].ToString();
                    list.Add(user);
                }
                reader1.Close();
                con1.Close();
            }
            reader.Close();
            con.Close();

            return list;
        }

        //public User GetById(string jmbg)
        //{
            
       // }

        public void Update(User user)
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Usercina set email = @Email,Password=@Password,FirstName=@FirstName,LastName=@LastName,gender=@gender,usertype=@usertype,address=@address,isactive=@isactive;", con);
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
            SqlConnection con1 = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("update Address set street = @Street,number=@Number,city=@City,country=@Country;", con1);
            cmd1.Parameters.AddWithValue("Street", user.Address.Street);
            cmd1.Parameters.AddWithValue("@Number", user.Address.StreetNumber);
            cmd1.Parameters.AddWithValue("@City", user.Address.City);
            cmd1.Parameters.AddWithValue("Country", user.Address.Country);
            cmd1.ExecuteNonQuery();
            con1.Close();

        }

  
    }
}
