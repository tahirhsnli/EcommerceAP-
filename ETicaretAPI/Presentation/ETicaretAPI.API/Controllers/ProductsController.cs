using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository,IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(_productReadRepository.GetAll(false));
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

            //Order order = await _orderReadRepository.GetByIdAsync("5b1c9158-1ac9-4f81-a927-da85581e7bf3");
            //order.Address = "Qaradag Lokbatan";
            //await _orderWriteRepository.SaveAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id,false));
        }
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Stock = model.Stock,
                Price = model.Price,
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);   
        }
        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Name = model.Name;
            product.Stock = model.Stock;
            product.Price = model.Price;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> FindByIdAsync(string id, bool tracking = true)
        //{
        //    Product product = await _readRepository.GetByIdAsync(id,true);
        //    return Ok(product);
        //}
    }
}
