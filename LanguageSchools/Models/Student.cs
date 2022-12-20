using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchools.Models
{
    public class Student
    {
        public User user;

        public User User { get => user; set => user = value; }
        public List<Meeting> MeetingList { get; set; }
    }
}
