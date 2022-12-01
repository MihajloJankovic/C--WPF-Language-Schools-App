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
    /// Interaction logic for ShowSchools.xaml
    /// </summary>
    public partial class ShowSchools : Window
    {
        public ShowSchools()
        {
            InitializeComponent();

            List<School> schools = Data.Instance.SchoolService.GetAll().ToList();

            dgSchools.ItemsSource = Data.Instance.SchoolService.getViewModel(schools);
        }

        private void miAddSchool_Click(object sender, RoutedEventArgs e)
        {

            var addEditProfessorWindow = new AddEditSchool();

            var successeful = addEditProfessorWindow.ShowDialog();

            if ((bool)successeful)
            {

                List<School> schools = Data.Instance.SchoolService.GetAll().ToList();

                dgSchools.ItemsSource = Data.Instance.SchoolService.getViewModel(schools);
            }
        }

        private void miUpdateSchool_Click(object sender, RoutedEventArgs e)
        {
            var sprof = dgSchools.SelectedItem as SchoolV;
            if (sprof != null)
            {
                var addEditProfessorWindow = new AddEditSchool(sprof);

                var successful = addEditProfessorWindow.ShowDialog();

                if ((bool)successful)
                {

                    List<School> schools = Data.Instance.SchoolService.GetAll().ToList();

                    dgSchools.ItemsSource = Data.Instance.SchoolService.getViewModel(schools);
                }
            }
        }
    }
}
