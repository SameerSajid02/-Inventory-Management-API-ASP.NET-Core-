using ProductInventoryApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ProductInventoryApi.Models.DTOs;
using ProductInventoryApi.Models;

namespace ProductInventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository repo;
        private readonly IMapper mapper;

        public ProductsController(IProductRepository Repo, IMapper Mapper)
        {
            repo = Repo;
            mapper = Mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await repo.GetAllAsync();
            return Ok( mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await repo.GetByIdAsync(id);
            if (product == null) return NotFound();

            return Ok(mapper.Map<ProductDto>(product));
        }


        [HttpPost]
        public async Task<ActionResult> Create(CreateProductDto dto)
        {
            var product =  mapper.Map<Product>(dto);
            await  repo.AddAsync(product);
            await repo.SaveAsync();

            var productDto = mapper.Map<ProductDto>(product);

            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CreateProductDto dto)
        {
            var existing = await  repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            mapper.Map(dto, existing);
            repo.Update(existing);
            await repo.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await repo.GetByIdAsync(id);
            if (product == null) return NotFound();

            repo.Delete(product);
            await repo.SaveAsync();
            return NoContent();
        }

    }
}
