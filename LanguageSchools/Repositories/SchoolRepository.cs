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
        public void Delete(String id)
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM School WHERE id = " + id + ";", con);
            //cmd.Parameters.AddWithValue("@Professor",id.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Add(School school)
        {
            repostoryadres.Add(school.Address);
            
            SqlConnection con1 = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT max(id) FROM Address;", con1);
            SqlDataReader reader1 = cmd1.ExecuteReader();


            while (reader1.Read())
            {
                school.Address.Id = (reader1.GetInt32(0));
            }

            // Call Close when done reading.
            reader1.Close();
            con1.Close();
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO School VALUES (@Name,@Address,@deleted);", con);
            cmd.Parameters.AddWithValue("@Name", school.Name);
            cmd.Parameters.AddWithValue("@Address", school.Address.Id);
            cmd.Parameters.AddWithValue("@deleted", school.IsDeleted.ToString());
            cmd.ExecuteNonQuery();
            con.Close();

            SqlConnection con3 = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con3.Open();
            SqlCommand cmd3 = new SqlCommand("SELECT max(id) FROM School;", con3);
            SqlDataReader reader3 = cmd3.ExecuteReader();


            while (reader3.Read())
            {
                school.Id = (reader3.GetInt32(0)) ;
            }


            reader3.Close();
            con3.Close();
            repostorylang.UpdateToSchool(school);


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
        public void UpdateSchool(School pera)
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update School set Name = @Email where id = " + pera.Id.ToString() + ";", con);
            cmd.Parameters.AddWithValue("@Email", pera.Name);
           
            cmd.ExecuteNonQuery();
            SqlConnection con1 = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("update Address set street = @Street,number=@Number,city=@City,country=@Country where id = " + pera.Address.Id.ToString() + ";", con1);
            cmd1.Parameters.AddWithValue("Street", pera.Address.Street);
            cmd1.Parameters.AddWithValue("@Number", pera.Address.StreetNumber);
            cmd1.Parameters.AddWithValue("@City", pera.Address.City);
            cmd1.Parameters.AddWithValue("Country", pera.Address.Country);
            cmd1.ExecuteNonQuery();
            con1.Close();
            repostorylang.UpdateToSchool(pera);
        }
        public List<SchoolV> getViewModel(List<School> skl)
        {

            List<SchoolV> schoolVS = new List<SchoolV>();

            foreach (School sc in skl)
            {
                SchoolV peraa = new SchoolV();
                peraa.School = Convert.ToString(sc.Id);
                peraa.Name = sc.Name;
                peraa.Address = sc.Address.Street + " " + sc.Address.StreetNumber + " " + sc.Address.City + " " + sc.Address.Country;
                peraa.Languages = "";
                foreach (Language language in sc.Languages)
                {
                    
                    peraa.Languages = peraa.Languages + language.Jezik + " ,";
                }
                

                schoolVS.Add(peraa);
            }



            return schoolVS;
        }
        public List<School> GetAll()
        {
            List<School> schools = new List<School>();


            SqlConnection con2 = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con2.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM School where deleted = 'false';", con2);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                School school = new School();
                school.Languages = new List<Language>();
                school.Id= Convert.ToInt32(reader2["id"].ToString());
                school.Name= reader2["Name"].ToString();
                int addressid = Convert.ToInt32(reader2["Address"].ToString());
                bool ss = Convert.ToBoolean(reader2["deleted"].ToString());
                school.Address = new Address();
                school.IsDeleted = ss;
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
            SqlCommand cmd = new SqlCommand("select * from School where deleted = 'false';", con);
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
                school.Languages = Data.Instance.languageRepository.GetBySchool(id);
                
            }
         

            reader.Close();
            con.Close();
            return school;
        }
        public School GetByProfessor(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from School where usertype = 'PROFESSOR' and deleted = 'false';", con);
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
