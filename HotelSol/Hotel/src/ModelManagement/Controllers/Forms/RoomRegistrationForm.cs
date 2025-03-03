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
using Hotel.src.ModelManagement.Validations;
using HotelLibrary.Utilities.UserInputManagement;
using Spectre.Console;

namespace Hotel.src.ModelManagement.Controllers.Forms
{
    public class RoomRegistrationForm : IModelRegistrationForm, IInstantiable
    {
        private static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety
        public IMenu PreviousMenu { get; set; }
        public EModelType ModelType { get; set; } = EModelType.Room;
        public IModelRegistrationForm? RelatedForm { get; set; }
        public EModelType RelatedFormModelType { get; set; } = EModelType.RoomDetails;
        public IModelController ModelController { get; set; }
        public IRoom NewEntity { get; set; }
        public bool IsAnEdit { get; set; }

        public object Data01 { get; set; }
        public object Data02 { get; set; }
        public object Data03 { get; set; }
        public object Data04 { get; set; }
        public object Data05 { get; set; }
        public object Data06 { get; set; }
        public object Data07 { get; set; }
        public object Data08 { get; set; }
        public object Data09 { get; set; }
        public object Data10 { get; set; }

        public void AssignRelatedForm(IModelRegistrationForm relatedForm)
        {
            RelatedForm = relatedForm;
        }

        public static IModelRegistrationForm GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<RoomRegistrationForm>(_instance, _lock, previousMenu);
            return (IModelRegistrationForm)_instance;
        }

        public void CreateForm()
        {
            ModelController = ModelFactory.GetModelController(ModelType, PreviousMenu);
            IsAnEdit = false;

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Rumsnummer[/]: ");
            Data01 = RoomValidator.ValidateRoomNumber(false, PreviousMenu);

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Beskrivning[/]: ");
            Data02 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Våning[/]: ");
            Data03 = RoomValidator.ValidateFloor(false, PreviousMenu);

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            RelatedForm = ModelFactory.GetModelRegistrationForm(RelatedFormModelType, PreviousMenu);
            RelatedForm.AssignRelatedForm(this);

            Data04 = RelatedForm.CreateAndReturnForm(); // start RoomDetail registration form
            var _newRoomDetails = (IRoomDetails)Data04;

            var _newRoom = new Room((string)Data01, (string)Data02, (int)Data03);
            _newRoomDetails.RoomID = _newRoom.ID;

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);

            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
                NewEntity = new Room((string)Data01, (string)Data02, (int)Data03, (RoomDetails)_newRoomDetails);

                RoomService.Create((Room)NewEntity);
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
            var ExistingEntity = (IRoom)entityToUpdate;
            ModelController = ModelFactory.GetModelController(ModelType, PreviousMenu);
            IsAnEdit = true;

            Console.Clear();
            DisplaySummary(ExistingEntity);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Rumsnummer[/]: ");
            Data01 = RoomValidator.ValidateRoomNumber(true, PreviousMenu);
            if (CopyChecker.CheckCopyValue(Data01))
                Data01 = ExistingEntity.Name;

            Console.Clear();
            DisplaySummary(ExistingEntity);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Beskrivning[/]: ");
            Data02 = UserInputHandler.UserInputString(PreviousMenu);
            if (CopyChecker.CheckCopyValue(Data02))
                Data02 = ExistingEntity.Description;

            Console.Clear();
            DisplaySummary(ExistingEntity);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Våning[/]: ");
            Data03 = RoomValidator.ValidateFloor(true, PreviousMenu);
            if (CopyChecker.CheckCopyValue(Data03))
                Data03 = ExistingEntity.Floor;

            Console.Clear();
            DisplaySummary(ExistingEntity);
            FormDisplayer.DisplayCurrentFormValues(this);
            RelatedForm = ModelFactory.GetModelRegistrationForm(RelatedFormModelType, PreviousMenu);
            RelatedForm.AssignRelatedForm(this);
            Data04 = RelatedForm.EditAndReturnForm(ExistingEntity.Details); // start RoomDetail registration form

            var _newRoomDetails = (IRoomDetails)Data04;
            _newRoomDetails.RoomID = ExistingEntity.ID;

            Console.Clear();
            Console.WriteLine("Tidigare värden: ");
            DisplaySummary(ExistingEntity);
            Console.WriteLine("Nya värden: ");
            FormDisplayer.DisplayCurrentFormValues(this);

            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                NewEntity = new Room((string)Data01, (string)Data02, (int)Data03, (RoomDetails)_newRoomDetails)
                { ID = ExistingEntity.ID, UpdatedDate = DateTime.Now };

                RoomService.Update((Room)NewEntity);
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
            var ExistingEntity = (IRoom)entityToDelete;
            IsAnEdit = true;

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Godkänn inaktivering[/]: ");

            if (UserInputHandler.UserInputBool(PreviousMenu))
            {
                RoomService.Delete(ExistingEntity);
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
            var ExistingEntity = (IRoom)entityToReactivate;
            IsAnEdit = true;

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Godkänn återaktivering[/]: ");

            if (UserInputHandler.UserInputBool(PreviousMenu))
            {
                ExistingEntity.IsInactive = false;
                ExistingEntity.InactivatedDate = null;
                RoomService.Update(ExistingEntity);
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
            // Room
            Console.Clear();
            FormDisplayer.DisplayFormHeader();
            AnsiConsole.MarkupLine("\n[bold green]Sammanfattning:[/]");
            var table = new Table();
            table.AddColumn("[red]Fält[/]");
            table.AddColumn("[red]Värde[/]");
            table.AddRow("Rumsnummer", (string)Data01);
            table.AddRow("Beskrivning", (string)Data02);
            table.AddRow("Våning", (string)Data03);

            // Room Details
            table.AddRow("Typ", (string)RelatedForm.Data01);
            table.AddRow("Storlek", (string)RelatedForm.Data02);
            table.AddRow("Antal sängar", (string)Data03);
            table.AddRow("Typ", (string)RelatedForm.Data04);

            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Summary of existing customer information
        /// </summary>
        /// <param name="entity"></param>
        public void DisplaySummary(IRoom entity)
        {
            Console.Clear();
            AnsiConsole.MarkupLine("\n[bold green]Sammanfattning av kundinformation:[/]");
            var table = new Table();
            table.AddColumn("[red]Fält[/]");
            table.AddColumn("[red]Värde[/]");
            table.AddRow("Rumsnummer", entity.Name);
            table.AddRow("Beskrivning", entity.Description);
            table.AddRow("Våning", entity.Floor.ToString());
            table.AddRow("Typ", entity.Details.RoomType.Name);
            table.AddRow("Storlek", entity.Details.Size.ToString());
            table.AddRow("Antal sängar", entity.Details.NumberOfBeds.ToString());
            table.AddRow("Pris", entity.Details.Price.ToString());
            AnsiConsole.Write(table);
        }
    }
}
