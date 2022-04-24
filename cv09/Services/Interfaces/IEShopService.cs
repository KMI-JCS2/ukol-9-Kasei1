using cv09.Dtos;

namespace cv09.Services.Interfaces
{
    public interface IEShopService
    {
        ProductDto GetProduct(int id);

        List<ProductBasicDto> GetAllProducts(int? maxCount);

        List<PriceHistoryDto> GetPriceHistories(int id);

        List<SaleHistoryDto> GetSaleHistory(int id);

        void CreateProduct(CreateProductDto dto);
    }
}
