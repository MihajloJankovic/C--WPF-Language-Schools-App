using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchools.Models;

namespace LanguageSchools.Repositories
{
    interface IProfessorRepository
    {
        List<Professor> GetAll();
        void Update(Professor pera);
             Professor GetById(string email);
        List<ProfessorV> getViewModel(List<Professor> users);
        void Add(Professor professor);
  //      void Update(string email, Professor professor);
        void Delete(string email);
       List<Professor> GetBySchool(String idd);
        public Professor GetByIdSec(String idd);
        public List<Professor> GetSch(String tekst);


    }
}
