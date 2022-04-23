using AutoMapper;
using AutoMapper.QueryableExtensions;
using cv09.Dtos;
using cv09.Models;
using cv09.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cv09.Services
{
    public class EShopService : IEShopService
    {
        private EShopContext _context;
        private IMapper _mapper;

        public EShopService(EShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public ProductDto GetProduct(int id)
        {
            var product = _context.Products
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);

            var dto = _mapper.Map<ProductDto>(product);

            return dto;
        }
        public List<PriceHistoryDto> GetPriceHistories(int id)
        {
            var query = _context.PriceHistories
                .AsNoTracking()
                .Where(ph => ph.ProductId == id)
                .OrderBy(ph => ph.Date)
                .ProjectTo<PriceHistoryDto>(_mapper.ConfigurationProvider);

            var priceHistories = query.ToList();

            return priceHistories;
        }

        public List<SaleHistoryDto> GetSaleHistory(int id)
        {
            var query = _context.SaleHistory
                .AsNoTracking()
                .Where(sh => sh.ProductId == id)
                .OrderBy(sh => sh.SaleDate)
                .ProjectTo<SaleHistoryDto>(_mapper.ConfigurationProvider);

            var saleHistories = query.ToList();

            return saleHistories;
        }

        public List<ProductBasicDto> GetAllProducts(int? maxCount)
        {
            var query = _context.Products
                .AsNoTracking()
                .OrderBy(p => p.Name)
                .ProjectTo<ProductBasicDto>(_mapper.ConfigurationProvider);

            if (maxCount.HasValue)
            {
                query = query.Take(maxCount.Value);
            }

            var products = query.ToList();

            return products;
        }

        public void CreateProduct(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
