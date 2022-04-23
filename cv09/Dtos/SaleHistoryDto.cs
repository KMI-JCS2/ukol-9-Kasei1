namespace cv09.Dtos
{
    public class SaleHistoryDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
