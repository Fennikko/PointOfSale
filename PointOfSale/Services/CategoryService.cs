using PointOfSale.Controllers;
using PointOfSale.Models;
using Spectre.Console;

namespace PointOfSale.Services;

public class CategoryService
{
    public static void InsertCategory()
    {
        var category = new Category();
        category.Name = AnsiConsole.Ask<string>("Category's name: ");
        

        CategoryController.AddCategory(category);
    }

    public static void DeleteCategory()
    {
        var category = GetCategoryOptionInput();
        CategoryController.DeleteCategory(new Category{ CategoryId = category});
    }

    public static void GetCategories()
    {
        var categories = CategoryController.GetCategories();
        UserInterface.ShowCategoryTable(categories);
    }

    public static int GetCategoryOptionInput()
    {
        var categories = CategoryController.GetCategories();
        var categoriesArray = categories.Select(p => p.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose a category")
            .AddChoices(categoriesArray));
        var id = categories.Single(p => p.Name == option).CategoryId;

        return id;
    }
}