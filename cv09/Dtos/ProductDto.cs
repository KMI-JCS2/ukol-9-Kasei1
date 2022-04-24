using cv09.Models;

namespace cv09.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<PriceHistoryDto> PriceHistory { get; set; }
        public ICollection<SaleHistoryDto> SaleHistory { get; set; }
    }
}
