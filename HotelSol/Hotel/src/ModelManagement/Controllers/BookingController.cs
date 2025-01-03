using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.FactoryManagement;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.MenuManagement.Menus;
using Hotel.src.ModelManagement.Controllers.Forms;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
using Hotel.src.ModelManagement.Utilities.Displayers;
using Hotel.src.ModelManagement.Utilities.Selectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Controllers
{
    public class BookingController : IModelController, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
        private static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety

        public BookingController()
        {
        }

        /// <summary>
        /// Single instance
        /// </summary>
        /// <returns></returns>
        public static IModelController GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<BookingController>(_instance, _lock, previousMenu);
            return (IModelController)_instance;
        }

        public void Create()
        {
            var _modelForm = BookingRegistrationForm.GetInstance(PreviousMenu);
            IBooking _model = (IBooking)_modelForm.CreateForm();

            if (_model == null)
            {
                Console.WriteLine("Ingen data att spara, återgår...");
                Thread.Sleep(2000);
                return;
            }

            BookingService.Create(_model);
        }

        //public void DisplayCurrentCustomerInfo(IBooking model)
        //{
        //    Console.Clear();
        //    Console.WriteLine($"\nFörnamn: {model.FirstName}");
        //    Console.WriteLine($"\nEfternamn: {model.LastName}");
        //    Console.WriteLine($"\nFödelsedatum: {model.DateOfBirth}");
        //    Console.WriteLine($"\nE-post: {model.Email}");
        //    Console.WriteLine($"\nTelefon: {model.Phone}");
        //    Console.WriteLine($"\nAdress: {model.Address.StreetAddress} {model.Address.PostalCode} {model.Address.City} {model.Address.Country}");
        //}

        public IBooking GetOne()
        {
            IBooking _modelToReturn = ModelEntitySelector.Select(BookingService.GetAll(), 0, PreviousMenu);
            return _modelToReturn;
        }

        public void ReadOne()
        {
            var _model = GetOne();
            Console.Clear();
            BookingDisplayer.DisplayModel(_model);
            Console.WriteLine("Vad vill du göra?");

            var _crudMenu = BookingCRUDMenu.GetInstance(PreviousMenu);
            _crudMenu.Run((IModel)_model);
        }

        public void ReadAll()
        {
            BookingDisplayer.DisplayModelTable(BookingService.GetAll());
        }

        public void Update()
        {
            var _modelToUpdate = GetOne();

            var _modelForm = BookingRegistrationForm.GetInstance(PreviousMenu);
            IBooking _model = (IBooking)_modelForm.EditForm((IModel)_modelToUpdate);

            if (_model == null)
            {
                Console.WriteLine("Ingen data att spara, återgår...");
                Thread.Sleep(2000);
                return;
            }

            BookingService.Update(_model);
        }

        public void Update(IModel modelToUpdate)
        {
            var _modelToUpdate = modelToUpdate;

            var _modelForm = BookingRegistrationForm.GetInstance(PreviousMenu);
            IBooking _model = (IBooking)_modelForm.EditForm((IModel)_modelToUpdate);

            if (_model == null)
            {
                Console.WriteLine("Ingen data att spara, återgår...");
                Thread.Sleep(2000);
                return;
            }

            CustomerService.Update(_model);
        }

        public void Delete()
        {
        }
    }
}
