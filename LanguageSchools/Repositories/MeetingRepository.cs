using LanguageSchools.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace LanguageSchools.Repositories
{
     class MeetingRepository
    {
      

        public MeetingRepository()
        {

          

           
        }
        public bool jmbg(String jm)
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Count(Jmbg) from usercina where Jmbg = '" + jm + "';", con);
            SqlDataReader reader = cmd.ExecuteReader();
            bool da = false;
            int daA = 0;
            while (reader.Read()) 
            {
                  daA = Convert.ToInt32(reader[0]);

            }
            reader.Close();
            con.Close();
            if(daA > 0 ) 
            {
                return true;
            }
            return false;
        }
        public Meeting GetMeeting(int id)
        {

            List<User> list = new List<User>();
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Meeting where id = " + id + ";", con);
            SqlDataReader reader = cmd.ExecuteReader();

            Meeting meeting = new Meeting();
            while (reader.Read())
            {
                meeting.Id = Convert.ToInt32(reader["id"]);
                meeting.Professor = Data.Instance.ProfessorService.GetById(reader["Professor"].ToString());
                meeting.From = Convert.ToDateTime(reader["From"]);
                meeting.To = Convert.ToDateTime(reader["To"]);
                meeting.Status = Convert.ToBoolean(reader["Status"]);
                Student st = new Student();
                st.User = Data.Instance.UserService.GetById(reader["Student"].ToString());
                st.MeetingList = new List<Meeting>();
                meeting.Student = st;
            

            }
            reader.Close();
            con.Close();
            return meeting;
        }
        public void Add(Meeting meeting) 
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Meeting VALUES (@Professor,@From,@To,@Student,@Status);", con);
            cmd.Parameters.AddWithValue("@Professor",meeting.Professor.UserId.ToString());
            cmd.Parameters.AddWithValue("@From", meeting.From.ToString());
            cmd.Parameters.AddWithValue("@To", meeting.To.ToString());
            cmd.Parameters.AddWithValue("@Student", meeting.Student.User.JMBG.ToString());
            cmd.Parameters.AddWithValue("@Status", meeting.Status.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteForStudent(string email)
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Meeting WHERE Student = " + email + ";", con);
            //cmd.Parameters.AddWithValue("@Professor",id.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void AddToProfessor(Professor professor)
        {
            foreach (Meeting jez in professor.Meetings)
            {

                SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO ProfessorMeeting VALUES (@Professor,@Meeting);", con);
                cmd.Parameters.AddWithValue("@Professor", Convert.ToInt32(professor.UserId));
                cmd.Parameters.AddWithValue("@Meeting",jez.Id.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        
        public List<Meeting> getByProfessor(int id,Professor pera)
        {

            List<User> list = new List<User>();
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Meeting where Professor = '"+id.ToString()+"'"+"and Status = 'True'"+";", con);
            SqlDataReader reader = cmd.ExecuteReader();

            List <Meeting> meetings = new List<Meeting>();
            while (reader.Read())
            {    
                Meeting meeting = new Meeting();
                meeting.Id =Convert.ToInt32(reader["id"]);
                meeting.Professor = pera;
                meeting.From = Convert.ToDateTime(reader["From"]);
                meeting.To= Convert.ToDateTime(reader["To"]);
                meeting.Status = Convert.ToBoolean(reader["Status"]);
                Student st = new Student();
                st.User = Data.Instance.UserService.GetById(reader["Student"].ToString());
                st.MeetingList = new List<Meeting>();
                meeting.Student = st;
                meetings.Add(meeting);

            }
            reader.Close();
            con.Close();
            return meetings;
        }
        public void AddToStudent(Student professor)
        {
            foreach (Meeting jez in professor.MeetingList)
            {

                SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO StudentMeeting VALUES (@Professor,@Meeting);", con);
                cmd.Parameters.AddWithValue("@Professor", Convert.ToInt32(professor.User.JMBG));
                cmd.Parameters.AddWithValue("@Meeting", Convert.ToInt32(jez.Id));
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public List<Meeting> getByStudent(String id)
        {

            List<User> list = new List<User>();
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Meeting where Student = '" + id + "'"+ "and Status = 'true'" + ";", con);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Meeting> meetings = new List<Meeting>();
            while (reader.Read())
            {
                Meeting meeting = new Meeting();
                meeting.Id = Convert.ToInt32(reader["id"]);
                meeting.Professor = Data.Instance.ProfessorService.GetById(reader["Professor"].ToString());
                meeting.From = Convert.ToDateTime(reader["From"]);
                meeting.To = Convert.ToDateTime(reader["To"]);
                meeting.Status = Convert.ToBoolean(reader["Status"]);
                Student st = new Student();
                st.User = Data.Instance.UserService.GetById(reader["Student"].ToString());
                st.MeetingList = new List<Meeting>();
                meeting.Student = st;
                meetings.Add(meeting);

            }
            reader.Close();
            con.Close();
            return meetings;
        }
        public void UpdateStudent(Student pera)
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();






            SqlCommand cmd = new SqlCommand("DELETE FROM Meeting WHERE Student = " + pera.User.JMBG + ";", con);
            //cmd.Parameters.AddWithValue("@Professor",id.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            AddToStudent(pera);
        }
        public void Update(Professor pera)
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();




           

            SqlCommand cmd = new SqlCommand("DELETE FROM Meeting WHERE Professor = "+pera.UserId+";", con);
            //cmd.Parameters.AddWithValue("@Professor",id.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
           
        }
        public void UpdateMeet(int pera)
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();





            SqlCommand cmd = new SqlCommand("update Meeting set Status=@Street where id = " + pera + "; ", con);
            cmd.Parameters.AddWithValue("Street", "false");
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
