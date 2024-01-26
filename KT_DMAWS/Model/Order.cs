namespace KT_DMAWS.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipPhone { get; set; }
        public decimal PriceQuantity { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime DeliveryTime { get; set; } 
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
