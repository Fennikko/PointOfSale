
using PointOfSale.Models;
using PointOfSale.Services;
using Spectre.Console;

namespace PointOfSale;

public static class UserInterface
{
    public static void MainMenu()
    {
        var isAppRunning = true;

        do
        {
            AnsiConsole.Clear();
            var options = AnsiConsole.Prompt(
                new SelectionPrompt<enums.MenuOptions>()
                    .Title("What would you like to do?")
                    .AddChoices(
                        enums.MenuOptions.AddCategory,
                        enums.MenuOptions.DeleteCategory,
                        enums.MenuOptions.ViewAllCategories,
                        enums.MenuOptions.AddProduct,
                        enums.MenuOptions.DeleteProduct,
                        enums.MenuOptions.UpdateProduct,
                        enums.MenuOptions.ViewProduct,
                        enums.MenuOptions.ViewAllProducts,
                        enums.MenuOptions.Quit));

            switch (options)
            {
                case enums.MenuOptions.AddCategory:
                    CategoryService.InsertCategory();
                    break;
                case enums.MenuOptions.DeleteCategory:
                    CategoryService.DeleteCategory(); 
                    break;
                case enums.MenuOptions.ViewAllCategories:
                    CategoryService.GetCategories();
                    break;
                case enums.MenuOptions.AddProduct:
                    ProductService.InsertProduct();
                    break;
                case enums.MenuOptions.DeleteProduct:
                    ProductService.DeleteProduct();
                    break;
                case enums.MenuOptions.UpdateProduct:
                    ProductService.UpdateProduct();
                    break;
                case enums.MenuOptions.ViewProduct:
                    ProductService.GetProductById();
                    break;
                case enums.MenuOptions.ViewAllProducts:
                    ProductService.GetProducts();
                    break;
                case enums.MenuOptions.Quit:
                    isAppRunning = false;
                    Environment.Exit(0);
                    break;
            }
        } while (isAppRunning);
    }

    public static void ShowProductTable(List<Product> products)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Price");
        table.AddColumn("Category");


        foreach (var product in products)
        {
            table.AddRow(
                product.ProductId.ToString(), 
                product.Name, 
                product.Price.ToString(),
                product.Category.Name
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
                               Id: {product.ProductId}
                               Name: {product.Name}
                               Category: {product.Category.Name}
                               """);
        panel.Header = new PanelHeader("Product Info");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        AnsiConsole.Clear();
    }

    public static void ShowCategoryTable(List<Category> categories)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Price");


        foreach (var category in categories)
        {
            table.AddRow(
                category.CategoryId.ToString(), 
                category.Name
            );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        AnsiConsole.Clear();
    }

    public static void ShowCategory(Category category)
    {
        var panel = new Panel($"""
                               Id: {category.CategoryId}
                               Name: {category.Name}
                               """);
        panel.Header = new PanelHeader("Category Info");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        AnsiConsole.Clear();
    }
}