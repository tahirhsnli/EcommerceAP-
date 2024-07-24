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
        private readonly IOrderReadRepository _orderReadRepository;

        private readonly ICustomerWriteRepository _customerWriteRepository;

        public ProductsController(IProductReadRepository readRepository,IProductWriteRepository writeRepository,IOrderWriteRepository orderWriteRepository,ICustomerWriteRepository customerWriteRepository,IOrderReadRepository orderReadRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
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

            //Guid customerId = Guid.NewGuid();
            //await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Frank" });
            //await _orderWriteRepository.AddAsync(new() { Description = "Bomba kimi", Address = "Qaradag",CustomerId = customerId });
            //await _orderWriteRepository.SaveAsync();

            Order order = await _orderReadRepository.GetByIdAsync("5b1c9158-1ac9-4f81-a927-da85581e7bf3");
            order.Address = "Qaradag Lokbatan";
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
