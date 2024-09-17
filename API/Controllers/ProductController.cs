using API.Models.DTOs;
using API.Models.Entities;
using API.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IServiceProduct _service;
        private readonly IMapper _mapper;


        public ProductController(IServiceProduct service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("get-product/{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var product = await _service.GetAsync(id);
            var productsResponse = _mapper.Map<ProductDTO>(product);

            return Ok(productsResponse);
        }

        [HttpGet("get-all-products")]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _service.GetAllAsync();

            return products.Any()
                ? Ok(products)
                : BadRequest("Paciente não encontrado!");
        }

        [HttpGet("get-all-available-products")]
        public IActionResult GetAllAvailableProducts()
        {
            var products = _service.GetProductsAvailableAsync();
            return Ok(products);
        }

        [HttpPost("post-product")]
        public async Task<IActionResult> Post(ProductRequestDTO item)
        {
            if (item == null)
                return BadRequest("Insira dados do Produto");

            var productnew = _mapper.Map<Product>(item);

            _service.Post(productnew);

            return await (_service.SaveChanges())
             ? Created("", productnew)
             : BadRequest($"Erro ao cadastrar: {item.Name}");
        }

        [HttpDelete("delete-product/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var product = await _service.GetAsync(id);
            if (product != null)
            {
                _service.Delete(id);
                return Ok($"Produto {product.Name} excluido com sucesso");
            }

            return BadRequest("Produto não encontrado");
        }

        [HttpPut("put-product/{id}")]
        public IActionResult Put(int id)
        {
            return Ok();
        }

    }
}
