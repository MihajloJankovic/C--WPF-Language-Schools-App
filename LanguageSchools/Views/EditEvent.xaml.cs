using LanguageSchools.Models;
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

namespace LanguageSchools.Views
{
    /// <summary>
    /// Interaction logic for EditEvent.xaml
    /// </summary>
    public partial class EditEvent : Window
    {
        Meeting cas;
        public EditEvent(int pera)
        {
            InitializeComponent();
            this.cas = new Meeting();
            cas = Data.Instance.meetingRepository.GetMeeting(pera);


            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cas.Status = false;
            Data.Instance.meetingRepository.UpdateMeet(cas.Id);
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
