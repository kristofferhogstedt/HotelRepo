using Hotel.src.ModelManagement.Models.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Displayers
{
    public class CustomerDisplayer
    {
        public static void DisplayModelTable(List<ICustomer> customers)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Förnamn");
            table.AddColumn("EfterNamn");
            table.AddColumn("E-Post");
            table.AddColumn("Telefon");

            foreach (var customer in customers)
            {
                table.AddRow(
                    customer.ID.ToString(),
                    customer.FirstName,
                    customer.LastName,
                    customer.Email,
                    customer.Phone
                    );
            }

            AnsiConsole.Write(table);

            Console.WriteLine("Valfri tangent för att återgå till huvudmeny");
            Console.ReadLine();
            Console.Clear();
        }

        public static void DisplayModel(ICustomer customer)
        {
            var panel = new Panel($@"
                Id: {customer.ID}
                Namn: {customer.FirstName}
                Namn: {customer.LastName}
                E-post: {customer.Email}
                Telefon: {customer.Phone}
            ");
            panel.Header = new PanelHeader("Product Info");
            panel.Padding = new Padding(2, 2, 2, 2);

            AnsiConsole.Write(panel);

            Console.WriteLine("Valfri tangent för att återgå till huvudmeny");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
