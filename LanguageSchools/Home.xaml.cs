﻿using LanguageSchools.Models;
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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddEditStudent pera = new AddEditStudent();
            pera.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Login pera = new Login();
            var proz =pera.ShowDialog();
            if ((bool)proz)
            {

               this.Close();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var pera = new ShowSchools(false);
            pera.ShowDialog();
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var pera = new ShowProfessorsWindow(false);
            pera.ShowDialog();
            
        }
    }
}
