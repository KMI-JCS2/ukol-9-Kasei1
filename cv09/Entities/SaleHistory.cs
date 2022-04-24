namespace cv09.Models
{
    public class SaleHistory
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
