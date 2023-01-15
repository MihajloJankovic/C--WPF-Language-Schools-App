using LanguageSchools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LanguageSchools.Repositories
{
     interface ISchoolRepository
    {
        public void AddProfessorSchool(String school, String professor);
        public List<School> GetAll();
        public void Add(School school);
        public School GetById(int id);
        public School GetByProfessor(int id);
        public List<SchoolV> getViewModel(List<School> skl);
        public void UpdateSchool(School pera);
        public List<School> sch(String pera);
    }
}
