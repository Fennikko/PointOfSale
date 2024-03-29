using PointOfSale.Models;

namespace PointOfSale.Controllers;

public class CategoryController
{
    public static void AddCategory(Category category)
    {
        using var db = new ProductsContext();

        db.Add(category);

        db.SaveChanges();
    }

    public static void DeleteCategory(Category category)
    {
        using var db = new ProductsContext();

        db.Remove(category);
        db.SaveChanges();
    }

    public static List<Category> GetCategories()
    {
        using var db = new ProductsContext();

        var categories = db.Categories.ToList();

        return categories;
    }

    public static Category GetCategoryById(int id)
    {
        using var db = new ProductsContext();
        var category = db.Categories.SingleOrDefault(c => c.CategoryId == id);

        return category;
    }
}