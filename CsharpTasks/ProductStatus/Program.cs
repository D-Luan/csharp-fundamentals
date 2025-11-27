namespace EcommerceTasks;

internal class Program
{
    static void Main(string[] args)
    {
        Product playstation5 = new Product("Playstation 5", null);

        StockService statusProduct = new StockService();

        var status = statusProduct.GetStockStatus(playstation5);

        Console.WriteLine(status);

        Customer customerInformation = new Customer("Lucas", "Microsoft");

        var serviceTag = new ServiceTag();

        var customerName = serviceTag.GetEnterpriseName(customerInformation);

        Console.WriteLine(customerName);
    }
}
