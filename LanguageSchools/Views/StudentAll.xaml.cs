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
    /// Interaction logic for StudentAll.xaml
    /// </summary>
    public partial class StudentAll : Window
    {
        public StudentAll()
        {
            InitializeComponent();

            List<User> schools = Data.Instance.studentRepository.GetAllStudents().ToList();

            dgSchools.ItemsSource = Data.Instance.studentRepository.getViewModel(schools);
        }

        private void DeleteStudent(object sender, RoutedEventArgs e)
        {
            var sprof = dgSchools.SelectedItem as StudentV;
            if (sprof != null)
            {
                Data.Instance.studentRepository.Delete(sprof.JMBG);

                List<User> schools = Data.Instance.studentRepository.GetAllStudents().ToList();

                dgSchools.ItemsSource = Data.Instance.studentRepository.getViewModel(schools);

            }



        }

        private void miUpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            var sprof = dgSchools.SelectedItem as StudentV;
            if (sprof != null)
            {
                var addEditProfessorWindow = new AddEditStudent(sprof);

                var successful = addEditProfessorWindow.ShowDialog();

                if ((bool)successful)
                {

                    List<User> schools = Data.Instance.studentRepository.GetAllStudents().ToList();

                    dgSchools.ItemsSource = Data.Instance.studentRepository.getViewModel(schools);
                }
            }

        }

        private void miAddStudent_Click(object sender, RoutedEventArgs e)
        {

            var addEditProfessorWindow = new AddEditStudent();

            var successeful = addEditProfessorWindow.ShowDialog();

            if ((bool)successeful)
            {

                List<User> schools = Data.Instance.studentRepository.GetAllStudents().ToList();

                dgSchools.ItemsSource = Data.Instance.studentRepository.getViewModel(schools);
            }
        }
    }
}
