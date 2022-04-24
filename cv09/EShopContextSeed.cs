using cv09.Models;

namespace cv09
{
    public class EShopContextSeed
    {
        private static EShopContext _context;

        private static readonly Random _rnd = new();

        public static void Seed(EShopContext context)
        {
            _context = context;

            var isSeeded = context.Products.Any()
                           | context.Customers.Any()
                           | context.PriceHistories.Any()
                           | context.SaleHistory.Any();

            if (isSeeded)
            {
                return;
            }

            var products = CreateProducts();
            var customers = CreateCustomers();

            _context.SaveChanges();
            
            CreatePriceHistories(products);
            CreateSaleHistory(customers, products);

            _context.PriceHistories.Add(new PriceHistory
            {
                ProductId = 1,
                Product = products[0],
                Price = 0,
                Date = new DateTime(2020, 1, 1)
            });

            _context.SaveChanges();
        }

        private static List<Product> CreateProducts()
        {

            var products = new List<Product>();

            for (var i = 0; i < 10; i++)
            {
                var product = new Product
                {
                    Name = $"Product {i}",
                    Price = _rnd.Next(100, 1000)
                };

                products.Add(product);
            }

            _context.Products.AddRange(products);

            return products;
        }

        private static List<Customer> CreateCustomers()
        {
            
            var customers = new List<Customer>();

            for (var i = 0; i < 10; i++)
            {
                var customer = new Customer()
                {
                    Name = $"Customer {i}",
                    Surname = $"Surname {i}"
                };

                customers.Add(customer);
            }

            _context.Customers.AddRange(customers);

            return customers;
        }

        public static void CreatePriceHistories(List<Product> products)
        {
            var priceHistories = new List<PriceHistory>();

            foreach (var product in products)
            {
                for (var i = 0; i < 3; i++)
                {
                    priceHistories.Add(new PriceHistory()
                    {
                        Product = product,
                        Price = product.Price + _rnd.Next(-100, 100),
                        Date = DateTime.Now.AddMonths(- _rnd.Next(10, 20))
                    });

                }
            }

            _context.PriceHistories.AddRange(priceHistories);
        }

        private static void CreateSaleHistory(List<Customer> customers, List<Product> products)
        {
            var saleHistory = new List<SaleHistory>();

            foreach (var customer in customers)
            {
                for (var i = 0; i < _rnd.Next(1, 5); i++)
                {
                    var productId = _rnd.Next(1, 10);

                    saleHistory.Add(new SaleHistory()
                    {
                        Product = products[productId - 1],
                        CustomerId = customer.Id,
                        SaleDate = DateTime.Now.AddMonths(- _rnd.Next(5, 20))
                    });
                }
            }

            _context.SaleHistory.AddRange(saleHistory);
        }
    }
}
