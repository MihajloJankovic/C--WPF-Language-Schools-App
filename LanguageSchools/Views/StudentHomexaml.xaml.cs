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
        Student pera;
        public StudentHomexaml(String Student)
        {
            InitializeComponent();
            this.pera = Data.Instance.studentRepository.GetById(Student);
        }
    }
}
