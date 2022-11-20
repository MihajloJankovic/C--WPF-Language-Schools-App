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
        private IProfessorRepository professorRepository;
        private IUserRepository userRepository;

        //public ProfessorService()
        //{
        //    professorRepository = new ProfessorRepository();
        //    userRepository = new UserRepository();
        //}

        //public Professor GetById(string email)
        //{
        //    return professorRepository.GetById(email);
        //}
        //
        //public List<Professor> GetAll()
        //{
        //    return professorRepository.GetAll();
        //}

        //public List<Professor> GetActiveProfessors()
        //{
        //    // baza
        //}
        //public void Add(User user)
        //{
        //    userRepository.Add(user);

        //    //var professor = new Professor
        //    //{
        //    //    User = user,
        //    //    UserId = user.Email
        //    //   
        //   // };

        //   // professorRepository.Add(professor);
        //}

        //public void Update(string email, Professor professor)
        //{
        //    userRepository.Update(email, professor.User);
        //    professorRepository.Update(email, professor);
        //}

        //public void Delete(string email)
        //{
        //    userRepository.Delete(email);
        //    professorRepository.Delete(email);
        //}

        //public List<User> ListAllStudents()
        //{
        //  //
        //}
    }
}
