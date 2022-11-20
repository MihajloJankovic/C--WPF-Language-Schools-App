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

namespace LanguageSchools.Views
{
    /// <summary>
    /// Interaction logic for AddEditProfessorsWindow.xaml
    /// </summary>
    public partial class AddEditProfessorsWindow : Window
    {
        private User newUser;
        public AddEditProfessorsWindow(User usercina)
        {
            InitializeComponent();
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
            newUser = new User
            {
                UserType = EUserType.PROFESSOR
            };
           
            DataContext = newUser;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            newUser.Email = txtEmail.Text;
            newUser.FirstName = txtFirstName.Text;
            newUser.JMBG = txtJMBG.Text;
            newUser.LastName = txtLastName.Text;
            newUser.Password = txtPassword.Text;
           
            Data.Instance.UserService.Add(newUser);
           

            DialogResult = true;
            Close();
        }
    }
}
