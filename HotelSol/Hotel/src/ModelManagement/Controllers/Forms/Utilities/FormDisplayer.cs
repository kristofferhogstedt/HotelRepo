using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Spectre.Console;

namespace Hotel.src.ModelManagement.Controllers.Forms.Utilities
{
    internal class FormDisplayer
    {
        /// <summary>
        /// Displays current form data for entity creation
        /// </summary>
        /// <param name="registrationForm"></param>
        public static void DisplayCurrentFormValues(IModelRegistrationForm registrationForm)
        {
            FormDisplayer.DisplayFormHeader();
            AnsiConsole.MarkupLine("\n[bold green]Sammanfattning av aktuell formulärdata:[/]");

            AnsiConsole.MarkupLine($"[green]{FormLabelMapper.LabelMapData01(registrationForm)}[/]: {registrationForm.Data01}");
            if (FormLabelMapper.LabelMapData02(registrationForm) != "")
                AnsiConsole.MarkupLine($"[green]{FormLabelMapper.LabelMapData02(registrationForm)}[/]: {registrationForm.Data02}");
            if (FormLabelMapper.LabelMapData03(registrationForm) != "")
                AnsiConsole.MarkupLine($"[green]{FormLabelMapper.LabelMapData03(registrationForm)}[/]: {registrationForm.Data03}");
            if (FormLabelMapper.LabelMapData04(registrationForm) != "")
                AnsiConsole.MarkupLine($"[green]{FormLabelMapper.LabelMapData04(registrationForm)}[/]: {registrationForm.Data04}");
            if (FormLabelMapper.LabelMapData05(registrationForm) != "")
                AnsiConsole.MarkupLine($"[green]{FormLabelMapper.LabelMapData05(registrationForm)}[/]: {registrationForm.Data05}");
            if (registrationForm.RelatedForm != null)
            {
                if (FormLabelMapper.LabelMapData01(registrationForm.RelatedForm) != "")
                    AnsiConsole.MarkupLine($"[green]{FormLabelMapper.LabelMapData01(registrationForm.RelatedForm)}[/]: {registrationForm.RelatedForm.Data01}");
                if (FormLabelMapper.LabelMapData02(registrationForm.RelatedForm) != "")
                    AnsiConsole.MarkupLine($"[green]{FormLabelMapper.LabelMapData02(registrationForm.RelatedForm)}[/]: {registrationForm.RelatedForm.Data02}");
                if (FormLabelMapper.LabelMapData03(registrationForm.RelatedForm) != "")
                    AnsiConsole.MarkupLine($"[green]{FormLabelMapper.LabelMapData03(registrationForm.RelatedForm)}[/]: {registrationForm.RelatedForm.Data03}");
                if (FormLabelMapper.LabelMapData04(registrationForm.RelatedForm) != "")
                    AnsiConsole.MarkupLine($"[green]{FormLabelMapper.LabelMapData04(registrationForm.RelatedForm)}[/]: {registrationForm.RelatedForm.Data04}");
            }
        }

        public static void DisplayFormHeader()
        {
            AnsiConsole.Markup("\n[bold green]Registrering[/]");
            AnsiConsole.WriteLine();
        }

    }
}
