﻿using LanguageSchools.Models;
using LanguageSchools.Repositories;
using LanguageSchools.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LanguageSchools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
         //   Data.Instance.LoadData();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            var professorsWindow = new ShowProfessorsWindow();
            professorsWindow.Show();
            this.Hide();
            

        }

        private void btnSchool_Click(object sender, RoutedEventArgs e)
        {
            var professorsWindow = new ShowSchools();
            professorsWindow.Show();
            this.Hide();
        }

        private void btnStudent_Click(object sender, RoutedEventArgs e)
        {
            var professorsWindow = new StudentAll();
            professorsWindow.Show();
            this.Hide();
        }

        

        private void btnadg_Click(object sender, RoutedEventArgs e)
        {

            var professorsWindow = new Home();
            professorsWindow.Show();
            this.Hide();
            Close();
        }
       
    }
}
