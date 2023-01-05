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
    /// Interaction logic for ProfessorHome.xaml
    /// </summary>
    public partial class ProfessorHome : Window
    {
        private Professor professor;
        public ProfessorHome(String prof)
        {
            InitializeComponent();
            this.professor = Data.Instance.ProfessorService.GetByIdSec(prof);
        }
    }
}
