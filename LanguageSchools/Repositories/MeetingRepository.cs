﻿using LanguageSchools.Models;
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
        
        public List<Meeting> getByProfessor(int id)
        {

            List<User> list = new List<User>();
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Meeting where Professor = "+id.ToString()+";", con);
            SqlDataReader reader = cmd.ExecuteReader();

            List <Meeting> meetings = new List<Meeting>();
            while (reader.Read())
            {    
                Meeting meeting = new Meeting();
                meeting.Id =Convert.ToInt32(reader["id"]);
                meeting.Professor = Data.Instance.ProfessorService.GetById(reader["Professor"].ToString());
                meeting.From = Convert.ToDateTime(reader["[From]"]);
                meeting.To= Convert.ToDateTime(reader["[To]"]);
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

        public void Update(Professor pera)
        {
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();




           

            SqlCommand cmd = new SqlCommand("DELETE FROM Meeting WHERE Professor = "+pera.UserId+";", con);
            //cmd.Parameters.AddWithValue("@Professor",id.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            AddToProfessor(pera);
        }
    }
}
