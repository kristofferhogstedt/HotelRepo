using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Utilities;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.Utilities.UserInputManagement.RegexManagement;
using Hotel.src.Utilities.UserInputManagement;
using HotelLibrary.Utilities.UserInputManagement;
using Microsoft.IdentityModel.Tokens;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.src.ModelManagement.Utilities.Displayers.Interfaces;
using Hotel.src.ModelManagement.Utilities.Displayers;

namespace Hotel.src.ModelManagement.Controllers.Forms
{
    //public class ModelRegistrationForm : IModelRegistrationForm, IInstantiable
    //{
    //    public IMenu PreviousMenu { get; set; }
    //    private static IInstantiable _instance;
    //    private static readonly object _lock = new object(); // Lock object for thread safety
    //    public object Data01 { get; set; }
    //    public object Data02 { get; set; }
    //    public object Data03 { get; set; }
    //    public object Data04 { get; set; }
    //    public object Data05 { get; set; }
    //    public object Data06 { get; set; }
    //    public object Data07 { get; set; }
    //    public object Data08 { get; set; }
    //    public object Data09 { get; set; }
    //    public object Data10 { get; set; }
    //    public IModelRegistrationForm SubForm { get; set; }
    //    public EModelType ModelType { get; set; }
    //    public IModel Model { get; set; }

    //    public static IModelRegistrationForm GetInstance(IMenu previousMenu)
    //    {
    //        _instance = InstanceGenerator.GetInstance<ModelRegistrationForm>(_instance, _lock, previousMenu);
    //        return (IModelRegistrationForm)_instance;
    //    }

    //    public IModel CreateForm()
    //    {

    //    }

    //    public IModel EditForm(IModel modelToUpdate)
    //    {
    //        Model = (IModel)modelToUpdate;

    //        Console.Clear();
    //        DisplaySummary(Model);
    //        FormDisplayer.DisplayCurrentFormValues(this);
    //        AnsiConsole.MarkupLine("\nAnge [yellow]förnamn[/]: ");
    //        Data01 = UserInputHandler.UserInputString(PreviousMenu);
    //        if (Data01.ToString().IsNullOrEmpty())
    //            Data01 = Model.GetType().;

    //        Console.Clear();
    //        DisplaySummary(Model);
    //        FormDisplayer.DisplayCurrentFormValues(this);
    //        AnsiConsole.MarkupLine("\nAnge [yellow]efternamn[/]: ");
    //        Data02 = UserInputHandler.UserInputString(PreviousMenu);
    //        if (Data02.ToString().IsNullOrEmpty())
    //            Data02 = Model.LastName;

    //        Console.Clear();
    //        DisplaySummary(Model);
    //        FormDisplayer.DisplayCurrentFormValues(this);
    //        AnsiConsole.MarkupLine("\nAnge [yellow]födelseår[/]: ");
    //        var _yearOfBirth = UserInputHandlerDateTime.UserInputYear(PreviousMenu);
    //        if (_yearOfBirth == 0)
    //            _yearOfBirth = Model.DateOfBirth.Year;

    //        AnsiConsole.MarkupLine("\nAnge [yellow]födelsemånad[/]: ");
    //        var _monthOfBirth = UserInputHandlerDateTime.UserInputMonth(PreviousMenu);
    //        if (_monthOfBirth == 0)
    //            _monthOfBirth = Model.DateOfBirth.Month;

    //        AnsiConsole.MarkupLine("\nAnge [yellow]födelsedag[/]: ");
    //        var _dayOfBirth = UserInputHandlerDateTime.UserInputMonth(PreviousMenu);
    //        if (_dayOfBirth == 0)
    //            _dayOfBirth = Model.DateOfBirth.Day;

    //        Data03 = Convert.ToDateTime($"{_yearOfBirth}-{_monthOfBirth}-{_dayOfBirth}");
    //        if (Data03.ToString().IsNullOrEmpty())
    //            Data03 = Model.DateOfBirth;

    //        Console.Clear();
    //        DisplaySummary(Model);
    //        FormDisplayer.DisplayCurrentFormValues(this);
    //        AnsiConsole.MarkupLine("\nAnge [yellow]E-post[/]: ");
    //        Data04 = UserInputRegexHandler.UserInputRegexEmail(PreviousMenu);
    //        if (Data04.ToString().IsNullOrEmpty())
    //            Data04 = Model.Email;

    //        Console.Clear();
    //        DisplaySummary(Model);
    //        FormDisplayer.DisplayCurrentFormValues(this);
    //        AnsiConsole.MarkupLine("\nAnge [yellow]telefonnummer[/]: ");
    //        Data05 = UserInputRegexHandler.UserInputRegexPhone(PreviousMenu);
    //        if (Data05.ToString().IsNullOrEmpty())
    //            Data05 = Model.Phone;

    //        AnsiConsole.MarkupLine("Uppdatera [yellow]adress[/]?");
    //        if (UserInputHandler.UserInputBool(PreviousMenu))
    //        {
    //            // Address registration form
    //            var _addressForm = AddressRegistrationForm.GetInstance(PreviousMenu);

    //            // If customer exists, and an address, edit it. If not, create a new one.
    //            if (Model != null)
    //            {
    //                if (Model.Address != null)
    //                    Data06 = (IAddress)_addressForm.EditForm(this.Model.Address);
    //                else
    //                    Data06 = (IAddress)_addressForm.CreateForm();
    //            }
    //            else
    //                Data06 = (IAddress)_addressForm.CreateForm();
    //        }

    //        Console.Clear();
    //        DisplaySummary(Model);
    //        FormDisplayer.DisplayCurrentFormValues(this);

    //        // Bekräfta kunduppgifter
    //        bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

    //        if (confirm)
    //        {
    //            // Meddelande om lyckad registrering
    //            AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
    //            this.Model = new Customer((string)Data01, (string)Data02, (DateTime)Data03, (string)Data04, (string)Data05, (Address)Data06);
    //            return (IModel)this.Model;
    //        }
    //        else
    //        {
    //            // Meddelande om avbryta
    //            AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
    //            Thread.Sleep(2000);
    //            EditForm(modelToUpdate);
    //            return (IModel)this.Model;
    //        }
    //    }
    //    //public void DisplaySummary(IModel entity)
    //    //{
    //    //    // Visa sammanfattning
    //    //    Console.Clear();
    //    //    AnsiConsole.MarkupLine("\n[bold green]Sammanfattning av kundinformation:[/]");
    //    //    var table = new Table();
    //    //    table.AddColumn("[red]Fält[/]");
    //    //    table.AddColumn("[red]Värde[/]");
    //    //    table.AddRow("Förnamn", entity.FirstName);
    //    //    table.AddRow("Efternamn", entity.LastName);
    //    //    table.AddRow("Födelsedatum", entity.DateOfBirth.ToString());
    //    //    table.AddRow("E-post", entity.Email);
    //    //    table.AddRow("Telefonnummer", entity.Phone);
    //    //    if (entity.Address == null)
    //    //        table.AddRow("Adress", "Ej angiven");
    //    //    else
    //    //        table.AddRow("Adress", $"{entity.Address.StreetAddress} {entity.Address.PostalCode} {entity.Address.City}{entity.Address.Country}");
    //    //    AnsiConsole.Write(table);
    //    //}

    //    public void DisplaySummary(IModel entity)
    //    {
    //        ModelInfoDisplayer.DisplayModelInfo(entity);
    //    }
    //}
}
