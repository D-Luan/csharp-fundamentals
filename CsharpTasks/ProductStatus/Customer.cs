namespace EcommerceTasks;

public class Customer
{
    public string Name { get; set; }
    public string Enterprise { get; set; }

    public Customer(string name, string enterprise)
    {
        this.Name = name;
        this.Enterprise = enterprise;
    }
}
