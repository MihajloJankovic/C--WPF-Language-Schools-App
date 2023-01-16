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

namespace LanguageSchools.Views
{
    /// <summary>
    /// Interaction logic for StudentHomexaml.xaml
    /// </summary>
    public partial class StudentHomexaml : Window
    {
        Student peraa;
        public StudentHomexaml(String Student)
        {
            InitializeComponent();
            this.peraa = Data.Instance.studentRepository.GetById(Student);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StudentV pp = new StudentV();
            pp.JMBG = peraa.User.JMBG;
            AddEditStudent pera = new AddEditStudent(pp);
            var result = pera.ShowDialog();
            if (result == true)
            {
                peraa.User = pera.st.User;


            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Scheduler pera = new Scheduler(peraa);
            pera.ShowDialog();
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var s = new ShowProfessorsWindow(peraa);
            s.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var s = new ShowSchools(peraa);
            s.ShowDialog();

        }

        private void DataWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var g = new Home();
            g.Show();
            
        }
    }
}
