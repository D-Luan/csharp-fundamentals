namespace EcommerceTasks;

public class StockService
{
    public string GetStockStatus(Product product)
    {
        if (product.StockQuantity == null)
        {
            return "Status: Checking Status";
        }

        if (product.StockQuantity == 0)
        {
            return "Status: Sold Out";
        }

        return $"Status: Available ({product.StockQuantity} units)";
    }
}
