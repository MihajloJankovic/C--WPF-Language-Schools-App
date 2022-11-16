using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using LanguageSchools.Services;

namespace LanguageSchools.Models
{
    sealed class Data
    {
        private static readonly Data instance = new Data();
        public IUserService UserService { get; set; }
        public IProfessorService ProfessorService { get; set; }

        static Data() { }

        private Data()
        {
            UserService = new UserService();
            ProfessorService = new ProfessorService();
        }

        public static Data Instance
        {
            get
            {
                return instance;
            }
        }

        public void Initialize()
        {
          //inicijalizacija
        }

        public void LoadData()
        {
           // za sada prazno 
        }

        private List<User> LoadUsers()
        {
            //baza 
        }

        private List<Professor> LoadProfessors()
        {
            //baza
         
        }
    }
}
