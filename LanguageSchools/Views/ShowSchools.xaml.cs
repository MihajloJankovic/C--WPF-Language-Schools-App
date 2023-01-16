using LanguageSchools.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private Student st;
        private bool s;
        public ShowSchools()
        {
            InitializeComponent();
            professors.Visibility = Visibility.Hidden;
            List<String> str = new List<String>();
            List<Language> jezici = new List<Language>();
            jezici.AddRange(Data.Instance.languageRepository.GetAll());
            foreach (Language lang in jezici)
            {
                str.Add(lang.Jezik);
            }
            listbox1.SelectionMode = SelectionMode.Multiple;
            listbox1.ItemsSource = str;

            List<School> schools = Data.Instance.SchoolService.GetAll().ToList();

           
            
            dgSchools.ItemsSource = Data.Instance.SchoolService.getViewModel(schools);
            
        }
        public ShowSchools(Student st)
        {
            InitializeComponent();
            this.st = st;
            miDeleteProfessor.Visibility = Visibility.Hidden;
            miAddSchool.Visibility = Visibility.Hidden;
            miUpdateSchool.Visibility = Visibility.Hidden;
            List<String> str = new List<String>();
            List<Language> jezici = new List<Language>();
            jezici.AddRange(Data.Instance.languageRepository.GetAll());
            foreach (Language lang in jezici)
            {
                str.Add(lang.Jezik);
            }
            listbox1.SelectionMode = SelectionMode.Multiple;
            listbox1.ItemsSource = str;

            List<School> schools = Data.Instance.SchoolService.GetAll().ToList();



            dgSchools.ItemsSource = Data.Instance.SchoolService.getViewModel(schools);

        }
        public ShowSchools(bool st)
        {
            InitializeComponent();
            s = st;
            miDeleteProfessor.Visibility = Visibility.Hidden;
            miAddSchool.Visibility = Visibility.Hidden;
            miUpdateSchool.Visibility = Visibility.Hidden;
            professors.Visibility = Visibility.Hidden;
            List<String> str = new List<String>();
            List<Language> jezici = new List<Language>();
            jezici.AddRange(Data.Instance.languageRepository.GetAll());
            foreach (Language lang in jezici)
            {
                str.Add(lang.Jezik);
            }
            listbox1.SelectionMode = SelectionMode.Multiple;
            listbox1.ItemsSource = str;

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
        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            if(s = true)
            {

            }
            if (this.st is not null)
            {
              
            }
            else
            {
                if (s = true)
                {

                }
                else
                {
                    MainWindow pera = new MainWindow();
                    pera.Show();
                }
            }
        }
        private void DeleteSch(object sender, RoutedEventArgs e)
        {
            var sprof = dgSchools.SelectedItem as SchoolV;
            if (sprof != null)
            {
                Data.Instance.SchoolService.Delete(sprof.School);

                List<School> schools = Data.Instance.SchoolService.GetAll().ToList();

                dgSchools.ItemsSource = Data.Instance.SchoolService.getViewModel(schools);

            }
        }
        

        private void ss(object sender, SelectionChangedEventArgs e)
        {

        }

        private void sch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void sch_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (sch.Text.Trim().Length != 0)
            {
                List<School> schools = Data.Instance.SchoolService.sch(sch.Text.Trim());
                List<Language> jezici = new List<Language>();
                List<Language> jezic = new List<Language>();
                jezici.AddRange(Data.Instance.languageRepository.GetAll());
                List<String> jezz = new List<String>();
                foreach (String element in listbox1.SelectedItems)
                {
                    jezz.Add(element);
                }
                foreach (String ele in jezz)
                {
                    Language jez = jezici.Find(e => e.Jezik == ele);
                    jezic.Add(jez);
                }
                List<School> skolee = new List<School>();
                foreach (School s in schools)
                {
                    int h = 0;
                    foreach (Language jez in s.Languages)
                    {
                        foreach (Language g in jezic)
                        {
                            if (jez.Jezik == g.Jezik)
                            {
                                h = h + 1;
                            }
                        }
                    }
                    if (h == jezic.Count)
                    {
                        skolee.Add(s);
                    }


                }

                dgSchools.ItemsSource = Data.Instance.SchoolService.getViewModel(skolee);



            }
            else
            {
                List<School> schools = Data.Instance.SchoolService.GetAll().ToList();



                dgSchools.ItemsSource = Data.Instance.SchoolService.getViewModel(schools);
            }
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (sch.Text.Trim().Length != 0)
            {
                List<School> schools = Data.Instance.SchoolService.sch(sch.Text.Trim());
                List<Language> jezici = new List<Language>();
                List<Language> jezic = new List<Language>();
                jezici.AddRange(Data.Instance.languageRepository.GetAll());
                List<String> jezz = new List<String>();
                foreach (String element in listbox1.SelectedItems)
                {
                    jezz.Add(element);
                }
                foreach (String ele in jezz)
                {
                    Language jez = jezici.Find(e => e.Jezik == ele);
                    jezic.Add(jez);
                }
                List<School> skolee = new List<School>();
                foreach (School s in schools)
                {
                    int h = 0;
                    foreach (Language jez in s.Languages)
                    {
                        foreach (Language g in jezic)
                        {
                            if (jez.Jezik == g.Jezik)
                            {
                                h = h + 1;
                            }
                        }
                    }
                    if (h == jezic.Count)
                    {
                        skolee.Add(s);
                    }


                }

                dgSchools.ItemsSource = Data.Instance.SchoolService.getViewModel(skolee);



            }
            else
            {
                List<School> schools = Data.Instance.SchoolService.GetAll().ToList();
                List<Language> jezici = new List<Language>();
                List<Language> jezic = new List<Language>();
                jezici.AddRange(Data.Instance.languageRepository.GetAll());
                List<String> jezz = new List<String>();
                foreach (String element in listbox1.SelectedItems)
                {
                    jezz.Add(element);
                }
                foreach (String ele in jezz)
                {
                    Language jez = jezici.Find(e => e.Jezik == ele);
                    jezic.Add(jez);
                }
                List<School> skolee = new List<School>();
                foreach (School s in schools)
                {
                    int h = 0;
                    foreach (Language jez in s.Languages)
                    {
                        foreach (Language g in jezic)
                        {
                            if (jez.Jezik == g.Jezik)
                            {
                                h = h+1;
                            }
                        }
                    }
                    if (h == jezic.Count)
                    {
                        skolee.Add(s);
                    }


                }



                dgSchools.ItemsSource = Data.Instance.SchoolService.getViewModel(skolee);
            }
        }

        private void professors_Click(object sender, RoutedEventArgs e)
        {
            var sprof = dgSchools.SelectedItem as SchoolV;
            if (sprof != null)
            {
                var addEditProfessorWindow = new ShowProfessorsWindow(st,sprof.School);

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
