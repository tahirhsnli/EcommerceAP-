using ETicaretAPI.Application.Repositories;
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
        public ProductsController(IProductReadRepository readRepository,IProductWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
        [HttpGet]
        public async void GetAsync()
        {
            await _writeRepository.AddRangeAsync(new()
            {
                new(){Id = Guid.NewGuid(),Name="Product1",Price=1000,Stock=20,Created = DateTime.UtcNow},
                new(){Id = Guid.NewGuid(),Name="Product2",Price=2000,Stock=30,Created = DateTime.UtcNow},
                new(){Id = Guid.NewGuid(),Name="Product3",Price=3000,Stock=40,Created = DateTime.UtcNow},
            });
            await _writeRepository.SaveAsync();
        }
    }
}
