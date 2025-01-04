using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
using Hotel.src.ModelManagement.Utilities.Selectors;
using HotelLibrary.Utilities.UserInputManagement;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Controllers
{
    public class AddressController : IModelController, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
        public EModelType ModelType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety

        public AddressController()
        {
        }

        /// <summary>
        /// Single instance
        /// </summary>
        /// <returns></returns>
        public static ISupportModelController GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<AddressController>(_instance, _lock, previousMenu);
            return (ISupportModelController)_instance;
        }

        public void Create()
        {
            var _modelForm = ModelFactory.GetModelRegistrationForm(ModelType, PreviousMenu);
            IAddress _entity = (IAddress)_modelForm.CreateForm();

            if (_entity == null)
            {
                Console.WriteLine("Ingen data att spara, återgår...");
                Thread.Sleep(2000);
                return;
            }

            AddressService.Create(_entity);
        }

        public IModel GetOne()
        {
            ICustomer _customerToReturn = CustomerEntitySelector.Select(CustomerService.GetAll(), 0, PreviousMenu);
            return _customerToReturn;
        }

        public void ReadOne()
        {
            throw new NotImplementedException();
        }

        public void ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Update(IModel modelToUpdate)
        {
            throw new NotImplementedException();
        }


        public void DisplaySummary(IAddress address)
        {
            AnsiConsole.MarkupLine($"Adress:");
            AnsiConsole.MarkupLine($"-----------------");
            AnsiConsole.MarkupLine($"Gatuadress: {address.StreetAddress}");
            AnsiConsole.MarkupLine($"Postnummer: {address.PostalCode} {address.City}");
            AnsiConsole.MarkupLine($"Land: {address.Country}");
        }

    }
}
