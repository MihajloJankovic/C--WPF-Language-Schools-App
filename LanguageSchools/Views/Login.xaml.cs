using System;
using System.Collections.Generic;
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
using LanguageSchools.Models;

namespace LanguageSchools.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            int broj = Data.Instance.UserService.CheckLogin(JMBG.Text, sifra.Password);
            if (broj == 0)
            {
                MessageBox.Show("\r\nInvalid credentials !");
            }
            if (broj == 1)
            {
                MessageBox.Show("Successful login !");
                if (Data.Instance.UserService.GetById(JMBG.Text).UserType == EUserType.STUDENT)
                {
                    StudentHomexaml pera = new StudentHomexaml(JMBG.Text);
                    pera.Show();
                }
                if (Data.Instance.UserService.GetById(JMBG.Text).UserType == EUserType.ADMINISTRATOR) 
                {
                    MainWindow pera = new MainWindow();
                    pera.Show();
                }
                if (Data.Instance.UserService.GetById(JMBG.Text).UserType == EUserType.PROFESSOR) 
                {
                    ProfessorHome pera = new ProfessorHome(JMBG.Text);
                    pera.Show();
                }
                DialogResult = true;

            }
            





        }
    }
}
