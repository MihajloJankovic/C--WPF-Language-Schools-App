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
    /// Interaction logic for ShowProfessorsWindow.xaml
    /// </summary>
    public partial class ShowProfessorsWindow : Window
    {
        public ShowProfessorsWindow()
        {
            InitializeComponent();
          
            List<Professor> users = Data.Instance.ProfessorService.GetAll().ToList();
            
            dgProfessors.ItemsSource = Data.Instance.ProfessorService.getViewModel(users);
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
                Data.Instance.ProfessorService.Delete(sprof.Professor);
               
                    List<Professor> users = Data.Instance.ProfessorService.GetAll().ToList();

                    dgProfessors.ItemsSource = Data.Instance.ProfessorService.getViewModel(users); ;
                
            }
        }
    }
}
