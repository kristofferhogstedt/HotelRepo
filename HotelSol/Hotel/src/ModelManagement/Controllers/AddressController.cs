using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
using Hotel.src.ModelManagement.Utilities.Displayers;
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
            throw new NotImplementedException();
        }

        public int CreateAndReturnID()
        {
            var _modelForm = ModelFactory.GetModelRegistrationForm(ModelType, PreviousMenu);
            IAddress _entity = (IAddress)_modelForm.CreateForm();

            if (_entity == null)
            {
                Console.WriteLine("Ingen data att spara, återgår...");
                Thread.Sleep(2000);
            }

            AddressService.Create(_entity, PreviousMenu);



            return _entity.ID;
        }

        public IModel GetOne()
        {
            //IAddress _entityToReturn = AddressEntitySelector.Select(AddressService.GetAll(), 0, PreviousMenu);
            //return _entityToReturn;
            return null;
        }

        //public IModel GetOneByID()
        //{
        //    AnsiConsole.MarkupLine("");
        //}

        public void ReadOne()
        {
            throw new NotImplementedException();
        }

        public void ReadAll()
        {
            AddressDisplayer.RenderDeadTable(AddressService.GetAll(PreviousMenu), PreviousMenu);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Update(IModel modelToUpdate)
        {
            var _customer = (ICustomer)modelToUpdate;

            var _addressToUpdate = AddressService.GetOneByCustomerID(_customer.ID, PreviousMenu);
            var _modelForm = ModelFactory.GetModelRegistrationForm(ModelType, PreviousMenu);
            IAddress _entity;

            if (_addressToUpdate == null)
                _entity = (IAddress)_modelForm.CreateForm();
            else
                _entity = (IAddress)_modelForm.EditForm(_addressToUpdate);

            if (_entity == null)
            {
                Console.WriteLine("Ingen data att spara, återgår...");
                Thread.Sleep(2000);
                return;
            }
            else
                AddressService.Create(_entity, PreviousMenu);
        }

        public void Delete(IModel modelToDelete)
        {
            var _addressToDelete = (IAddress)modelToDelete;
            DisplaySummary(_addressToDelete);
            Console.WriteLine("Radera?");
            var _confirm = UserInputHandler.UserInputBool(PreviousMenu);

            if (_confirm)
            {
                AddressService.Delete(_addressToDelete);
                Console.WriteLine("Adress raderad.");
                Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                Console.ReadKey();
            }
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
