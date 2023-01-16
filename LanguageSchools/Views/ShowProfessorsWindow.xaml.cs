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
    /// Interaction logic for ShowProfessorsWindow.xaml
    /// </summary>
    public partial class ShowProfessorsWindow : Window
    {
        private Student st;
        private bool s;
        public ShowProfessorsWindow()
        {
            st = null;
            InitializeComponent();
            List<String> str = new List<String>();
            List<Language> jezici = new List<Language>();
            jezici.AddRange(Data.Instance.languageRepository.GetAll());
            foreach (Language lang in jezici)
            {
                str.Add(lang.Jezik);
            }
            listbox1.SelectionMode = SelectionMode.Multiple;
            listbox1.ItemsSource = str;

            List<Professor> users = Data.Instance.ProfessorService.GetAll().ToList();
            
            dgProfessors.ItemsSource = Data.Instance.ProfessorService.getViewModel(users);
        }
        public ShowProfessorsWindow(Student st)
        {
            InitializeComponent();
            this.st = st;
            miAddProfessor.Visibility = Visibility.Hidden;
            miUpdateProfessor.Visibility = Visibility.Hidden;
            miDeleteProfessor.Visibility = Visibility.Hidden;
            miAddProfessor.Visibility = Visibility.Hidden;
            List<String> str = new List<String>();
            List<Language> jezici = new List<Language>();
            jezici.AddRange(Data.Instance.languageRepository.GetAll());
            foreach (Language lang in jezici)
            {
                str.Add(lang.Jezik);
            }
            listbox1.SelectionMode = SelectionMode.Multiple;
            listbox1.ItemsSource = str;

            List<Professor> users = Data.Instance.ProfessorService.GetAll().ToList();

            dgProfessors.ItemsSource = Data.Instance.ProfessorService.getViewModel(users);
        }
        public ShowProfessorsWindow(bool st)
        {
            InitializeComponent();
            this.s = st;
            miAddProfessor.Visibility = Visibility.Hidden;
            miUpdateProfessor.Visibility = Visibility.Hidden;
            miDeleteProfessor.Visibility = Visibility.Hidden;
            miAddProfessor.Visibility = Visibility.Hidden;
            miSC.Visibility = Visibility.Hidden;
            List<String> str = new List<String>();
            List<Language> jezici = new List<Language>();
            jezici.AddRange(Data.Instance.languageRepository.GetAll());
            foreach (Language lang in jezici)
            {
                str.Add(lang.Jezik);
            }
            listbox1.SelectionMode = SelectionMode.Multiple;
            listbox1.ItemsSource = str;

            List<Professor> users = Data.Instance.ProfessorService.GetAll().ToList();

            dgProfessors.ItemsSource = Data.Instance.ProfessorService.getViewModel(users);
        }
        public ShowProfessorsWindow(Student st,String sk)
        {
            InitializeComponent();
            this.st = st;
            School test = new School();
            test = Data.Instance.SchoolService.GetById(Convert.ToInt32(sk));
            miAddProfessor.Visibility = Visibility.Hidden;
            miUpdateProfessor.Visibility = Visibility.Hidden;
            miDeleteProfessor.Visibility = Visibility.Hidden;
            miAddProfessor.Visibility = Visibility.Hidden;
            List<String> str = new List<String>();
            List<Language> jezici = new List<Language>();
            jezici.AddRange(Data.Instance.languageRepository.GetAll());
            foreach (Language lang in jezici)
            {
                str.Add(lang.Jezik);
            }
            listbox1.SelectionMode = SelectionMode.Multiple;
            listbox1.ItemsSource = str;
            List<Professor> userss = new List<Professor>();
            List<Professor> users = Data.Instance.ProfessorService.GetAll().ToList();
            foreach(Professor user in users)
            {
                if(user.SchoolT.Name == test.Name)
                {
                    userss.Add(user);
                }

            }
            dgProfessors.ItemsSource = Data.Instance.ProfessorService.getViewModel(userss);
        }
        private void miAddProfessor_Click(object sender, RoutedEventArgs e)
        {
            var addEditProfessorWindow = new AddEditProfessorsWindow();

            var successeful = addEditProfessorWindow.ShowDialog();

            if ((bool)successeful)
            {

                List<Professor> users = Data.Instance.ProfessorService.GetAll().ToList();

                dgProfessors.ItemsSource = Data.Instance.ProfessorService.getViewModel(users); ;
            }
        }
        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            
           if(this.st is not null)
            {
              
            }
            else
            {
                if (this.s = true)
                {

                }
                else
                {
                    MainWindow pera = new MainWindow();
                    pera.Show();
                }
            }
        }
        private void miUpdateProfessor_Click(object sender, RoutedEventArgs e)
        {
            var sprof = dgProfessors.SelectedItem as ProfessorV;
            if(sprof != null)
            {
                var addEditProfessorWindow = new AddEditProfessorsWindow(sprof);

                var successful = addEditProfessorWindow.ShowDialog();

                if ((bool)successful)
                {

                    List<Professor> users = Data.Instance.ProfessorService.GetAll().ToList();

                    dgProfessors.ItemsSource = Data.Instance.ProfessorService.getViewModel(users); ;
                }
            }
        }

        private void DeleteProf(object sender, RoutedEventArgs e)
        {
            var sprof = dgProfessors.SelectedItem as ProfessorV;
            

            if (sprof != null)
            {
                Professor pera = Data.Instance.ProfessorService.GetById(sprof.Professor);
                Data.Instance.ProfessorService.Delete(pera.User.JMBG);
               
                    List<Professor> users = Data.Instance.ProfessorService.GetAll().ToList();

                    dgProfessors.ItemsSource = Data.Instance.ProfessorService.getViewModel(users); ;
                
            }
        }

        private void miSC_Click(object sender, RoutedEventArgs e)
        {
            var sprof = dgProfessors.SelectedItem as ProfessorV;
            if (sprof != null)
            {
               if(st is null)
                {
                    var addEditProfessorWindow = new Scheduler(sprof,true);

                    var successful = addEditProfessorWindow.ShowDialog();

                    if ((bool)successful)
                    {

                        List<Professor> users = Data.Instance.ProfessorService.GetAll().ToList();

                        dgProfessors.ItemsSource = Data.Instance.ProfessorService.getViewModel(users); ;
                    }
                }
                else
                {
                    var addEditProfessorWindow = new Scheduler(st,sprof);

                    var successful = addEditProfessorWindow.ShowDialog();

                    if ((bool)successful)
                    {

                        List<Professor> users = Data.Instance.ProfessorService.GetAll().ToList();

                        dgProfessors.ItemsSource = Data.Instance.ProfessorService.getViewModel(users); ;
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (sch.Text.Trim().Length != 0)
            {
               

                List<Professor> schools = Data.Instance.ProfessorService.GetSch(sch.Text.Trim());
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
                List<Professor> skolee = new List<Professor>();
                foreach (Professor s in schools)
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

                dgProfessors.ItemsSource = Data.Instance.ProfessorService.getViewModel(skolee);



            }
            else
            {
                List<Professor> schools = Data.Instance.ProfessorService.GetAll().ToList();
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
                List<Professor> skolee = new List<Professor>();
                foreach (Professor s in schools)
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



                dgProfessors.ItemsSource = Data.Instance.ProfessorService.getViewModel(skolee);
            }
        }

        private void sch_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (sch.Text.Trim().Length != 0)
            {


                List<Professor> schools = Data.Instance.ProfessorService.GetSch(sch.Text.Trim());
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
                List<Professor> skolee = new List<Professor>();
                foreach (Professor s in schools)
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

                dgProfessors.ItemsSource = Data.Instance.ProfessorService.getViewModel(skolee);



            }
            else
            {
                List<Professor> users = Data.Instance.ProfessorService.GetAll().ToList();

                dgProfessors.ItemsSource = Data.Instance.ProfessorService.getViewModel(users); ;
            }
        }
    }
}
