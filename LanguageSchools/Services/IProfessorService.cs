using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchools.Models;

namespace LanguageSchools.Services
{
    interface IProfessorService
    {
        List<Professor> GetAll();
        //   Professor GetById(string email);
        //    List<Professor> GetActiveProfessors();
        List<ProfessorV> getViewModel(List<Professor> users);
        void Add(Professor professor);
        void Update(Professor pera);
        void Delete(string email);
  //      List<User> ListAllStudents();
    }
}
