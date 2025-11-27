namespace EcommerceTasks;

public class ServiceTag
{
    public string? GetEnterpriseName(Customer customer)
    {
        return customer?.Enterprise?.Name;
    }
}
