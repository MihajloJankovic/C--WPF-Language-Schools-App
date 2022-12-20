using LanguageSchools.Models;
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

namespace LanguageSchools.Views
{
    /// <summary>
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Window
    {
        private Student st;
        private DateTime dt;
        public AddEvent(Student st,DateTime dt)
        {
            this.st = st;
            this.dt= dt;
            InitializeComponent();
            List<School> skola = new List<School>();

            skola.AddRange(Data.Instance.SchoolService.GetAll());
            List<String> skole = new List<String>();
            foreach (School y in skola)
            {
                skole.Add(y.Name);
            }
            cbSchool.ItemsSource = skole;
            Professor.Visibility = Visibility.Hidden;
            listbox1.Visibility = Visibility.Hidden;
         
        }

       
        private void cbSchool_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox pera = sender as ComboBox;
            
             if (string.IsNullOrEmpty(cbSchool.SelectedItem.ToString()))
            {
                List<String> pp = new List<string>();
                listbox1.ItemsSource = pp;
                Professor.ItemsSource = pp;
            }
            else
            {
                School school = new School();
                String Name = pera.Text;
                school = Data.Instance.SchoolService.GetByName(Name);
                List<Professor> peraa = Data.Instance.ProfessorService.GetBySchool(school.Id.ToString());
                List<String> li = new List<string>();
                foreach(Professor p in peraa)
                {
                    li.Add(p.User.FirstName + " " + p.User.LastName + "--" + p.UserId);
                }    
                Professor.ItemsSource = li ;
                

            }
        }
        private void Professor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox pera = sender as ComboBox;

            if (Professor.SelectedItem is null)
            {
                List<String> pp = new List<string>();
                listbox1.ItemsSource = pp;
            }
            else
            {
                Professor per = new Professor();
                String te = Professor.SelectedItem.ToString();

                Regex regex = new Regex("-");         // Split on hyphens.
                string[] substrings = regex.Split(te);
                String jmbg = substrings[2];
                per = Data.Instance.ProfessorService.GetById(jmbg);

                List<String> str = new List<String>();
                List<Language> jezici = new List<Language>();
                jezici.AddRange(per.Languages);
                foreach (Language lang in jezici)
                {
                    str.Add(lang.Jezik);
                }
                listbox1.SelectionMode = SelectionMode.Single;
                listbox1.ItemsSource = str;


            }

        }





        private void cbSchool_DropDownClosed_1(object sender, EventArgs e)
        {
            if (cbSchool.SelectedItem is null)
            {
                List<String> pp = new List<string>();
                listbox1.ItemsSource = pp;
                Professor.ItemsSource = pp;
            }
            else
            {
                School school = new School();
                String Name = cbSchool.SelectedItem.ToString();
                school = Data.Instance.SchoolService.GetByName(Name);
                List<Professor> peraa = Data.Instance.ProfessorService.GetBySchool(school.Id.ToString());
                List<String> li = new List<string>();
                foreach (Professor p in peraa)
                {
                    li.Add(p.User.FirstName + " " + p.User.LastName + "--" + p.UserId);
                }
                Professor.ItemsSource = li;

            }
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Professor.Visibility = Visibility.Visible;
            listbox1.Visibility = Visibility.Visible;
            btn.Visibility = Visibility.Hidden;

            if (cbSchool.SelectedItem is null)
            {
                List<String> pp = new List<string>();
                listbox1.ItemsSource = pp;
                Professor.ItemsSource = pp;
            }
            else
            {
                School school = new School();
                String Name = cbSchool.SelectedItem.ToString();
                school = Data.Instance.SchoolService.GetByName(Name);
                List<Professor> peraa = Data.Instance.ProfessorService.GetBySchool(school.Id.ToString());
                List<String> li = new List<string>();
                foreach (Professor p in peraa)
                {
                    li.Add(p.User.FirstName + " " + p.User.LastName + "--" + p.UserId);
                }
                Professor.ItemsSource = li;

            }

        }

        private void cbSchool_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ComboBox pera = sender as ComboBox;

            if (Professor.SelectedItem is null)
            {
                List<String> pp = new List<string>();
                listbox1.ItemsSource = pp;
            }
            else
            {
                Professor per = new Professor();
                String te = Professor.SelectedItem.ToString();

                Regex regex = new Regex("-");         // Split on hyphens.
                string[] substrings = regex.Split(te);
                String jmbg = substrings[2];
                per = Data.Instance.ProfessorService.GetById(jmbg);

                List<String> str = new List<String>();
                List<Language> jezici = new List<Language>();
                jezici.AddRange(per.Languages);
                foreach (Language lang in jezici)
                {
                    str.Add(lang.Jezik);
                }
                listbox1.SelectionMode = SelectionMode.Single;
                listbox1.ItemsSource = str;


            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Professor per = new Professor();
            String te = Professor.SelectedItem.ToString();

            Regex regex = new Regex("-");         // Split on hyphens.
            string[] substrings = regex.Split(te);
            String jmbg = substrings[2];
            per = Data.Instance.ProfessorService.GetById(jmbg);

            

            if(listbox1.SelectedItem is not null )
            {
                Meeting mt = new Meeting();
                mt.Professor = per;
                mt.Student = this.st;
                mt.From = dt;
                mt.To = dt.AddHours(1);
                mt.Status = true;
                Data.Instance.meetingRepository.Add(mt);

            }
        }
    }
}
