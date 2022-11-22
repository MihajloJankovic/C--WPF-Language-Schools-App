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
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;


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
            cbGender.ItemsSource = Enum.GetValues(typeof(EGender));
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
            

            newUser = usercina as User;
            txtEmail.Text = usercina.Email;
            txtFirstName.Text = usercina.FirstName;
            txtJMBG.Text = usercina.JMBG;
            txtLastName.Text = usercina.LastName;
            txtPassword.Text = usercina.Password;
            cbGender.SelectedItem = usercina.Gender;
            emailx.Text = usercina.Address.Street;
            passwordx.Text = usercina.Address.StreetNumber;
            firstnamex.Text = usercina.Address.Country;
            lastnamex.Text = usercina.Address.City;
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
            cbSchool.Visibility = Visibility.Hidden;
            listbox1.Visibility = Visibility.Hidden;
            List<String> str = new List<String>();
            List<Language> jezici = new List<Language>();
            jezici.AddRange(Data.Instance.languageRepository.GetAll());
            foreach (Language lang in jezici)
            {
                str.Add(lang.Jezik);
            }
            listbox1.SelectionMode = SelectionMode.Multiple;
            listbox1.ItemsSource = str;


            g = 1;
            newUser = new User
            {
                UserType = EUserType.PROFESSOR
            };
           
            DataContext = newUser;
        }
        
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(g==1)
            {
                if(cbSchool.SelectedItem is null)
                {
                    MessageBox.Show("chose a school first");
                    
                }
                else
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
                    korisnik.JMBG = txtJMBG.Text;
                    korisnik.LastName = txtLastName.Text;
                    korisnik.FirstName = txtFirstName.Text;
                    korisnik.Address = new Address();
                    korisnik.Address.Street = emailx.Text;
                    korisnik.Address.StreetNumber = passwordx.Text;
                    korisnik.Address.Country = firstnamex.Text;
                    korisnik.Address.City = lastnamex.Text;
                    korisnik.Gender = EGender.FEMALE;
                    korisnik.UserType = EUserType.PROFESSOR;



                    if (emailx.Text.Length > 3)
                    {
                        if(passwordx.Text.Length >= 1)
                        {
                            if(firstnamex.Text.Length > 3)
                            {
                                if(lastnamex.Text.Length > 3)
                                {
                                    if(listbox1.SelectedItems.Count > 0)
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
                                        Professor pera = new Professor();
                                        pera.User = korisnik;
                                        pera.SchoolT = new School();
                                        List<School> skola = new List<School>();
                                        skola.AddRange(Data.Instance.SchoolService.GetAll());
                                        foreach (School h in skola)
                                        {
                                            if (h.Name == cbSchool.SelectedItem.ToString())
                                            {
                                                pera.SchoolT = h;

                                            }
                                        }


                                        List<Meeting> listaaa = new List<Meeting>();
                                        pera.Meetings = listaaa;
                                        List<Language> jezici = new List<Language>();
                                        List<Language> jezic = new List<Language>();
                                        jezici.AddRange(Data.Instance.languageRepository.GetAll());
                                        List<String> jezz = new List<String>();
                                        foreach (String element in listbox1.SelectedItems)
                                        {
                                            jezz.Add(element);
                                        }
                                        foreach(String ele in jezz)
                                        {
                                            Language jez = jezici.Find(e => e.Jezik == ele);
                                            jezic.Add(jez);
                                        }
                                        List<Language> temp = new List<Language>();
                                        pera.Languages = temp;
                                        pera.Languages.AddRange(jezic);
                                        Data.Instance.ProfessorService.Add(pera);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Chose at least 1 language");
                                    }

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
            if (g == 0)
            {
                
            }    


                DialogResult = true;
            Close();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txtEmail.Text.Length > 5)
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
                                cbSchool.Visibility = Visibility.Visible;   
                                listbox1.Visibility = Visibility.Visible;

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
                                
                                skola.AddRange(Data.Instance.SchoolService.GetAll());
                                List<String> skole = new List<String>();
                                foreach (School y in skola)
                                {
                                    skole.Add(y.Name);
                                }
                                cbSchool.ItemsSource = skole;
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
