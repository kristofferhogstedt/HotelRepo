using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.FactoryManagement;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Utilities;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Services;
using Hotel.src.ModelManagement.Utilities.Calculators;
using Hotel.src.ModelManagement.Validations;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelLibrary.Utilities.UserInputManagement;

namespace Hotel.src.ModelManagement.Controllers.Forms
{
    public class InvoiceRegistrationForm : IModelRegistrationForm, IInstantiable
    {
        private static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety
        public IMenu PreviousMenu { get; set; }
        public EModelType ModelType { get; set; } = EModelType.Invoice;
        public IModelRegistrationForm? RelatedForm { get; set; }
        public EModelType RelatedFormModelType { get; set; } 
        public IInvoice Invoice{ get; set; }
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
            _instance = InstanceGenerator.GetInstance<InvoiceRegistrationForm>(_instance, _lock, previousMenu);
            return (IModelRegistrationForm)_instance;
        }

        /// <summary>
        /// Not used for Invoices, creation is automatic
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IModel CreateForm()
        {
            throw new NotImplementedException();
        }

        public void EditForm(IModel entityToUpdate)
        {
            var ExistingInvoice = (IInvoice)entityToUpdate;
            IsAnEdit = true;

            IsAnEdit = false;
            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Är fakturan betald?[/]: ");
            Data01 = UserInputHandler.UserInputBool(PreviousMenu);

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                ExistingInvoice.IsPaid = true;
                ExistingInvoice.PaidDate = DateTime.Now;
                ExistingInvoice.UpdatedDate = DateTime.Now;
                InvoiceService.Delete(ExistingInvoice);
                AnsiConsole.MarkupLine("[bold green]Fakturaändring registrerad framgångsrikt![/]");
                PreviousMenu.Run();
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                CreateForm();
                PreviousMenu.Run();
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
            table.AddRow("Rumsnummer", (string)Data01);
            table.AddRow("Beskrivning", (string)Data02);
            table.AddRow("Våning", (string)Data03);

            // Room Details
            table.AddRow("Typ", (string)RelatedForm.Data01);
            table.AddRow("Storlek", (string)RelatedForm.Data02);
            table.AddRow("Antal sängar", (string)Data03);

            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Summary of existing customer information
        /// </summary>
        /// <param name="entity"></param>
        public void DisplaySummary(IRoom entity)
        {
            // Visa sammanfattning
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
            AnsiConsole.Write(table);
        }
    }
}
