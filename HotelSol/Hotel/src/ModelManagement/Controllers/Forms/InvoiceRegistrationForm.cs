using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Menus;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Utilities;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
using HotelLibrary.Utilities.UserInputManagement;
using Spectre.Console;

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
        public IModelController ModelController { get; set; }
        public bool IsAnEdit { get; set; }
        public IInvoice NewEntity { get; set; }
        public bool GetRelatedObjects { get; set; } = true;

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
            _instance = InstanceGenerator.GetInstance<InvoiceRegistrationForm>(_instance, _lock, previousMenu);
            return (IModelRegistrationForm)_instance;
        }

        /// <summary>
        /// Not used for Invoices, creation is automatic
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public void CreateForm()
        {
            throw new NotImplementedException();
        }

        public void EditForm(IModel entityToUpdate)
        {
            var ExistingEntity = (IInvoice)entityToUpdate;
            IsAnEdit = true;
            NewEntity = ExistingEntity;

            Console.Clear();
            DisplaySummary(ExistingEntity);
            AnsiConsole.MarkupLine("\n[yellow]Är fakturan betald?[/]: ");
            Data01 = UserInputHandler.UserInputBool(PreviousMenu);
            if (CopyChecker.CheckCopyValue(Data01))
                Data01 = ExistingEntity.IsPaid;
            else if ((bool)Data01 == true)
            {
                NewEntity.IsPaid = (bool)Data01;
                NewEntity.PaidDate = DateTime.Now;
            }
            else
            {
                NewEntity.IsPaid = (bool)Data01;
                NewEntity.PaidDate = null;
            }


            Console.Clear();
            DisplaySummary(ExistingEntity);
            FormDisplayer.DisplayCurrentFormValues(this);
            Console.WriteLine();
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                NewEntity.UpdatedDate = DateTime.Now;

                InvoiceService.Update(NewEntity);
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
            var ExistingEntity = (IInvoice)entityToDelete;
            IsAnEdit = true;

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Godkänn inaktivering[/]: ");
            Data01 = UserInputHandler.UserInputBool(PreviousMenu);
            if ((bool)Data01 == true)
            {
                InvoiceService.Delete(ExistingEntity);
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
            throw new NotImplementedException();
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

            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Summary of existing customer information
        /// </summary>
        /// <param name="entity"></param>
        public void DisplaySummary(IInvoice entity)
        {
            Console.Clear();
            AnsiConsole.MarkupLine("\n[bold green]Sammanfattning av kundinformation:[/]");
            var table = new Table();
            table.AddColumn("[red]Fält[/]");
            table.AddColumn("[red]Värde[/]");
            table.AddRow("Belopp", entity.Amount.ToString());
            table.AddRow("Förfallodatum", entity.DueDate.ToShortDateString());
            table.AddRow("Är betald?", entity.IsPaid.ToString());
            AnsiConsole.Write(table);
        }
    }
}
