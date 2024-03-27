using PointOfSale;
using Spectre.Console;

var isAppRunning = true;

do
{
    var options = AnsiConsole.Prompt(
        new SelectionPrompt<MenuOptions>()
            .Title("What would you like to do?")
            .AddChoices(
                MenuOptions.AddProduct,
                MenuOptions.DeleteProduct,
                MenuOptions.UpdateProduct,
                MenuOptions.ViewProduct,
                MenuOptions.ViewAllProducts,
                MenuOptions.Quit));

    switch (options)
    {
        case MenuOptions.AddProduct:
           ProductService.InsertProduct();
            break;
        case MenuOptions.DeleteProduct:
            ProductService.DeleteProduct();
            break;
        case MenuOptions.UpdateProduct:
            ProductService.UpdateProduct();
            break;
        case MenuOptions.ViewProduct:
            ProductService.GetProductById();
            break;
        case MenuOptions.ViewAllProducts:
           ProductService.GetProducts();
            break;
        case MenuOptions.Quit:
            isAppRunning = false;
            Environment.Exit(0);
            break;
    }
} while (isAppRunning);

enum MenuOptions
{
    AddProduct,
    DeleteProduct,
    UpdateProduct,
    ViewProduct,
    ViewAllProducts,
    Quit
}