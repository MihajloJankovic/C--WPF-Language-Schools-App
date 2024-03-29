﻿using LanguageSchools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchools.Repositories
{
     interface IMeetingRepository
    {
        List<Meeting> GetByProfessor(int id);
        void AddToProfessor(Professor professor);
        public void Update(Professor pera);
        void UpdateStudent(Student pera);
        List<Meeting> getByStudent(int id);
        List<Meeting> getByProfessor(Professor professor);

        void Add(Meeting meeting);
    }
}
