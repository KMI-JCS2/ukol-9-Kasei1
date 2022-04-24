using cv09.Dtos;
using cv09.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cv09.Controllers
{
    [ApiController]
    [Route("api/eShop")]
    public class EShopController : ControllerBase
    {
        private IEShopService _service;

        public EShopController(IEShopService service)
        {
            _service = service;
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult CreateProduct([FromBody] CreateProductDto product)
        {
            _service.CreateProduct(product);
            return NoContent();
        }

        [HttpGet]
        public List<ProductBasicDto> GetProducts([FromQuery] int? maxCount)
            => _service.GetAllProducts(maxCount);


        [HttpGet("{id}")]
        public ProductDto Get([FromRoute] int id)
        {
            var product = _service.GetProduct(id);
            
            product.PriceHistory = _service.GetPriceHistories(id);
            product.SaleHistory = _service.GetSaleHistory(id);

            return product;
        }
    }
}
