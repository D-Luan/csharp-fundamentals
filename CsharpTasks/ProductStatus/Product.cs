namespace EcommerceTasks;

public class Product
{
    public string Name { get; set; }
    public int? StockQuantity { get; set; }

    public Product(string name, int? stock)
    {
        this.Name = name;
        this.StockQuantity = stock;
    }
}
