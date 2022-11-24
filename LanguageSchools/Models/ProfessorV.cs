using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchools.Models
{
    public class ProfessorV
    {
      
         
        
            [NonSerialized]
            private String prof;

            public String Professor { get => prof; set => prof = value; }
   
        public string Name { get; set; }
        public string Languages { get; set; }
        public string school_name { get; set; }


        
    }

}

