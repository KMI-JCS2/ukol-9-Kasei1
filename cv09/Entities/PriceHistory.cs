namespace cv09.Models
{
    public class PriceHistory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
