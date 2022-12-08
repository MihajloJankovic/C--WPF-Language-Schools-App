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
using LanguageSchools.Models;
using Syncfusion.UI.Xaml.Scheduler;

namespace LanguageSchools.Views
{
    /// <summary>
    /// Interaction logic for Scheduler.xaml
    /// </summary>
    public partial class Scheduler : Window
    {
        public Scheduler(ProfessorV peraa)
        {
            InitializeComponent();
            this.Schedule.AppointmentEditorOpening += Schedule_AppointmentEditorOpening1;
            String ID = peraa.Professor;
            Professor pera = new Professor();


            pera = Data.Instance.ProfessorService.GetById(ID);
            

        }
        private void Schedule_AppointmentEditorOpening1(object? sender, AppointmentEditorOpeningEventArgs e)
        {
            
            e.Cancel = true;
            if (e.Appointment != null)
            {
                // e.Resource nam daje taj sastanak .
            }
            else
            {
                //Display the custom appointment editor window to add new appointment
            }
        }

    }
}
