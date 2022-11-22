using LanguageSchools.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchools.Services
{
    
    class MeetingService : IMeetingService
    {
        private MeetingRepository meetingRepository;
     

        public MeetingService()
        {
            meetingRepository = new MeetingRepository();
           
        }
    }
}
