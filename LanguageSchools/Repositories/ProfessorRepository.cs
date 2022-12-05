using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using LanguageSchools.Models;
using LanguageSchools.Repositories;

namespace LanguageSchools.Repositories
{
    class ProfessorRepository : IProfessorRepository
    {
        public SchoolRepository repostorySchool;
        public MeetingRepository repostorymeet;
        public LanguageRepository repostorylang;
        public UserRepository repostory;
        public AddressRepository repostoryadres;

        public ProfessorRepository()
        {

            repostory = new UserRepository();
            repostorySchool = new SchoolRepository();
            repostorylang = new LanguageRepository();
            repostorymeet = new MeetingRepository();
            repostoryadres = new AddressRepository();
        }

        public List<ProfessorV> getViewModel(List<Professor> users)
        {

            List<ProfessorV> professorVS = new List<ProfessorV>();
          
                foreach (Professor professor in users)
                {
                    ProfessorV peraa = new ProfessorV();
                    peraa.Professor = professor.UserId;
                    peraa.school_name = professor.SchoolT.Name;
                    foreach (Language language in professor.Languages)
                    {
                        peraa.Languages = peraa.Languages + language.Jezik + " ,";
                    }
                    peraa.Name = 
                    peraa.Name = professor.User.FirstName.ToString() + " " + professor.User.LastName.ToString();

                    professorVS.Add(peraa);
                }

            
            
            return professorVS;
        }
        public void Add(Professor professor)
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Professore VALUES (@Userid,@Professorid,@schid);", con);



            SqlConnection con1 = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("select max(Professorid) from Professore;", con1);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            int ajd = 0;
            while (reader1.Read())
            {
                if (reader1.IsDBNull(0))
                {
                    ajd = 1;
                }
                else
                {
                    ajd = Convert.ToInt32(reader1.GetString(0)) + 1;
                }
               

            }
            reader1.Close();
            con1.Close();


            professor.UserId = ajd.ToString();
            repostorylang.AddToProfessor(professor);
            repostorySchool.AddProfessorSchool(professor.SchoolT.Id.ToString(), ajd.ToString());


            cmd.Parameters.AddWithValue("@Userid",professor.User.JMBG);
            cmd.Parameters.AddWithValue("@Professorid", ajd);
            cmd.Parameters.AddWithValue("@schid", professor.SchoolT.Id.ToString());
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void Delete(string email)
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Professore WHERE Professorid = " + email + ";", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
      

        public List<Professor> GetAll()
        {
            List<User> list = new List<User>();
           list =  repostory.GetAll();
            foreach(User user in list)
            {
                if(user.UserType != EUserType.PROFESSOR)
                {
                    list.Remove(user);
                }
            }
            List<Professor> lista = new List<Professor>();
            



            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Professore;", con);
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                Professor professor = new Professor();
                String id = reader["Userid"].ToString();
                if (id == null)
                {
                    continue;
                }
                User usert = list.Find(e => e.JMBG == id.ToString());
                professor.User = usert;
                professor.UserId = reader["Professorid"].ToString();
                int profid = Convert.ToInt32(professor.UserId);
                List<Language> pp = new List<Language>();
                List<Meeting> bb = new List<Meeting>();
                professor.Languages =pp;
                professor.Meetings = bb;
                professor.Languages.AddRange(repostorylang.GetByProfessor(profid));
                professor.Meetings.AddRange(repostorymeet.getByProfessor(profid));
                int schid = Convert.ToInt32(reader["schid"].ToString());
                professor.SchoolT = repostorySchool.GetById(schid);
                lista.Add(professor);

            }
            reader.Close();
            con.Close();
            return lista;


        }

        public Professor GetById(String idd)
        {
            
            List<User> list = new List<User>();
            list = repostory.GetAll();
            foreach (User user in list)
            {
                if (user.UserType != EUserType.PROFESSOR)
                {
                    list.Remove(user);
                }
            }
            




            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Professore where Professorid = "+idd+";", con);
            SqlDataReader reader = cmd.ExecuteReader();
            Professor professor = new Professor();
            while (reader.Read())
            {
               
                String id = reader["Userid"].ToString();
                User usert = list.Find(e => e.JMBG == id.ToString());
                professor.User = usert;
                professor.UserId = reader["Professorid"].ToString();
                int profid = Convert.ToInt32(professor.UserId);
                List<Language> pp = new List<Language>();
                List<Meeting> bb = new List<Meeting>();
                professor.Languages = pp;
                professor.Meetings = bb;
                professor.Languages.AddRange(repostorylang.GetByProfessor(profid));
                professor.Meetings.AddRange(repostorymeet.getByProfessor(profid));
                int schid = Convert.ToInt32(reader["schid"].ToString());
                professor.SchoolT = repostorySchool.GetById(schid);
               

            }
            reader.Close();
            con.Close();




            return professor;
        }

        public void Update(Professor pera)
        {

            repostory.Update(pera.User);
            repostorymeet.Update(pera);
            repostorylang.Update(pera);
            repostorySchool.Update(pera);

        }



    }
}
