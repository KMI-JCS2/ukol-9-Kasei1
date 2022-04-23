namespace cv09.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        private ICollection<PriceHistory> _priceHistory;

        public virtual ICollection<PriceHistory> PriceHistory
        {
            get => _priceHistory ??= new HashSet<PriceHistory>();
            set => _priceHistory = value;
        }

    }
}
