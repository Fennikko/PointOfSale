
using Spectre.Console;

namespace PointOfSale;

public static class UserInterface
{

    public static void ShowProductTable(List<Product> products)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Price");


        foreach (var product in products)
        {
            table.AddRow(
                product.Id.ToString(), 
                product.Name, 
                product.Price.ToString()
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        AnsiConsole.Clear();
    }

    public static void ShowProduct(Product product)
    {
        var panel = new Panel($"""
                               Id: {product.Id}
                               Name: {product.Name}
                               """);
        panel.Header = new PanelHeader("Product Info");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        AnsiConsole.Clear();
    }
}