using LanguageSchools.Models;
using LanguageSchools.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchools.Services
{
     class AddressService : IAddressService
    {
        private IAddressRepository addressRepository;

        public AddressService()
        {
            addressRepository = new AddressRepository();
            
        }
        public void Add(Address address)
        {
            addressRepository.Add(address);
        }

    }
}
