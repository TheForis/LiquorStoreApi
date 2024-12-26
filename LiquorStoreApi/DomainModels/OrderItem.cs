namespace DomainModels
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; }
        public int BeverageId { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerOrderItem { get; set; } 
    }
}
