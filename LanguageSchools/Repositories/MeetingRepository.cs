using LanguageSchools.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchools.Repositories
{
     class MeetingRepository
    {
      

        public MeetingRepository()
        {

          

           
        }
        public List<Meeting> getByProfessor(int id)
        {

            List<User> list = new List<User>();
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Meeting where Professor = "+id+";", con);
            SqlDataReader reader = cmd.ExecuteReader();

            List <Meeting> meetings = new List<Meeting>();
            while (reader.Read())
            {    
                Meeting meeting = new Meeting();
                

            }
            reader.Close();
            con.Close();
            return meetings;
        }
    }
}
