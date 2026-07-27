public class CustomerWithOrders
{
    public string CustomerName{get; set;} = "";
    public List<Order> Orders{get; set;} = new();
}