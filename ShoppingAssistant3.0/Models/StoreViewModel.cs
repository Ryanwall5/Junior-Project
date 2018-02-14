using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingAssistant3._0.Models
{
    [NotMapped]
    public class StoreViewModel : Store
    {
        public string Street { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }

        public int Zip { get; set; }
        
        public string Longitude { get; set; }
        
        public string Latitude { get; set; }

        public StoreViewModel() { }
        public StoreViewModel(Store store, Address address)
        {
            Id = store.Id;
            Name = store.Name;
            EmailAddress = store.EmailAddress;
            PhoneNumber = store.PhoneNumber;
            AddressId = address.Id;
            Street = address.Street;
            City = address.City;
            State = address.State;
            Zip = address.Zip;
            Longitude = address.Longitude;
            Latitude = address.Latitude;
        }

        public Address GetAddress()
        {
            Address address = new Address
            {
                Id = AddressId,
                Street = Street,
                City = City,
                State = State,
                Zip = Zip,
                Longitude = Longitude,
                Latitude = Latitude
            };

            return address;
        }
    }
}