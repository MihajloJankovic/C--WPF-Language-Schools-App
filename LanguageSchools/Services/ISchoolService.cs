using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchools.Models;

namespace LanguageSchools.Services
{
    internal interface ISchoolService
    {
        School GetByID(int id);
        void Add(School school);
        School GetByProfessor(int id);
        List<School> GetAll();
        void AddProfessorSchool(String school, String professor);
        public List<School> sch(String pera);
    }
}
