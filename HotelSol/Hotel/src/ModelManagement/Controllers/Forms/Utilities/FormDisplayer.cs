using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Controllers.Forms.Utilities
{
    internal class FormDisplayer
    {
        public static void DisplayCurrentFormValues(IModelRegistrationForm registrationForm)
        {
            FormDisplayer.DisplayFormHeader();
            AnsiConsole.MarkupLine("\n[bold green]Sammanfattning av aktuell formulärdata:[/]");

            AnsiConsole.MarkupLine($"[green]{FormLabelMapper.CustomerLabelMapData01(registrationForm)}[/]: {registrationForm.Data01}");
            AnsiConsole.MarkupLine($"[green]{FormLabelMapper.CustomerLabelMapData02(registrationForm)}[/]: {registrationForm.Data02}");
            AnsiConsole.MarkupLine($"[green]{FormLabelMapper.CustomerLabelMapData03(registrationForm)}[/]: {registrationForm.Data03}");
            AnsiConsole.MarkupLine($"[green]{FormLabelMapper.CustomerLabelMapData04(registrationForm)}[/]: {registrationForm.Data04}");
            AnsiConsole.MarkupLine($"[green]{FormLabelMapper.CustomerLabelMapData05(registrationForm)}[/]: {registrationForm.Data05}");
            if (registrationForm.SubForm != null)
            {
                AnsiConsole.MarkupLine($"[green]{FormLabelMapper.CustomerLabelMapData01(registrationForm.SubForm)}[/]: {registrationForm.SubForm.Data01}");
                AnsiConsole.MarkupLine($"[green]{FormLabelMapper.CustomerLabelMapData02(registrationForm.SubForm)}[/]: {registrationForm.SubForm.Data02}");
                AnsiConsole.MarkupLine($"[green]{FormLabelMapper.CustomerLabelMapData03(registrationForm.SubForm)}[/]: {registrationForm.SubForm.Data03}");
                AnsiConsole.MarkupLine($"[green]{FormLabelMapper.CustomerLabelMapData04(registrationForm.SubForm)}[/]: {registrationForm.SubForm.Data04}");
            }
        }

        public static void DisplayFormHeader()
        {
            AnsiConsole.Markup("\n[bold green]Kundregistrering[/]");
            AnsiConsole.WriteLine();
        }

    }
}
