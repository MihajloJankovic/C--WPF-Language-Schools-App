using LanguageSchools.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

    }
}
