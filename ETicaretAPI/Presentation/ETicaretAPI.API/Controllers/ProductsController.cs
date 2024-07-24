using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _readRepository;
        private readonly IProductWriteRepository _writeRepository;

        private readonly IOrderWriteRepository _orderWriteRepository;

        public ProductsController(IProductReadRepository readRepository,IProductWriteRepository writeRepository,IOrderWriteRepository orderWriteRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _orderWriteRepository = orderWriteRepository;
        }
        [HttpGet]
        public async Task GetAsync()
        {
            //await _writeRepository.AddRangeAsync(new()
            //{
            //    new(){Id = Guid.NewGuid(),Name="Product1",Price=1000,Stock=20,Created = DateTime.UtcNow},
            //    new(){Id = Guid.NewGuid(),Name="Product2",Price=2000,Stock=30,Created = DateTime.UtcNow},
            //    new(){Id = Guid.NewGuid(),Name="Product3",Price=3000,Stock=40,Created = DateTime.UtcNow},
            //});
            //await _writeRepository.SaveAsync();

            //Product product = await _readRepository.GetByIdAsync("43565798-4638-494e-8f58-02faede51aa4");
            //product.Price = 1221;
            //await _writeRepository.SaveAsync();

            await _orderWriteRepository.AddAsync(new() { Description = "Bomba kimi", Address = "Qaradag" });
            await _orderWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindByIdAsync(string id, bool tracking = true)
        {
            Product product = await _readRepository.GetByIdAsync(id,true);
            return Ok(product);
        }
    }
}
