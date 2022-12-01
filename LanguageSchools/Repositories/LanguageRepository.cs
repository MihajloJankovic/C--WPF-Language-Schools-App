using LanguageSchools.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Documents;

namespace LanguageSchools.Repositories
{
    class LanguageRepository
    {
        public void Add()
        {

        }
        public void AddToProfessor(Professor professor)
        {
            foreach(Language jez in professor.Languages)
            {

                SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO LanguageProfessore VALUES (@Professor,@Language);", con);
                cmd.Parameters.AddWithValue("@Professor", professor.UserId);
                cmd.Parameters.AddWithValue("@Language",jez.Jezik );
                cmd.ExecuteNonQuery();
                con.Close();
            }
            
        }
        public void AddToSchool(School school)
        {
            foreach (Language jez in school.Languages)
            {

                SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO SchoolLanguage VALUES (@Professor,@Language);", con);
                cmd.Parameters.AddWithValue("@Professor", school.Id);
                cmd.Parameters.AddWithValue("@Language", jez.Jezik);
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        public void UpdateToSchool(School school)
        {

            foreach (Language jez in school.Languages)
            {
                SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM SchoolLanguage WHERE School = " + school.Id.ToString() + ";", con);
                //cmd.Parameters.AddWithValue("@Professor",id.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
                

               AddToSchool(school);
            }

        }
        public List<Language> GetBySchool(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Language from SchoolLanguage where School = "+id.ToString()+";", con);
            //cmd.Parameters.AddWithValue("@Professor",id.ToString());
            SqlDataReader reader = cmd.ExecuteReader();

            List<Language> languages = new List<Language>();
            while (reader.Read())
            {
                Language language = new Language();
                language.Jezik = reader["Language"].ToString();
                languages.Add(language);
            }
            reader.Close();
            con.Close();


            return languages;
        }
        public List<Language> GetAll()
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Language;", con);
            //cmd.Parameters.AddWithValue("@Professor",id.ToString());
            SqlDataReader reader = cmd.ExecuteReader();

            List<Language> languages = new List<Language>();
            while (reader.Read())
            {
                Language language = new Language();
                language.Jezik = reader["Language"].ToString();
                languages.Add(language);
            }
            reader.Close();
            con.Close();

            return languages;

        }
        public List<Language> GetByProfessor(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Language from LanguageProfessore where Professor = "+id.ToString()+";", con);
            //cmd.Parameters.AddWithValue("@Professor",id.ToString());
            SqlDataReader reader = cmd.ExecuteReader();

            List <Language> languages = new List<Language>();
            while (reader.Read())
            {  
                Language language = new Language();
                language.Jezik=reader["Language"].ToString();
                languages.Add(language);
            }
            reader.Close();
            con.Close();


            return languages;

        }
        public void Update(Professor pera)
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM LanguageProfessore WHERE Professor = "+pera.UserId +";", con);
            //cmd.Parameters.AddWithValue("@Professor",id.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            AddToProfessor(pera);
        }

    }
}
