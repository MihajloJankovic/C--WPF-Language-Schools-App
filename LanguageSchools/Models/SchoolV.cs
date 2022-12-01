using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchools.Models
{
    public class SchoolV
    {

        [NonSerialized]
        private String school;

        public String School { get => school; set => school = value; }

        public string Name { get; set; }
        public string Address { get; set; }

        public string Languages { get; set; }
    }
}
