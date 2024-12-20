using HotelLibrary.Models.Interfaces;
using Hotel;
using Hotel.src.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Models.Controllers
{
    public class CustomerController
    {
        public static void Create()
        {

        }

        public static ICustomer ReadOne(ApplicationDbContext dbContext)
        {
            Console.Write("Ange katt: ");
            return dbContext.Students.First(c => c.FirstName == Console.ReadLine());
        }

        public static List<ICustomer> ReadAll(StudentContext dbContext)
        {
            return dbContext.Students.ToList();
        }

        public static void Update(StudentContext dbContext)
        {
            Console.Clear();
            StudentService.ReadAll(dbContext).ForEach(c => Console.WriteLine(c.DisplayString()));
            Console.Write("Välj katt att uppdatera: ");
            var _entityToUpdate = dbContext.Students.First(c => c.FirstName + " " + c.LastName == Console.ReadLine());
            Console.Clear();
            Console.WriteLine($"uppdaterar ålder på: {_entityToUpdate.FirstName} {_entityToUpdate.LastName}");
            Console.Write("Ange ny ålder: ");
            //_entityToUpdate. = UserInputManager.UserInputInt();

            Console.Clear();
            Console.WriteLine("Uppdaterad lista: ");
            StudentService.ReadAll(dbContext).ForEach(c => Console.WriteLine(c.DisplayString()));
            dbContext.SaveChanges();
        }
        public void Delete()
        {

        }
    }
}
