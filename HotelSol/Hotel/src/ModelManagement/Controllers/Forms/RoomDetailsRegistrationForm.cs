using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.FactoryManagement;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Utilities;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Models;
using HotelLibrary.Utilities.UserInputManagement;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.src.ModelManagement.Validations;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Services;
using Hotel.src.MenuManagement.Menus;

namespace Hotel.src.ModelManagement.Controllers.Forms
{
    internal class RoomDetailsRegistrationForm : IModelRegistrationForm, IInstantiable
    {
        private static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety
        public IMenu PreviousMenu { get; set; }
        public IMenu MainMenu { get; set; } = MenuFactory.GetMenu<MainMenu>();
        public EModelType ModelType { get; set; } = EModelType.RoomDetails;
        public IModelRegistrationForm? RelatedForm { get; set; }
        public EModelType RelatedFormModelType { get; set; } = EModelType.Room;
        public IRoomDetails NewEntity { get; set; }
        public IRoom Room { get; set; }
		public IRoomType RoomType { get; set; }
		public IModelController ModelController { get; set; }
        public bool IsAnEdit { get; set; }

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
            _instance = InstanceGenerator.GetInstance<RoomDetailsRegistrationForm>(_instance, _lock, previousMenu);
            return (IModelRegistrationForm)_instance;
        }

        public void CreateForm()
        {
            throw new NotImplementedException();
        }

        public void EditForm(IModel modelToUpdate)
        {
            throw new NotImplementedException();
        }

        public void InactivateForm(IModel entityToDelete)
        {
            var ExistingEntity = (IRoomDetails)entityToDelete;
            IsAnEdit = true;

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Godkänn inaktivering[/]: ");
            Data01 = UserInputHandler.UserInputBool(PreviousMenu);
            if ((bool)Data01 == true)
            {
                RoomDetailsService.Delete(ExistingEntity);
            }
            else
            {
                Console.WriteLine("Inaktivering avbruten, Återgår...");
                Thread.Sleep(1000);
                return;
            }
        }

		public void ReactivateForm(IModel entityToReactivate)
		{
			throw new NotImplementedException();
		}


		public IModel CreateAndReturnForm()
		{
			IsAnEdit = false;

			Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Rumtyp[/]: ");
            Data01 = RoomDetailsValidator.ValidateRoomType(null, IsAnEdit, PreviousMenu);
            if (Data01 != null)
			{
				RoomType = Data01 as IRoomType;
				Data02 = RoomType.ID;
			}
			else
            {
                Console.WriteLine("Fel vid val av rumstyp, återgår till föregående meny... Kontakta admin om problemet kvarstår.");
                Thread.Sleep(3000);
                PreviousMenu.Run();
            }

   //         // Rum
   //         Data03 = parentRoom;
			//if (Data03 != null)
			//{
			//	Room = Data03 as IRoom;
			//	Data04 = Room.ID;
			//}
			//else
			//{
			//	Console.WriteLine("Fel vid tilldelning av ägande rum, återgår till föregående meny... Kontakta admin om problemet kvarstår.");
			//	Thread.Sleep(3000);
			//	PreviousMenu.Run();
			//}

			Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine($"\n[yellow]Storlek[/] (default {RoomType.SizeDefault}): ");
            Data05 = RoomDetailsValidator.ValidateRoomSize(RoomType, false, PreviousMenu);

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine($"\n[yellow]Antal sängar[/] (default {RoomType.NumberOfBedsDefault}): ");
            Data06 = RoomDetailsValidator.ValidateNumberOfBeds(RoomType, (int)Data05, false, PreviousMenu);

			Console.Clear();
			FormDisplayer.DisplayCurrentFormValues(this);
			AnsiConsole.MarkupLine($"\n[yellow]Pris[/] (default {RoomType.PriceDefault}): ");
			Data07 = UserInputHandler.UserInputDouble(PreviousMenu);
			if (CopyChecker.CheckCopyValue(Data05))
				Data07 = RoomType.PriceDefault;

			Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
                NewEntity = new RoomDetails((IRoomType)Data01, (int)Data02, (int)Data05, (int)Data06, (double)Data07);

				return (IModel)NewEntity;
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);

                PreviousMenu.Run();
                return null;
            }
        }

        public IModel EditAndReturnForm(IModel entityToUpdate)
		{
			IsAnEdit = true;
			var ExistingEntity = (IRoomDetails)entityToUpdate;
            //ModelController = ModelFactory.GetModelController(ModelType, PreviousMenu);

            Console.Clear();
            DisplaySummary(ExistingEntity);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Rumtyp[/]: ");
            Data01 = RoomDetailsValidator.ValidateRoomType(ExistingEntity.RoomType, IsAnEdit, PreviousMenu);
            if (CopyChecker.CheckCopyValue(Data01))
                Data01 = ExistingEntity.RoomType;

            if (Data01 != null)
            {
                RoomType = Data01 as IRoomType;
                Data02 = RoomType.ID; 
            }

            else
            {
                Console.WriteLine("Fel vid val av rumstyp, återgår till föregående meny... Kontakta admin om problemet kvarstår.");
                Thread.Sleep(3000);
                PreviousMenu.Run();
            }

			//Data03 = ExistingEntity.Room;
			//if (Data03 != null)
			//{
			//	Room = Data03 as IRoom;
			//	Data04 = Room.ID;
			//}
			//else
			//{
			//	Console.WriteLine("Fel vid tilldelning av ägande rum, återgår till föregående meny... Kontakta admin om problemet kvarstår.");
			//	Thread.Sleep(3000);
			//	PreviousMenu.Run();
			//}


			Console.Clear();
            DisplaySummary(ExistingEntity);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine($"\n[yellow]Storlek[/] (default {RoomType.SizeDefault}): ");
            Data05 = RoomDetailsValidator.ValidateRoomSize(RoomType, true, PreviousMenu);
            if (CopyChecker.CheckCopyValue(Data05))
				Data05 = ExistingEntity.Size;

            Console.Clear();
            DisplaySummary(ExistingEntity);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine($"\n[yellow]Antal sängar[/] (default {RoomType.NumberOfBedsDefault}): ");
            Data06 = RoomDetailsValidator.ValidateNumberOfBeds(RoomType, (int)Data05, true, PreviousMenu);
            if (CopyChecker.CheckCopyValue(Data06))
				Data06 = ExistingEntity.NumberOfBeds;

			Console.Clear();
			FormDisplayer.DisplayCurrentFormValues(this);
			AnsiConsole.MarkupLine($"\n[yellow]Pris[/] (Nuvarande: {ExistingEntity.Price}, default {RoomType.PriceDefault}): ");
			Data07 = UserInputHandler.UserInputDouble(PreviousMenu);
			if (CopyChecker.CheckCopyValue(Data07))
				Data07 = ExistingEntity.Price;
            if ((double)Data07 == 0) //If ExistingEntity.Price was 0, assign PriceDefault from RoomType
				Data07 = RoomType.PriceDefault;

			Console.Clear();
            Console.WriteLine("Tidigare värden: ");
            DisplaySummary(ExistingEntity);
            Console.WriteLine("Nya värden: ");
            FormDisplayer.DisplayCurrentFormValues(this);

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
			{
				NewEntity = new RoomDetails((IRoomType)Data01, (int)Data02, (int)Data05, (int)Data06, (double)Data07)
				{ ID = ExistingEntity.ID, UpdatedDate = DateTime.Now};

                //RoomDetailsService.Update(NewEntity);
                return NewEntity;
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);

                return ExistingEntity;
            }
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
            table.AddRow("Rumsnummer", (string)RelatedForm.Data01);
            table.AddRow("Beskrivning", (string)RelatedForm.Data02);
            table.AddRow("Våning", (string)RelatedForm.Data03);

            // RoomDetails
            table.AddRow("Rumstyp", (string)Data01);
            table.AddRow("Storlek", (string)Data02);
            table.AddRow("Antal sängar", (string)Data03);
            table.AddRow("Pris", (string)Data04);

            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Summary of existing customer information
        /// </summary>
        /// <param name="entity"></param>
        public void DisplaySummary(IRoomDetails entity)
        {
            // Visa sammanfattning
            Console.Clear();
            AnsiConsole.MarkupLine("\n[bold green]Sammanfattning:[/]");
            var table = new Table();
            table.AddColumn("[red]Fält[/]");
            table.AddColumn("[red]Värde[/]");
            table.AddRow("Rumsnummer", entity.Room.Name);
            table.AddRow("Beskrivning", entity.Room.Description);
            table.AddRow("Våning", entity.Room.Floor.ToString());
            table.AddRow("Rumstyp", entity.RoomType.Name);
            table.AddRow("Storlek", entity.Size.ToString());
            table.AddRow("Antal sängar", entity.NumberOfBeds.ToString());
            table.AddRow("Pris", entity.Price.ToString());
            AnsiConsole.Write(table);
        }
    }
}
