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

            AnsiConsole.MarkupLine($"[green]{FormLabelMapper.LabelMapData01(registrationForm)}[/]: {registrationForm.Data01}");
            AnsiConsole.MarkupLine($"[green]{FormLabelMapper.LabelMapData02(registrationForm)}[/]: {registrationForm.Data02}");
            AnsiConsole.MarkupLine($"[green]{FormLabelMapper.LabelMapData03(registrationForm)}[/]: {registrationForm.Data03}");
            AnsiConsole.MarkupLine($"[green]{FormLabelMapper.LabelMapData04(registrationForm)}[/]: {registrationForm.Data04}");
            AnsiConsole.MarkupLine($"[green]{FormLabelMapper.LabelMapData05(registrationForm)}[/]: {registrationForm.Data05}");
            if (registrationForm.RelatedForm != null)
            {
                AnsiConsole.MarkupLine($"[green]{FormLabelMapper.LabelMapData01(registrationForm.RelatedForm)}[/]: {registrationForm.RelatedForm.Data01}");
                AnsiConsole.MarkupLine($"[green]{FormLabelMapper.LabelMapData02(registrationForm.RelatedForm)}[/]: {registrationForm.RelatedForm.Data02}");
                AnsiConsole.MarkupLine($"[green]{FormLabelMapper.LabelMapData03(registrationForm.RelatedForm)}[/]: {registrationForm.RelatedForm.Data03}");
                AnsiConsole.MarkupLine($"[green]{FormLabelMapper.LabelMapData04(registrationForm.RelatedForm)}[/]: {registrationForm.RelatedForm.Data04}");
            }
        }

        public static void DisplayFormHeader()
        {
            AnsiConsole.Markup("\n[bold green]Kundregistrering[/]");
            AnsiConsole.WriteLine();
        }

    }
}
