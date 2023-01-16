using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchools.Models;
using LanguageSchools.Repositories;

namespace LanguageSchools.Services
{
    class ProfessorService : IProfessorService
    {
        private ProfessorRepository professorRepository;
        private UserRepository userRepository;
        private SchoolRepository schoolRepository;

        public ProfessorService()
        {
            professorRepository = new ProfessorRepository();
            userRepository = new UserRepository();
            schoolRepository = new SchoolRepository();
        }

              public Professor GetById(string email)
          {
             return professorRepository.GetById(email);
         }
        public List<ProfessorV> getViewModel(List<Professor> users)
        {
            return professorRepository.getViewModel(users);
        }
        public List<Professor> GetAll()
        {
            return professorRepository.GetAll();
        }
        public List<Professor> GetBySchool(String idd)
        {
            return professorRepository.GetBySchool(idd);
        }
        //public List<Professor> GetActiveProfessors()
        //{
        //    // baza
        //}
        public void Add(Professor professor)
        {
            userRepository.Add(professor.User);
           professorRepository.Add(professor);
        
        }
        public Professor GetByIdSec(String idd)
        {
            return professorRepository.GetByIdSec(idd);
        }
        public List<Professor> GetSch(String tekst)
        {
            return professorRepository.GetSch(tekst);
        }
        public void Update(Professor pera)
        {
          professorRepository.Update(pera);
        }

        public void Delete(string email)
        {
           
         professorRepository.Delete(email);
        }

        //public List<User> ListAllStudents()
        //{
        //  //
        //}
    }
}
