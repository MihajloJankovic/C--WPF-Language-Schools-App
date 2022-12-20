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
        private Student st;
        public Scheduler(ProfessorV peraa)
        {

            InitializeComponent();
            Schedule.ViewType = SchedulerViewType.Week;
            Schedule.DaysViewSettings.StartHour = 8;
            Schedule.DaysViewSettings.EndHour = 15;
            this.Schedule.AppointmentEditorOpening += Schedule_AppointmentEditorOpening1;
            String ID = peraa.Professor;
            Professor pera = new Professor();
            pera = Data.Instance.ProfessorService.GetById(ID);

            var scheduleAppointmentCollection = new ScheduleAppointmentCollection();
            foreach(Meeting p in pera.Meetings)
                {
                scheduleAppointmentCollection.Add(new ScheduleAppointment()
                {
                    StartTime = p.From,
                    EndTime = p.To,
                    Subject = p.Student.User.FirstName + " "+ p.Student.User.LastName,
                });
            }

            Schedule.ItemsSource = scheduleAppointmentCollection;

        }
        public Scheduler(Student student)
        {
            this.st= student;
            InitializeComponent();
            Schedule.ViewType = SchedulerViewType.Week;
            Schedule.DaysViewSettings.StartHour = 8;
            Schedule.DaysViewSettings.EndHour = 15;
            this.Schedule.AppointmentEditorOpening += Schedule_AppointmentEditorOpening1;
          

            var scheduleAppointmentCollection = new ScheduleAppointmentCollection();
            foreach (Meeting p in student.MeetingList)
            {
                scheduleAppointmentCollection.Add(new ScheduleAppointment()
                {
                    StartTime = p.From,
                    EndTime = p.To,
                    Subject = p.Professor.User.FirstName + " " + p.Professor.User.LastName,
                    Id = p.Id,
                });
            }

            Schedule.ItemsSource = scheduleAppointmentCollection;


        }
        private void Schedule_AppointmentEditorOpening1(object? sender, AppointmentEditorOpeningEventArgs e)
        {
            
            e.Cancel = true;
            if (e.Appointment != null)
            {
               
                if (this.st is null)
                {

                }
                else
                {
                    var professorsWindow = new EditEvent(Convert.ToInt32(e));
                    professorsWindow.Show();
                    this.Hide();
                }
            }
            else
            {
                if(this.st is null)
                {

                }
                else
                {

                    var professorsWindow = new AddEvent(st,e.DateTime);
                    professorsWindow.Show();
                    this.Hide();
                }
            }
        }

    }
}
