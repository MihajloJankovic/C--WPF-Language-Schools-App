using LanguageSchools.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LanguageSchools.Views
{
    /// <summary>
    /// Interaction logic for AddEditStudent.xaml
    /// </summary>
    public partial class AddEditStudent : Window
    {
        int g = 0;
        public Student st;
        public AddEditStudent()
        {
            InitializeComponent();
            cbGender.ItemsSource = Enum.GetValues(typeof(EGender));
            passwordx.Visibility = Visibility.Hidden;
            emailx.Visibility = Visibility.Hidden;
            lastnamex.Visibility = Visibility.Hidden;
            firstnamex.Visibility = Visibility.Hidden;
            Street__.Visibility = Visibility.Hidden;
            Number_.Visibility = Visibility.Hidden;
            Country.Visibility = Visibility.Hidden;
            City.Visibility = Visibility.Hidden;
            //next.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Hidden;
          
            

            g = 1;

        }
        public AddEditStudent(StudentV peraa)
        {
            InitializeComponent();
            cbGender.ItemsSource = Enum.GetValues(typeof(EGender));
            passwordx.Visibility = Visibility.Hidden;
            emailx.Visibility = Visibility.Hidden;
            lastnamex.Visibility = Visibility.Hidden;
            firstnamex.Visibility = Visibility.Hidden;
            Street__.Visibility = Visibility.Hidden;
            Number_.Visibility = Visibility.Hidden;
            Country.Visibility = Visibility.Hidden;
            City.Visibility = Visibility.Hidden;
            //next.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Hidden;
          

            g = 0;

            String ID = peraa.JMBG;
            Student student = new Student();
            student.User = new User();
            student.User = Data.Instance.UserService.GetById(ID);
            student.MeetingList = new List<Meeting>();
            student.MeetingList = Data.Instance.meetingRepository.getByStudent(ID);
             User usercina = new User();
            usercina = student.User;
            st = student;
            
           
            txtEmail.Text = usercina.Email;
            txtFirstName.Text = usercina.FirstName;
            txtJMBG.Text = usercina.JMBG;
            txtJMBG.IsReadOnly = true;
            txtLastName.Text = usercina.LastName;
            txtPassword.Text = usercina.Password;
            cbGender.SelectedItem = usercina.Gender;
            emailx.Text = usercina.Address.Street;
            passwordx.Text = usercina.Address.StreetNumber;
            firstnamex.Text = usercina.Address.Country;
            lastnamex.Text = usercina.Address.City;

           
            cbGender.SelectedItem = usercina.Gender.ToString();
            
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text.Length > 5)
            {
                if (txtPassword.Text.Length > 5)
                {
                    if (txtFirstName.Text.Length > 3)
                    {
                        if (txtLastName.Text.Length > 3)
                        {
                            if (txtJMBG.Text.Length > 10)
                            {
                                passwordx.Visibility = Visibility.Visible;
                                emailx.Visibility = Visibility.Visible;
                                lastnamex.Visibility = Visibility.Visible;
                                firstnamex.Visibility = Visibility.Visible;
                                Street__.Visibility = Visibility.Visible;
                                Number_.Visibility = Visibility.Visible;
                                Country.Visibility = Visibility.Visible;
                                City.Visibility = Visibility.Visible;
                                next.Visibility = Visibility.Hidden;
                                btnSave.Visibility = Visibility.Visible;
                              

                                lblEmail.Visibility = Visibility.Hidden;
                                lblFirstName.Visibility = Visibility.Hidden;
                                lblGender.Visibility = Visibility.Hidden;
                                lblJMBG.Visibility = Visibility.Hidden;
                                lblLastName.Visibility = Visibility.Hidden;
                                lblPassword.Visibility = Visibility.Hidden;
                                txtEmail.Visibility = Visibility.Hidden;
                                txtFirstName.Visibility = Visibility.Hidden;
                                txtJMBG.Visibility = Visibility.Hidden;
                                txtLastName.Visibility = Visibility.Hidden;
                                txtPassword.Visibility = Visibility.Hidden;
                                cbGender.Visibility = Visibility.Hidden;
                                List<School> skola = new List<School>();

                               
                            }
                            else
                            {
                                MessageBox.Show("JMBG too Short!");
                            }

                        }
                        else
                        {
                            MessageBox.Show("LastName too short!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Name to short!");
                    }
                }
                else
                {
                    MessageBox.Show("Password too short!");
                }
            }
            else
            {
                MessageBox.Show("Email too short!");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (g == 1)
            {
               
                    //  newUser.Email = txtEmail.Text;
                    //  newUser.FirstName = txtFirstName.Text;
                    //  newUser.JMBG = txtJMBG.Text;
                    //  newUser.LastName = txtLastName.Text;
                    //  newUser.Password = txtPassword.Text;
                    //  newUser.Address.Id = 1100;
                    //  newUser.Address.Street = "ulica";
                    //  newUser.Address.StreetNumber = "5";
                    //  newUser.Address.City = "beska";
                    //  newUser.Address.Country = "srbija";
                    //
                    User korisnik = new User();
                    korisnik.Email = txtEmail.Text;
                    korisnik.Password = txtPassword.Text;
                    korisnik.LastName = txtLastName.Text;
                    korisnik.FirstName = txtFirstName.Text;
                    korisnik.Address = new Address();
                    korisnik.JMBG = txtJMBG.Text;
                    korisnik.Address.Street = emailx.Text;
                    korisnik.Address.StreetNumber = passwordx.Text;
                    korisnik.Address.Country = firstnamex.Text;
                    korisnik.Address.City = lastnamex.Text;
                    korisnik.Gender = Enum.Parse<EGender>(cbGender.SelectedItem.ToString());
                    korisnik.UserType = EUserType.STUDENT;




                    if (emailx.Text.Length > 3)
                    {
                        if (passwordx.Text.Length >= 1)
                        {
                            if (firstnamex.Text.Length > 3)
                            {
                                if (lastnamex.Text.Length > 3)
                                {
                                  

                                        SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
                                        con.Open();
                                        SqlCommand cmd = new SqlCommand("SELECT max(id) FROM Address;", con);
                                        SqlDataReader reader = cmd.ExecuteReader();


                                        while (reader.Read())
                                        {
                                            korisnik.Address.Id = (reader.GetInt32(0)) + 1;
                                        }

                                        // Call Close when done reading.
                                        reader.Close();
                                        Data.Instance.UserService.Add(korisnik);
                                        

                                        
                                      
                                        

                                        DialogResult = true;
                                        Close();
                                   
                                }
                                else
                                {
                                    MessageBox.Show("City name too short");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Contry name too short");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter street number");
                        }
                    }
                    else
                    {
                        MessageBox.Show("street name too short");
                    }
                
            }
            if (g == 0)
            {

               
               

                    if (emailx.Text.Length > 3)
                    {
                        if (passwordx.Text.Length >= 1)
                        {
                            if (firstnamex.Text.Length > 3)
                            {
                                if (lastnamex.Text.Length > 3)
                                {
                                   
                                       
                                        User korisnik = new User();
                                        korisnik.Email = txtEmail.Text;
                                        korisnik.Password = txtPassword.Text;
                                        korisnik.LastName = txtLastName.Text;
                                        korisnik.FirstName = txtFirstName.Text;
                                        korisnik.Address = new Address();
                                        korisnik.Address.Street = emailx.Text;
                                        korisnik.Address.StreetNumber = passwordx.Text;
                                        korisnik.Address.Country = firstnamex.Text;
                                        korisnik.Address.City = lastnamex.Text;
                                        korisnik.Gender = Enum.Parse<EGender>(cbGender.SelectedItem.ToString());
                                        korisnik.JMBG = st.User.JMBG;
                                        korisnik.Address.Id = st.User.Address.Id;
                                        korisnik.IsActive = true;
                                        korisnik.UserType = EUserType.STUDENT;
                                        Data.Instance.UserService.Update(korisnik);
                                        st.User = korisnik;
                                        DialogResult = true;
                                        Close();
                                    
                                   
                                }
                                else
                                {
                                    MessageBox.Show("City name too short");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Contry name too short");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter street number");
                        }
                    }
                    else
                    {
                        MessageBox.Show("street name too short");
                    }

                


            }


        }

        private void canc_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
