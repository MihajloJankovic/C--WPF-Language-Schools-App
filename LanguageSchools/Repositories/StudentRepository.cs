using LanguageSchools.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchools.Repositories
{
    internal class StudentRepository : IStudentRepository
    {
        public void AddToStudent(Student professor)
        {
            foreach (Meeting jez in professor.MeetingList)
            {

                SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO StudentMeeting VALUES (@Student,@Meeting);", con);
                cmd.Parameters.AddWithValue("@Professor", Convert.ToInt32(professor.User.JMBG));
                cmd.Parameters.AddWithValue("@Meeting", jez.Id);
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        //public Student GetById(int id)
        //{
        //   
        //        SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("select * from Student where userid = "+id.ToString()+";", con);
        //        Student pera = new Student();
        //        
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    

        //}
    }
}
