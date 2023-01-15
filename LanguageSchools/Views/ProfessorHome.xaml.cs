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
using System.Windows.Forms;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StudentV pp = new StudentV();
            pp.JMBG = professor.User.JMBG;
            AddEditStudent pera = new AddEditStudent(pp);
            var result =  pera.ShowDialog();
            if (result == true)
            {
                professor.User = pera.st.User;   
            
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProfessorV gg = new ProfessorV();
            gg.Professor = professor.UserId;
            Scheduler pera = new Scheduler(gg);
            pera.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Home pera = new Home();
            pera.Show();
            this.Close();
        }
    }
}
