using PointOfSale.Models;
using PointOfSale.Models.DTOs;
using PointOfSale.Services;
using Spectre.Console;

namespace PointOfSale.Controllers;

public class OrderService
{
    public static void InsertOrder()
    {
        var orderProducts = GetProductsForOrder();

        OrderController.AddOrder(orderProducts);
    }

    private static List<OrderProduct> GetProductsForOrder()
    {
        var products = new List<OrderProduct>();
        var order = new Order
        {
            CreatedDate = DateTime.Now
        };
        var isOrderFinished = false;

        do
        {
            var product = ProductService.GetProductOptionInput();
            var quantity = AnsiConsole.Ask<int>("How many? : ");

            order.TotalPrice = order.TotalPrice + (quantity * product.Price);

            products.Add(
                new OrderProduct
                {
                    Order = order,
                    ProductId = product.ProductId,
                    Quantity = quantity,
                });

            isOrderFinished = !AnsiConsole.Confirm("Would you like to add more products?");
        } while (!isOrderFinished);

        return products;
    }

    public static void GetOrders()
    {
        var orders = OrderController.GetOrders();

        UserInterface.ShowOrderTable(orders);
    }

    public static void GetOrder()
    {
        var order = GetOrderOptionInput();
        var products = order.OrderProducts
            .Select(x => new ProductForOrderViewDTO
            {
                Id = x.ProductId,
                Name = x.Product.Name,
                CategoryName = x.Product.Category.Name,
                Quantity = x.Quantity,
                Price = x.Product.Price,
                TotalPrice = x.Quantity * x.Product.Price
            })
            .ToList();

        UserInterface.ShowOrder(order);
        UserInterface.ShowProductForOrderTable(products);
    }

    private static Order GetOrderOptionInput()
    {
        var orders = OrderController.GetOrders();
        var orderArray = orders.Select(o => $"{o.OrderId}.{o.CreatedDate} - " +
                                            $"{o.TotalPrice}").ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Order")
            .AddChoices(orderArray));
        var idArray = option.Split('.');
        var order = orders.Single(o => o.OrderId == Int32.Parse(idArray
            [0]));

        return order;
    }
}