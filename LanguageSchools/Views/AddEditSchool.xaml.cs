using LanguageSchools.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for AddEditSchool.xaml
    /// </summary>
    public partial class AddEditSchool : Window
    {
        private School school;
        private int g;
        public AddEditSchool()
        {
            InitializeComponent();
            school = new School();
             g = 0;
            List<String> str = new List<String>();
            List<Language> jezici = new List<Language>();
            jezici.AddRange(Data.Instance.languageRepository.GetAll());
            foreach (Language lang in jezici)
            {
                str.Add(lang.Jezik);
            }
            listbox1.SelectionMode = SelectionMode.Multiple;
            listbox1.ItemsSource = str;

        }
        public AddEditSchool(SchoolV skola)
        {
            InitializeComponent();
            school = new School();
            School pera = new School();
            pera = Data.Instance.SchoolService.GetById(Convert.ToInt32(skola.School));
            pera.Languages = new List<Language>();
            school = pera;
            g = 1;
            Name.Text = school.Name;
            emailx.Text = school.Address.Street;
            passwordx.Text = school.Address.StreetNumber;
            firstnamex.Text = school.Address.Country;
            lastnamex.Text = school.Address.City;
            List<String> str = new List<String>();
            List<Language> jezici = new List<Language>();
            jezici.AddRange(Data.Instance.languageRepository.GetAll());
            foreach (Language lang in jezici)
            {
                str.Add(lang.Jezik);
            }
            listbox1.SelectionMode = SelectionMode.Multiple;
            listbox1.ItemsSource = str;

            List<String> jezz = new List<String>();
            foreach (Language element in pera.Languages)
            {
                jezz.Add(element.Jezik);
            }
            foreach (String lang in jezz)
            {
                listbox1.SelectedItems.Add(lang);
            }

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(g==0)
            {
                School sch = new School();
                sch.Address = new Address();
                sch.Name = Name.Text;
                sch.Address.Street = emailx.Text;
                sch.Address.StreetNumber = passwordx.Text;
                sch.Address.Country = firstnamex.Text;
                sch.Address.City = lastnamex.Text;
                if(Name.Text.Length > 3)
                {
                    if (emailx.Text.Length > 3)
                    {
                        if (passwordx.Text.Length >= 1)
                        {
                            if (firstnamex.Text.Length > 3)
                            {
                                if (lastnamex.Text.Length > 3)
                                {
                                    if (listbox1.SelectedItems.Count > 0)
                                    {
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
                                        List<Language> temp = new List<Language>();
                                        sch.Languages = temp;
                                        sch.Languages.AddRange(jezic);
                                        sch.Id = 1;
                                        Data.Instance.SchoolService.Add(sch);

                                        DialogResult = true;
                                        Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Chose at least 1 language");
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("City name too short");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Contry name too short");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter street number");
                        }
                    }
                    else
                    {
                        MessageBox.Show("street name too short");
                    }
                }
                else
                {
                    MessageBox.Show("School name too short");
                }
            }
            if(g==1)
            {
                School sch = new School();
                sch.Name = Name.Text;
                sch.Address = new Address();
                sch.Address.Street = emailx.Text;
                sch.Address.StreetNumber = passwordx.Text;
                sch.Address.Country = firstnamex.Text;
                sch.Address.City = lastnamex.Text;
                if (Name.Text.Length > 3)
                {
                    if (emailx.Text.Length > 3)
                    {
                        if (passwordx.Text.Length >= 1)
                        {
                            if (firstnamex.Text.Length > 3)
                            {
                                if (lastnamex.Text.Length > 3)
                                {
                                    if (listbox1.SelectedItems.Count > 0)
                                    {
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
                                        List<Language> temp = new List<Language>();
                                        sch.Languages = temp;
                                        sch.Languages.AddRange(jezic);

                                        School pp =  Data.Instance.SchoolService.GetById(school.Id);
                                        pp.Name = Name.Text;
                                        pp.Address.Street = emailx.Text;
                                        pp.Address.StreetNumber = passwordx.Text;
                                        pp.Address.Country = firstnamex.Text;
                                        pp.Address.City = lastnamex.Text;
                                        pp.Languages = sch.Languages;
                                        Data.Instance.SchoolService.UpdateSchool(pp);
                                        DialogResult = true;
                                        Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Chose at least 1 language");
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("City name too short");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Contry name too short");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter street number");
                        }
                    }
                    else
                    {
                        MessageBox.Show("street name too short");
                    }
                }
                else
                {
                    MessageBox.Show("School name too short");
                }
            }
        }
    }
}
