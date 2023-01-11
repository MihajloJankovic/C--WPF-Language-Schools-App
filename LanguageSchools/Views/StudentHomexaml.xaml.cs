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
    }
}
