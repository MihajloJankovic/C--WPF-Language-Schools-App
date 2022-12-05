using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using LanguageSchools.Repositories;
using LanguageSchools.Services;

namespace LanguageSchools.Models
{
    sealed class Data
    {
        private static readonly Data instance = new Data();
        public UserService UserService { get; set; }
        public ProfessorService ProfessorService { get; set; }
        public AddressService AddressService { get; set; }
        public SchoolRepository SchoolService { get; set; }
        public LanguageRepository languageRepository { get; set; }
        public StudentRepository studentRepository { get; set; }
        public MeetingRepository meetingRepository { get; set; }
        static Data() { }

        private Data()
        {
            UserService = new UserService();
            ProfessorService = new ProfessorService();
            AddressService = new AddressService();
            SchoolService = new SchoolRepository();
            languageRepository = new LanguageRepository();
            studentRepository = new StudentRepository();
            meetingRepository = new MeetingRepository();
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
         
        }

    }
}
