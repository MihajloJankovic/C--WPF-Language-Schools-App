using LanguageSchools.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace LanguageSchools.Repositories

{
    
    class SchoolRepository : ISchoolRepository
    {
        public AddressRepository repostoryadres;
        public LanguageRepository repostorylang;
        public SchoolRepository()
        {
            repostoryadres = new AddressRepository();
            repostorylang = new LanguageRepository();
        }
        public void Add(School school)
        {


        }
        public void AddProfessorSchool(String school,String professor)
        {
            
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO ProfessorSchool VALUES (@Schid,@Profid);", con);
            cmd.Parameters.AddWithValue("@Schid", school);
            cmd.Parameters.AddWithValue("@Profid",professor);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void Update(Professor pera)
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM ProfessorSchool WHERE Profid = " + pera.UserId + ";", con);
            //cmd.Parameters.AddWithValue("@Professor",id.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            AddProfessorSchool(pera.SchoolT.Id.ToString(), pera.UserId);

        }
        public List<School> GetAll()
        {
            List<School> schools = new List<School>();


            SqlConnection con2 = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con2.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM School;", con2);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                School school = new School();
                school.Languages = new List<Language>();
                school.Id= Convert.ToInt32(reader2["id"].ToString());
                school.Name= reader2["Name"].ToString();
                int addressid = Convert.ToInt32(reader2["Address"].ToString());
                school.Address = new Address();
                school.Address = repostoryadres.GetById(addressid);
                school.Languages.AddRange(repostorylang.GetBySchool(school.Id));
                schools.Add(school);
            }

            con2.Close();
            reader2.Close();






            return schools;
        }


        public School GetById(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from School;", con);
            SqlDataReader reader = cmd.ExecuteReader();
            School school = new School();
            Address address = new Address();
            school.Address = address;
            while (reader.Read())
            {   
                
                //      user.Address.City = reader["city"].ToString();
                school.Id = id;
                school.Name = reader["Name"].ToString();
                school.Address.Id = Convert.ToInt32(reader["Address"].ToString());
                SqlConnection con2 = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM Address where id = "+ school.Address.Id.ToString()+";", con2);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    school.Address.Street = reader2["street"].ToString();
                    school.Address.StreetNumber = reader2["number"].ToString();
                    school.Address.City = reader2["city"].ToString();
                    school.Address.Country = reader2["country"].ToString();
                }
               
                con2.Close();
                reader2.Close();
                
            }
         

            reader.Close();
            con.Close();
            return school;
        }
        public School GetByProfessor(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from School where usertype = 'PROFESSOR';", con);
            SqlDataReader reader = cmd.ExecuteReader();
            School school = new School();
            while (reader.Read())
            {

                //      user.Address.City = reader["city"].ToString();
                school.Id = id;
                school.Name = reader["Name"].ToString();
                school.Address.Id = Convert.ToInt32(reader["Address"].ToString());
                SqlConnection con2 = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM Address where id = " + school.Address.Id.ToString() + ";", con2);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                school.Address.Street = reader2["street"].ToString();
                school.Address.StreetNumber = reader2["number"].ToString();
                school.Address.City = reader2["city"].ToString();
                school.Address.Country = reader2["country"].ToString();
                con2.Close();
                reader2.Close();

            }


            reader.Close();
            con.Close();
            return school;
        }
    }
}
