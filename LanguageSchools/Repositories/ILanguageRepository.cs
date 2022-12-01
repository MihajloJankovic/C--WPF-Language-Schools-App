using LanguageSchools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchools.Repositories
{
     interface ILanguageRepository
    {
        void Update(Professor pera);
        List<Language> GetAll();
        List<Language> GetByProfessor(int id);
        List<Language> GetBySchool(int id);
        void Add();
        void AddToProfessor(Professor professor);
        void AddToSchool(School school);
    }
}
