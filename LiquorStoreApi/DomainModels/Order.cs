namespace DomainModels
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public DateTime OrderTime => DateTime.Now;
        public decimal TotalOrderPrice { get; set; }

        public virtual ICollection<OrderItem> OrderItemId { get; set; }

        

    }
}
