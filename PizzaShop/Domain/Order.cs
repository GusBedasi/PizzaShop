namespace PizzaShop.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}