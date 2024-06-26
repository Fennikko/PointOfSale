﻿using PointOfSale.Controllers;
using PointOfSale.Models;
using Spectre.Console;

namespace PointOfSale.Services;

public class ProductService
{
    public static void InsertProduct()
    {
        var product = new Product();
        product.Name = AnsiConsole.Ask<string>("Product's name:");
        product.Price = AnsiConsole.Ask<decimal>("Product's Price:");
        product.CategoryId = CategoryService.GetCategoryOptionInput().CategoryId;
        ProductController.AddProduct(product);
    }

    public static void DeleteProduct()
    {
        var product = GetProductOptionInput();
        ProductController.DeleteProduct(product);
    }

    public static void UpdateProduct()
    {
        var product = GetProductOptionInput();
        product.Name = AnsiConsole.Confirm("Update name?")
            ? AnsiConsole.Ask<string>("Product's new name: ")
            : product.Name;

        product.Price = AnsiConsole.Confirm("Update price?")
            ? AnsiConsole.Ask<decimal>("Product's new price: ")
            : product.Price;

        product.Category = AnsiConsole.Confirm("Update category?")
            ? CategoryService.GetCategoryOptionInput()
            : product.Category;

        ProductController.UpdateProduct(product);
    }

    public static void GetProducts()
    {
        var products = ProductController.GetProducts();
        UserInterface.ShowProductTable(products);
    }

    public static void GetProductById()
    {
        var product = GetProductOptionInput();
        UserInterface.ShowProduct(product);
    }

    public static Product GetProductOptionInput()
    {
        var products = ProductController.GetProducts();
        var productsArray = products.Select(p => p.Name).ToArray();
        if (!productsArray.Any())
        {
            AnsiConsole.Write("No products found, press any key to return to the main menu.");
            Console.ReadKey();
            UserInterface.MainMenu();
        }
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose a Product")
            .AddChoices(productsArray));
        var id = products.Single(p => p.Name == option).ProductId;
        var product = ProductController.GetProductById(id);

        return product;
    }

}