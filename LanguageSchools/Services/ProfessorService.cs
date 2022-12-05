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

        //public List<Professor> GetActiveProfessors()
        //{
        //    // baza
        //}
        public void Add(Professor professor)
        {
            userRepository.Add(professor.User);
           professorRepository.Add(professor);
        
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
