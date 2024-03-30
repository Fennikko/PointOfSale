namespace PointOfSale;

public class enums
{
    public enum MainMenuOptions
    {
        ManageCategories,
        ManageProducts,
        ManageOrders,
        Quit
    }

    public enum CategoryMenu
    {
        AddCategory,
        DeleteCategory,
        UpdateCategory,
        ViewCategory,
        ViewAllCategories,
        GoBack
    }

    public enum ProductMenu
    {
        AddProduct,
        DeleteProduct,
        UpdateProduct,
        ViewProduct,
        ViewAllProducts,
        GoBack
    }

    public enum OrderMenu
    {
        AddOrder,
        GetOrders,
        GetOrder,
        GoBack
    }
}