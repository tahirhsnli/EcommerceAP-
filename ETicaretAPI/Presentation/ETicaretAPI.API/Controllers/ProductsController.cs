using ETicaretAPI.Application.Features.Commands.Products.PutProduct;
using ETicaretAPI.Application.Features.Commands.Products.CreateProduct;
using ETicaretAPI.Application.Features.Commands.Products.DeleteProduct;
using ETicaretAPI.Application.Features.Commands.Products.PutProduct;
using ETicaretAPI.Application.Features.Queries.Products.GetAllProduct;
using ETicaretAPI.Application.Features.Queries.Products.GetByIdProduct;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.RequestParameters;
using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ETicaretAPI.Application.Services;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IWebHostEnvironment _webHostEnvironment; // 
        private readonly IMediator _mediator;
        private readonly IFileService _fileService;
        public ProductsController(IMediator mediator,IWebHostEnvironment webHostEnvironment, IFileService fileService)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {

            GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
            return Ok(response);


            //await Task.Delay(1000);
            //var totalCount = _productReadRepository.GetAll(false).Count();

            //var products = _productReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(p => new
            //{
            //    p.Id,
            //    p.Name,
            //    p.Stock,
            //    p.Price,
            //    p.CreatedDate,
            //    p.UpdatedDate
            //}).ToList();

            //return Ok(new
            //{
            //    totalCount,
            //    products
            //});


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
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute]GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);   
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PutProductCommandRequest putProductCommandRequest)
        {
            PutProductCommandResponse response = await _mediator.Send(putProductCommandRequest);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute]DeleteProductCommandRequest deleteProductCommandRequest)
        {
            DeleteProductCommandResponse response = await _mediator.Send(deleteProductCommandRequest);
            return Ok(deleteProductCommandRequest);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload(IFormFileCollection formFiles)
        {
            await _fileService.UploadAsync("resource\\product-image",formFiles);
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
