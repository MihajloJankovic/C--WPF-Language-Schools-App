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
        public void Delete(string pera)
        {
            Data.Instance.meetingRepository.DeleteForStudent(pera);
            Data.Instance.UserService.Delete(pera);
        }
        public List<User> GetAllStudents()
        {
            List<User> list = new List<User>();
            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from usercina where usertype = 'STUDENT' and IsActive='true';", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {    //Every new row will create a new dictionary that holds the columns

                User user = new User();
                user.Email = reader["email"].ToString();
                user.Password = reader["Password"].ToString();
                user.FirstName = reader["FirstName"].ToString();
                user.LastName = reader["LastName"].ToString();
                user.JMBG = reader["Jmbg"].ToString();
                user.Gender = Enum.Parse<EGender>(reader["Gender"].ToString());
                user.UserType = Enum.Parse<EUserType>(reader["UserType"].ToString());
                int adres = Convert.ToInt32(reader["Address"].ToString());



                SqlConnection con1 = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("select * from Address where id = " + adres.ToString() + ";", con1);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                while (reader1.Read())
                {
                    user.Address = new Address();
                    user.Address.Id = adres;
                    user.Address.Street = reader1["street"].ToString();
                    user.Address.StreetNumber = reader1["number"].ToString();
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

        public List<StudentV> getViewModel(List<User> skl)
        {

            List<StudentV> schoolVS = new List<StudentV>();

            foreach (User sc in skl)
            {
                StudentV peraa = new StudentV();
                peraa.FirstName = sc.FirstName;
                peraa.LastName = sc.LastName;
                peraa.Password = sc.Password;
                peraa.Email = sc.Email;
                peraa.Gender = sc.Gender;

                peraa.JMBG = sc.JMBG;
                
                peraa.Address = sc.Address.Street +" "+ sc.Address.StreetNumber + " " + sc.Address.City + " " + sc.Address.Country+" ";


                schoolVS.Add(peraa);
            }



            return schoolVS;
        }
        public Student GetById(String id)
        {
          
               SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
               con.Open();
               SqlCommand cmd = new SqlCommand("select * from usercina where usertype = 'STUDENT' and IsActive='true' and userid = " + id.ToString()+";", con);
               SqlDataReader reader = cmd.ExecuteReader();
            Student student = new Student();
            while (reader.Read())
            {    //Every new row will create a new dictionary that holds the columns

                User user = new User();
                user.Email = reader["email"].ToString();
                user.Password = reader["Password"].ToString();
                user.FirstName = reader["FirstName"].ToString();
                user.LastName = reader["LastName"].ToString();
                user.JMBG = reader["Jmbg"].ToString();
                user.Gender = Enum.Parse<EGender>(reader["Gender"].ToString());
                user.UserType = Enum.Parse<EUserType>(reader["UserType"].ToString());
                int adres = Convert.ToInt32(reader["Address"].ToString());



                SqlConnection con1 = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("select * from Address where id = " + adres.ToString() + ";", con1);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                while (reader1.Read())
                {
                    user.Address = new Address();
                    user.Address.Id = adres;
                    user.Address.Street = reader1["street"].ToString();
                    user.Address.StreetNumber = reader1["number"].ToString();
                    user.Address.City = reader1["city"].ToString();
                    user.Address.Country = reader1["country"].ToString();
                    student.User= user;
                    return student;
                }
                reader1.Close();
                con1.Close();
            }
            reader.Close();
            con.Close();

            return student;
        }
    }
}
