using Spectre.Console;

namespace PointOfSale;

public class ProductService
{
    public static void InsertProduct()
    {
        var product = new Product();
        product.Name = AnsiConsole.Ask<string>("Product's name:");
        product.Price = AnsiConsole.Ask<decimal>("Product's Price:");
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

    private static Product GetProductOptionInput()
    {
        var products = ProductController.GetProducts();
        var productsArray = products.Select(p => p.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose a Product")
            .AddChoices(productsArray));
        var id = products.Single(p => p.Name == option).Id;
        var product = ProductController.GetProductById(id);

        return product;
    }
}