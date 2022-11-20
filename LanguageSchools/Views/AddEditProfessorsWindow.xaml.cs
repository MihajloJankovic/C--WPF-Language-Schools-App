using LanguageSchools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LanguageSchools.Repositories;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Data.Common;
using System.Data;

namespace LanguageSchools.Views
{
    /// <summary>
    /// Interaction logic for AddEditProfessorsWindow.xaml
    /// </summary>
    public partial class AddEditProfessorsWindow : Window
    {
        private User newUser;
        private int g;
        public AddEditProfessorsWindow(User usercina)
        {
            passwordx.Visibility = Visibility.Hidden;
            emailx.Visibility = Visibility.Hidden;
            lastnamex.Visibility = Visibility.Hidden;
            firstnamex.Visibility = Visibility.Hidden;
            Street__.Visibility = Visibility.Hidden;
            Number_.Visibility = Visibility.Hidden;
            Country.Visibility = Visibility.Hidden;
            City.Visibility = Visibility.Hidden;
            //next.Visibility = Visibility.Hidden;
            InitializeComponent();
            g = 0;
            cbGender.ItemsSource = Enum.GetValues(typeof(EGender)).Cast<EGender>();

            newUser = usercina as User;
            txtEmail.Text = usercina.Email;
            txtFirstName.Text = usercina.FirstName;
            txtJMBG.Text = usercina.JMBG;
            txtLastName.Text = usercina.LastName;
            txtPassword.Text = usercina.Password;
            cbGender.SelectedItem = usercina.Gender;
            DataContext = newUser;
        }
        public AddEditProfessorsWindow()
        {
            InitializeComponent();
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
            newUser = new User
            {
                UserType = EUserType.PROFESSOR
            };
           
            DataContext = newUser;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(g==1)
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
                User korisnik = new User(txtEmail.Text, txtFirstName.Text, txtJMBG.Text, txtLastName.Text, txtPassword.Text);
                korisnik.Address.Street = emailx.Text;
                korisnik.Address.StreetNumber = passwordx.Text;
                korisnik.Address.Country = firstnamex.Text;
                korisnik.Address.City = lastnamex.Text;
                SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT max(id) FROM Address;", con);
                SqlDataReader reader = cmd.ExecuteReader();

                
                while (reader.Read())
                {
                    korisnik.Address.Id = reader.GetInt32(0);
                }

                // Call Close when done reading.
                reader.Close();
                Data.Instance.UserService.Add(korisnik);
            }
       
      
            DialogResult = true;
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txtEmail.Text.Length > 3)
            {
                if (txtPassword.Text.Length > 3)
                {
                    if (txtFirstName.Text.Length > 3)
                    {
                        if (txtLastName.Text.Length > 3)
                        {
                            if (txtJMBG.Text.Length > 3)
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
    }
}
