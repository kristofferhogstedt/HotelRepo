using Bogus;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.Persistence;
using Hotel.src.Utilities.Seeding.Interfaces;

namespace Hotel.src.Utilities.Seeding
{
    public class CustomerSeeder : ISeedable
    {
        public static void Seed(DatabaseLair databaseLair)
        {
            if (databaseLair.DatabaseContext.Rooms.Any())
            {
                return;   // DB already contains data
            }

            var _customers = CustomerSeeder.CreateSeed(10);
            foreach (var customer in _customers)
            {
                databaseLair.DatabaseContext.Customers.Add((Customer)customer);
            }

            databaseLair.DatabaseContext.SaveChanges();
        }

        /// <summary>
        /// Creates seed data (with Bogus NuGet)
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static List<ICustomer> CreateSeed(int num)
        {
            var _addressFaker = new Faker<IAddress>()
                .RuleFor(a => a.ID, f => f.IndexFaker + 1)
                .RuleFor(c => c.Country, f => f.Address.Country())
                .RuleFor(c => c.City, f => f.Address.City())
                .RuleFor(c => c.PostalCode, f => f.Address.ZipCode())
                .RuleFor(c => c.StreetAddress, f => f.Address.StreetAddress());

            var _customerFaker = new Faker<ICustomer>()
                .RuleFor(c => c.ID, f => f.IndexFaker + 1)
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(c => c.Address, f => _addressFaker.Generate())
                .RuleFor(c => c.IsActive, f => f.Random.Bool(0.8f))
                .RuleFor(c => c.CreatedDate, f => f.Date.Past())
                .RuleFor(c => c.UpdatedDate, f => f.Date.Recent());
                //.RuleFor(c => c.InactivatedDate, f => f.Date.Past()); // Can this be faked depending on IsActive?

            var _customers = _customerFaker.Generate(num);
            return _customers;
        }

    }
}
