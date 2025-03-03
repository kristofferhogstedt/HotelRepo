﻿using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Menus;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Utilities;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
using Hotel.src.ModelManagement.Utilities.Calculators;
using Hotel.src.ModelManagement.Validations;
using HotelLibrary.Utilities.UserInputManagement;
using Spectre.Console;

namespace Hotel.src.ModelManagement.Controllers.Forms
{
    public class BookingRegistrationForm : IModelRegistrationForm, IInstantiable
    {
        private static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety
        public IMenu PreviousMenu { get; set; }
        public EModelType ModelType { get; set; } = EModelType.Booking;
        public IModelRegistrationForm? RelatedForm { get; set; }
        public EModelType RelatedFormModelType { get; set; } = EModelType.Booking;
        public IModelController ModelController { get; set; }
        public IBooking NewEntity { get; set; }
        public bool IsAnEdit { get; set; }
        public bool HandleInactive { get; set; } = false;

        public object Data01 { get; set; } // First name
        public object Data02 { get; set; } // Last name
        public object Data03 { get; set; } // Date of birth
        public object Data04 { get; set; } // Email
        public object Data05 { get; set; } // Phone
        public object Data06 { get; set; } // Street Address
        public object Data07 { get; set; } // Postal Code
        public object Data08 { get; set; } // City
        public object Data09 { get; set; } // Country
        public object Data10 { get; set; }

        public void AssignRelatedForm(IModelRegistrationForm relatedForm)
        {
            RelatedForm = relatedForm;
        }

        public static IModelRegistrationForm GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<BookingRegistrationForm>(_instance, _lock, previousMenu);
            return (IModelRegistrationForm)_instance;
        }

        public void CreateForm()
        {
            IsAnEdit = false;

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Rum[/]: ");
            var _roomController = ModelFactory.GetModelController(EModelType.Room, PreviousMenu);
            Data01 = _roomController.BrowseOne(HandleInactive);
            var _room = (IRoom)Data01;

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Från-datum[/]: ");
            Data02 = BookingValidator.ValidateFromDate(_room.ID, null, IsAnEdit, PreviousMenu);

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Till-datum[/]: ");
            Data03 = BookingValidator.ValidateToDate(_room.ID, null, (DateTime)Data02, IsAnEdit, PreviousMenu);


            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Kund[/]: ");
            var _customerController = ModelFactory.GetModelController(EModelType.Customer, PreviousMenu);
            Data04 = _customerController.BrowseOne(HandleInactive);
            var _customer = (ICustomer)Data04;

            var _numberOfNights = NumberOfNightsCalculator.CalculateNumberOfNights((DateTime)Data03, (DateTime)Data02);
            var _price = PriceCalculator.CalculateStayPrice(_numberOfNights, _room.Details.Price);

            // Create Invoice 
            Data05 = new Invoice(_room.Details.RoomType, _price);

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);

            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                NewEntity = new Booking((Room)Data01, (Customer)Data04, (DateTime)Data02, (DateTime)Data03, (Invoice)Data05);

                BookingService.Update(NewEntity);
                MainMenu.ReturnToMainMenu();
            }
            else
            {
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                Console.Clear();

                return;
            }
        }

        public void EditForm(IModel entityToUpdate)
        {
            var ExistingEntity = (IBooking)entityToUpdate;
            ModelController = ModelFactory.GetModelController(ModelType, PreviousMenu);
            IsAnEdit = true;

            Console.Clear();
            DisplaySummary(ExistingEntity);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Rum[/]: ");
            var _roomController = ModelFactory.GetModelController(EModelType.Room, PreviousMenu);
            var _room = (IRoom)_roomController.BrowseOne(HandleInactive);
            Data01 = _room.ID;
            Data06 = _room;
            if (CopyChecker.CheckCopyValue(Data01))
            {
                Data01 = ExistingEntity.RoomID;
                Data06 = ExistingEntity.Room;
            }

            Console.Clear();
            DisplaySummary(ExistingEntity);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Från-datum[/]: ");
            Data02 = BookingValidator.ValidateFromDate(_room.ID, ExistingEntity, IsAnEdit, PreviousMenu);
            if (CopyChecker.CheckCopyValue(Data02))
                Data02 = ExistingEntity.FromDate;

            Console.Clear();
            DisplaySummary(ExistingEntity);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Till-datum[/]: ");
            Data03 = BookingValidator.ValidateToDate(_room.ID, ExistingEntity, (DateTime)Data02, IsAnEdit, PreviousMenu);
            if (CopyChecker.CheckCopyValue(Data03))
                Data03 = ExistingEntity.FromDate;

            Console.Clear();
            DisplaySummary(ExistingEntity);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Kund[/]: ");
            var _customerController = ModelFactory.GetModelController(EModelType.Customer, PreviousMenu);
            var _customer = (ICustomer)_customerController.BrowseOne(HandleInactive);
            Data04 = _customer.ID;
            Data07 = _customer;
            if (CopyChecker.CheckCopyValue(Data04))
            {
                Data04 = ExistingEntity.CustomerID;
                Data07 = ExistingEntity.Customer;
            }

            var _numberOfNights = NumberOfNightsCalculator.CalculateNumberOfNights((DateTime)Data03, (DateTime)Data02);
            var _price = PriceCalculator.CalculateStayPrice(_numberOfNights, _room.Details.Price);

            // Create Invoice 
            Data05 = new Invoice(_room.Details.RoomType, _price);



            Console.Clear();
            Console.WriteLine("Tidigare värden: ");
            DisplaySummary(ExistingEntity);
            Console.WriteLine("Nya värden: ");

            FormDisplayer.DisplayCurrentFormValues(this);

            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                NewEntity = new Booking((int)Data01, (int)Data04, (DateTime)Data02, (DateTime)Data03, (Invoice)Data05)
                { ID = ExistingEntity.ID, UpdatedDate = DateTime.Now };

                BookingService.Update(NewEntity);
                MainMenu.ReturnToMainMenu();
            }
            else
            {
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                Console.Clear();
                return;
            }
        }

        public void InactivateForm(IModel entityToDelete)
        {
            var ExistingEntity = (IBooking)entityToDelete;
            ModelController = ModelFactory.GetModelController(ModelType, PreviousMenu);
            IsAnEdit = true;

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Godkänn inaktivering[/]: ");
            Data01 = UserInputHandler.UserInputBool(PreviousMenu);
            if ((bool)Data01 == true)
            {
                BookingService.Delete(ExistingEntity);
                InvoiceService.Delete(ExistingEntity.Invoice);
                MainMenu.ReturnToMainMenu();
            }
            else
            {
                Console.WriteLine("Inaktivering avbruten, Återgår...");
                Thread.Sleep(1000);
                Console.Clear();
                return;
            }
        }
        public void ReactivateForm(IModel entityToReactivate)
        {
            var ExistingEntity = (IBooking)entityToReactivate;
            IsAnEdit = true;

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Godkänn återaktivering[/]: ");

            if (UserInputHandler.UserInputBool(PreviousMenu))
            {
                ExistingEntity.IsInactive = false;
                ExistingEntity.InactivatedDate = null;
                BookingService.Update(ExistingEntity);
                MainMenu.ReturnToMainMenu();
            }
            else
            {
                Console.WriteLine("Inaktivering avbruten, Återgår...");
                Thread.Sleep(1000);
                Console.Clear();
                return;
            }
        }

        public IModel CreateAndReturnForm()
        {
            throw new NotImplementedException();
        }
        public IModel EditAndReturnForm(IModel modelToUpdate)
        {
            throw new NotImplementedException();
        }

        public void DisplaySummary()
        {
            // Booking
            FormDisplayer.DisplayFormHeader();
            AnsiConsole.MarkupLine("\n[bold green]Sammanfattning:[/]");
            var table = new Table();
            table.AddColumn("[red]Fält[/]");
            table.AddColumn("[red]Värde[/]");
            table.AddRow("Rum", (string)Data01);
            table.AddRow("Från-datum", (string)Data02);
            table.AddRow("Till-datum", (string)Data03);
            table.AddRow("Kund", (string)Data04);

            // Invoice data
            table.AddRow("Belopp", (string)RelatedForm.Data01);
            table.AddRow("Förfallodatum", (string)RelatedForm.Data02);
            table.AddRow("Är betald?", (string)Data03);

            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Summary of existing customer information
        /// </summary>
        /// <param name="entity"></param>
        public void DisplaySummary(IBooking entity)
        {
            AnsiConsole.MarkupLine("\n[bold green]Sammanfattning av Bokningsinformation:[/]");
            var table = new Table();
            table.AddColumn("[red]Fält[/]");
            table.AddColumn("[red]Värde[/]");
            table.AddRow("Rum", entity.Room.Name);
            table.AddRow("Från-datum", entity.FromDate.Date.ToShortDateString());
            table.AddRow("Till-datum", entity.ToDate.ToShortDateString());
            table.AddRow("Kund", entity.Customer.FullName);

            // Invoice data
            table.AddRow("Belopp", entity.Invoice.Amount.ToString());
            table.AddRow("Förfallodatum", entity.Invoice.DueDate.ToShortDateString());
            table.AddRow("Är betald?", entity.Invoice.IsPaid.ToString());
            AnsiConsole.Write(table);
        }
    }
}
