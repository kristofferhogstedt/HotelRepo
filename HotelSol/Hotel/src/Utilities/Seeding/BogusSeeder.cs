using Bogus;
using AutoBogus;
using Hotel.src.ModelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.Utilities.Seeding
{
    public class BogusSeeder
    {
        public static List<Customer> CreateCustomer(int num)
        {
            var _addressFaker = new Faker<Address>()
                .RuleFor(a => a.ID, f => f.IndexFaker + 1)
                .RuleFor(c => c.Country, f => f.Address.Country())
                .RuleFor(c => c.City, f => f.Address.City())
                .RuleFor(c => c.PostalCode, f => f.Address.ZipCode())
                .RuleFor(c => c.StreetAddress, f => f.Address.StreetAddress());

            var _customerFaker = new Faker<Customer>()
                .RuleFor(c => c.ID, f => f.IndexFaker + 1)
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(c => c.Address, f => _addressFaker.Generate())
                .RuleFor(c => c.IsActive, f => f.Random.Bool(0.8f))
                .RuleFor(c => c.CreatedDate, f => f.Date.Past())
                .RuleFor(c => c.UpdatedDate, f => f.Date.Recent())
                .RuleFor(c => c.InactivatedDate, f => f.Date.Past());

            return _customerFaker.Generate(num);
        }

    }
}
