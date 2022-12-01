using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchools.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public bool IsDeleted { get; set; }
        public List<Language> Languages { get; set; }
        public School()
        {
            this.IsDeleted = false;
        }
    }
}
