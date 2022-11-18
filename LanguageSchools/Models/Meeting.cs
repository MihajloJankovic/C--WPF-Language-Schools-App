using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchools.Models
{
    internal class Meeting
    {
        public int Id { get; set; }
        public Professor Professor { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Student Student { get; set; }
        public bool Status { get; set; }
    }
}
