namespace cv09.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        private ICollection<SaleHistory> _saleHistory;

        public virtual ICollection<SaleHistory> SaleHistory
        {
            get => _saleHistory ??= new HashSet<SaleHistory>();
            set => _saleHistory = value;
        }
    }
}