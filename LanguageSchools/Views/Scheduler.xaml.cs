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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace LanguageSchools.Views
{
    /// <summary>
    /// Interaction logic for Scheduler.xaml
    /// </summary>
    public partial class Scheduler : Window
    {
        private Student st;
        private bool admin;
        private Professor perica;
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
                    Id = p.Id,
                });
            }

            Schedule.ItemsSource = scheduleAppointmentCollection;

        }
        public Scheduler(ProfessorV peraa,bool ad)
        {

            InitializeComponent();
            this.admin = ad;
            Schedule.ViewType = SchedulerViewType.Week;
            Schedule.DaysViewSettings.StartHour = 8;
            Schedule.DaysViewSettings.EndHour = 15;
            this.Schedule.AppointmentEditorOpening += Schedule_AppointmentEditorOpening1;
            String ID = peraa.Professor;
            Professor pera = new Professor();
            pera = Data.Instance.ProfessorService.GetById(ID);
            perica = pera;
            var scheduleAppointmentCollection = new ScheduleAppointmentCollection();
            foreach (Meeting p in pera.Meetings)
            {
                scheduleAppointmentCollection.Add(new ScheduleAppointment()
                {
                    StartTime = p.From,
                    EndTime = p.To,
                    Subject = p.Student.User.FirstName + " " + p.Student.User.LastName,
                    Id = p.Id,
                });
            }

            Schedule.ItemsSource = scheduleAppointmentCollection;

        }
        public Scheduler(Student student,bool adm)
        {
            this.admin = adm;
            this.st = student;
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
        public Scheduler(Student student, ProfessorV peraa)
        {
            this.st = student;
            
            InitializeComponent();
            Schedule.ViewType = SchedulerViewType.Week;
            Schedule.DaysViewSettings.StartHour = 8;
            Schedule.DaysViewSettings.EndHour = 15;
            this.Schedule.AppointmentEditorOpening += Schedule_AppointmentEditorOpening1;
            String ID = peraa.Professor;
            Professor pera = new Professor();
            pera = Data.Instance.ProfessorService.GetById(ID);
            this.perica = pera;
            var scheduleAppointmentCollection = new ScheduleAppointmentCollection();
            foreach (Meeting p in pera.Meetings)
            {
                scheduleAppointmentCollection.Add(new ScheduleAppointment()
                {
                    StartTime = p.From,
                    EndTime = p.To,
                    Subject = p.Student.User.FirstName + " " + p.Student.User.LastName,
                    Id = p.Id,


                }) ;
            }

            Schedule.ItemsSource = scheduleAppointmentCollection;


        }
        private void Schedule_AppointmentEditorOpening1(object? sender, AppointmentEditorOpeningEventArgs e)
        {
            
            e.Cancel = true;
            if (e.Appointment != null)
            {
               if(admin == true)
                {
                    if(perica is not null )
                    {

                        var professorsWindow = new EditEvent(Convert.ToInt32(e.Appointment.Id));
                       
                        var result = professorsWindow.ShowDialog();
                        if(result == true)
                        {
                            perica.Meetings.Remove(perica.Meetings.Find((x => x.Id == Convert.ToInt32(e.Appointment.Id))));
                            var scheduleAppointmentCollection = new ScheduleAppointmentCollection();
                            foreach (Meeting p in perica.Meetings)
                            {
                                scheduleAppointmentCollection.Add(new ScheduleAppointment()
                                {
                                    StartTime = p.From,
                                    EndTime = p.To,
                                    Subject = p.Student.User.FirstName + " " + p.Student.User.LastName,
                                    Id = p.Id,
                                });
                            }

                            Schedule.ItemsSource = scheduleAppointmentCollection;
                        }

                    }
                    else
                    {

                        var professorsWindow = new EditEvent(Convert.ToInt32(e.Appointment.Id));
                       
                        var result = professorsWindow.ShowDialog();
                        if(result == true )
                        {
                            st.MeetingList.Remove(st.MeetingList.Find((x => x.Id == Convert.ToInt32(e.Appointment.Id))));
                            var scheduleAppointmentCollection = new ScheduleAppointmentCollection();
                            foreach (Meeting p in st.MeetingList)
                            {
                                scheduleAppointmentCollection.Add(new ScheduleAppointment()
                                {
                                    StartTime = p.From,
                                    EndTime = p.To,
                                    Subject = p.Student.User.FirstName + " " + p.Student.User.LastName,
                                    Id = p.Id,
                                });
                            }

                            Schedule.ItemsSource = scheduleAppointmentCollection;
                        }
                    }
                }
                if (this.st is null)
                {

                }
                else
                {
                    var professorsWindow = new EditEvent(Convert.ToInt32(e.Appointment.Id));
                   

                    var res = professorsWindow.ShowDialog();
                    if(res == true)
                    {
                        st.MeetingList.Remove(st.MeetingList.Find((x => x.Id == Convert.ToInt32(e.Appointment.Id))));
                        var scheduleAppointmentCollection = new ScheduleAppointmentCollection();
                        foreach (Meeting p in st.MeetingList)
                        {
                            scheduleAppointmentCollection.Add(new ScheduleAppointment()
                            {
                                StartTime = p.From,
                                EndTime = p.To,
                                Subject = p.Student.User.FirstName + " " + p.Student.User.LastName,
                                Id = p.Id,


                            });
                        }

                        Schedule.ItemsSource = scheduleAppointmentCollection;
                    }
                    
                }
            }
            else
            {
                if(e.DateTime < DateTime.Now.AddMonths(1))
                {
                    if (this.st is null)
                    {

                    }
                    else
                    {
                       if(this.admin == true)
                        {

                            var professorsWindow = new AddEvent(st, e.DateTime);
                            professorsWindow.Show();
                            this.Hide();
                        }
                        else
                        {
                           if(this.perica is not null )
                            {
                                var h = new q1();
                                var result = h.ShowDialog();
                                if (result == true)
                                {
                                    Meeting mt = new Meeting();
                                    mt.Professor = perica;
                                    mt.Student = this.st;
                                    mt.From = e.DateTime;
                                    mt.To = e.DateTime.AddHours(1);
                                    mt.Status = true;
                                    Data.Instance.meetingRepository.Add(mt);
                                    st.MeetingList.Add(mt);
                                    perica.Meetings.Add(mt);
                                    var scheduleAppointmentCollection = new ScheduleAppointmentCollection();
                                    foreach (Meeting p in perica.Meetings)
                                    {
                                        scheduleAppointmentCollection.Add(new ScheduleAppointment()
                                        {
                                            StartTime = p.From,
                                            EndTime = p.To,
                                            Subject = p.Student.User.FirstName + " " + p.Student.User.LastName,

                                        });
                                    }

                                    Schedule.ItemsSource = scheduleAppointmentCollection;
                                }

                            }
                        }
                    }
                }
            }
        }

    }
}
