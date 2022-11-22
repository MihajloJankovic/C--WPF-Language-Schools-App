using LanguageSchools.Models;
using LanguageSchools.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchools.Services
{
    public class SchoolService : ISchoolService
    {
        private ISchoolRepository schoolRepo;
    
        public SchoolService()
        {
            schoolRepo = new SchoolRepository();
        }
        public School GetByID(int id)
        {
            return schoolRepo.GetById(id);
        }
        public School GetByProfessor(int id)
        {
            return schoolRepo.GetByProfessor(id);
        }
        public void Add(School school)
        {
            schoolRepo.Add(school);
        }
        public List<School> GetAll()
        {
            return schoolRepo.GetAll();
        }
        public void AddProfessorSchool(String school, String professor)
        {
            schoolRepo.AddProfessorSchool(school, professor);
        }
    }
}
