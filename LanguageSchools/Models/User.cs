using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace LanguageSchools.Models
{
    [Serializable]
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JMBG { get; set; }
        public EGender Gender { get; set; }
        public EUserType UserType { get; set; }
        public Address Address { get; set; }

        public bool IsActive { get; set; }


        public User() {
            IsActive = true;
            Gender = EGender.MALE;
            UserType = EUserType.STUDENT;
           // Address.Id = 5;
          //  Address.Street = "ulica";
          //  Address.StreetNumber = "5";
         //   Address.City = "beska";
          //  Address.Country = "srbija";
        }
        public User(String Email, String Password, String FirstName, String LastName, String JMBG)
        {   
            this.IsActive = true;
            this.Email = Email;
            this.Password = Password;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.JMBG = JMBG;
            this.Address = new Address();
            this.Address.Id = 5;
            this.Address.Street = "fruskgorska";
            this.Address.StreetNumber = "5";
            this.Address.City = "beska";
            this.Address.Country = "srbija";
        }

        public override string ToString()
        {
            return $"[User] {FirstName} {LastName}, {Email}";
        }
    }
}
