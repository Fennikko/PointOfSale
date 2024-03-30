
using PointOfSale.Models;
using PointOfSale.Services;
using Spectre.Console;
using System;

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
                new SelectionPrompt<enums.MainMenuOptions>()
                    .Title("What would you like to do?")
                    .AddChoices(
                        enums.MainMenuOptions.ManageCategories,
                        enums.MainMenuOptions.ManageProducts,
                        enums.MainMenuOptions.Quit));

            switch (options)
            {
                case enums.MainMenuOptions.ManageCategories:
                    CategoryMenu();
                    break;
                case enums.MainMenuOptions.ManageProducts:
                    ProductMenu(); 
                    break;
                case enums.MainMenuOptions.Quit:
                    isAppRunning = false;
                    Environment.Exit(0);
                    break;
            }
        } while (isAppRunning);
    }

    public static void CategoryMenu()
    {
        var categoryMenuRunning = true;

        do
        {
            AnsiConsole.Clear();
            var options = AnsiConsole.Prompt(
                new SelectionPrompt<enums.CategoryMenu>()
                    .Title("What would you like to do?")
                    .AddChoices(
                        enums.CategoryMenu.AddCategory,
                        enums.CategoryMenu.DeleteCategory,
                        enums.CategoryMenu.UpdateCategory,
                        enums.CategoryMenu.ViewCategory,
                        enums.CategoryMenu.ViewAllCategories,
                        enums.CategoryMenu.GoBack));

            switch (options)
            {
                case enums.CategoryMenu.AddCategory:
                    CategoryService.InsertCategory();
                    break;
                case enums.CategoryMenu.DeleteCategory:
                    CategoryService.DeleteCategory(); 
                    break;
                case enums.CategoryMenu.UpdateCategory:
                    CategoryService.UpdateCategory();
                    break;
                case enums.CategoryMenu.ViewCategory:
                    CategoryService.GetCategory();
                    break;
                case enums.CategoryMenu.ViewAllCategories:
                    CategoryService.GetCategories();
                    break;
                case enums.CategoryMenu.GoBack:
                    categoryMenuRunning = false;
                    MainMenu();
                    break;
            }
        } while (categoryMenuRunning);
    }

    public static void ProductMenu()
    {
        var productMenuRunning = true;

        do
        {
            AnsiConsole.Clear();
            var options = AnsiConsole.Prompt(
                new SelectionPrompt<enums.ProductMenu>()
                    .Title("What would you like to do?")
                    .AddChoices(
                        enums.ProductMenu.AddProduct,
                        enums.ProductMenu.DeleteProduct,
                        enums.ProductMenu.UpdateProduct,
                        enums.ProductMenu.ViewProduct,
                        enums.ProductMenu.ViewAllProducts,
                        enums.ProductMenu.GoBack));

            switch (options)
            {
                case enums.ProductMenu.AddProduct:
                    ProductService.InsertProduct();
                    break;
                case enums.ProductMenu.DeleteProduct:
                    ProductService.DeleteProduct();
                    break;
                case enums.ProductMenu.UpdateProduct:
                    ProductService.UpdateProduct();
                    break;
                case enums.ProductMenu.ViewProduct:
                    ProductService.GetProductById();
                    break;
                case enums.ProductMenu.ViewAllProducts:
                    ProductService.GetProducts();
                    break;
                case enums.ProductMenu.GoBack:
                    productMenuRunning = false;
                    MainMenu();
                    break;
            }
        } while (productMenuRunning);
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
                               Products {category.Products.Count}
                               """);
        panel.Header = new PanelHeader("Category Info");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        ShowProductTable(category.Products);

    }
}