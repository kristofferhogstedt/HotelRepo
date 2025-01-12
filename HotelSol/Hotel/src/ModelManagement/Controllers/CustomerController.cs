using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Menus;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
using Hotel.src.ModelManagement.Utilities.Displayers;
using Hotel.src.ModelManagement.Utilities.Selectors;
using Hotel.src.Persistence;

namespace Hotel.src.ModelManagement.Controllers
{
    public class CustomerController : IModelController, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
        private static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety
        public EModelType ModelTypeEnum { get; set; } = EModelType.Customer;
        public bool GetRelatedObjects { get; set; } = true;

        public CustomerController()
        {
        }

        /// <summary>
        /// Single instance
        /// </summary>
        /// <returns></returns>
        public static IModelController GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<CustomerController>(_instance, _lock, previousMenu);
            return (IModelController)_instance;
        }

        public void Create()
        {
            var _customerForm = ModelFactory.GetModelRegistrationForm(ModelTypeEnum, PreviousMenu);
            _customerForm.CreateForm();
            //ICustomer _customer = (ICustomer)_customerForm.CreateForm();

            //if (_customer == null)
            //{
            //    Console.WriteLine("Ingen data att spara, återgår...");
            //    Thread.Sleep(2000);
            //    return;
            //}
            //else
            //    CustomerService.Create(_customer);
        }
        public void Create(IModel entityToCreate)
        {
            CustomerService.Create((ICustomer)entityToCreate);
        }

        public IModel BrowseOne(bool isInactive)
        {
            ICustomer _customerToReturn = CustomerEntitySelector.Select(CustomerService.GetAll(GetRelatedObjects, isInactive), 0, PreviousMenu);
            return _customerToReturn;
        }

        public void ManageOne(bool isInactive)
        {
            var _customer = (ICustomer)BrowseOne(isInactive);
            Console.Clear();
            CustomerDisplayer.DisplayModel(_customer);
            Console.WriteLine("Vad vill du göra?");

            //var _crudMenu = CustomerCRUDMenu.GetInstance(PreviousMenu);
            var _crudMenu = ModelCRUDMenu.GetInstance(PreviousMenu);
            _crudMenu.Run((IModel)_customer);
        }

        public void ReadAll(bool isInactive)
        {
            CustomerDisplayer.DisplayModelTable(CustomerService.GetAll(GetRelatedObjects, isInactive));
        }

        public void Update()
        {
            //var _customerToUpdate = BrowseOne();

            //var _customerForm = ModelFactory.GetModelRegistrationForm(ModelTypeEnum, PreviousMenu);
            //_customerForm.EditForm((IModel)_customerToUpdate);
            ////ICustomer _customer = (ICustomer)_customerForm.EditForm((IModel)_customerToUpdate);

            //if (_customer == null)
            //{
            //    Console.WriteLine("Ingen data att spara, återgår...");
            //    Thread.Sleep(2000);
            //    return;
            //}
            //    CustomerService.Update(_customer);
        }

        public void Update(IModel entityToUpdate)
        {
            var _customerToUpdate = entityToUpdate;

            var _customerForm = ModelFactory.GetModelRegistrationForm(ModelTypeEnum, PreviousMenu);
            _customerForm.EditForm((IModel)_customerToUpdate);
            //ICustomer _customer = (ICustomer)_customerForm.EditForm((IModel)_customerToUpdate);

            //if (_customer == null)
            //{
            //    Console.WriteLine("Ingen data att spara, återgår...");
            //    Thread.Sleep(2000);
            //    return;
            //}
            //else
            //    CustomerService.Update(_customer);
        }

        //public void Update(DatabaseLair dbLair)
        //{
        //    Console.Clear();
        //    dbLair.DatabaseContext.Customers.Displayer.ReadAll(dbLair).ForEach(c => Console.WriteLine(c.DisplayString()));
        //    Console.Write("Välj katt att uppdatera: ");
        //    var _entityToUpdate = dbContext.Students.First(c => c.FirstName + " " + c.LastName == Console.ReadLine());
        //    Console.Clear();
        //    Console.WriteLine($"uppdaterar ålder på: {_entityToUpdate.FirstName} {_entityToUpdate.LastName}");
        //    Console.Write("Ange ny ålder: ");
        //    //_entityToUpdate. = UserInputManager.UserInputInt();

        //    Console.Clear();
        //    Console.WriteLine("Uppdaterad lista: ");
        //    CustomerService.ReadAll(dbContext).ForEach(c => Console.WriteLine(c.DisplayString()));
        //    dbContext.SaveChanges();
        //}
        public void Delete(IModel entityToDelete)
        {
            var _modelForm = ModelFactory.GetModelRegistrationForm(ModelTypeEnum, PreviousMenu);
            _modelForm.InactivateForm((IModel)entityToDelete);
        }
        public void Reactivate(IModel entityToReactivate)
        {
            var _modelForm = ModelFactory.GetModelRegistrationForm(ModelTypeEnum, PreviousMenu);
            if (DatabaseLair.DatabaseContext.Customers.Any(b => b.IsInactive == true))
                _modelForm.ReactivateForm((IModel)entityToReactivate);
            else
            {
                Console.WriteLine("Inga inaktiva finns");
                Thread.Sleep(2000);
            }
        }

        public void DisplaySummary(IModel entityToDisplay)
        {
            var _customer = (ICustomer)entityToDisplay;
            Console.Clear();
            Console.WriteLine($"\nFörnamn: {_customer.FirstName}");
            Console.WriteLine($"\nEfternamn: {_customer.LastName}");
            Console.WriteLine($"\nFödelsedatum: {_customer.DateOfBirth}");
            Console.WriteLine($"\nE-post: {_customer.Email}");
            Console.WriteLine($"\nTelefon: {_customer.Phone}");
            Console.WriteLine($"\nGatuadress: {_customer.StreetAddress}");
            Console.WriteLine($"\nPostnummer: {_customer.PostalCode}");
            Console.WriteLine($"\nStad: {_customer.City}");
            Console.WriteLine($"\nLand: {_customer.Country}");

        }
    }
}
