using E_Commerce.Application.DTOs.Product;
using E_Commerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService serivce)
        {
            _service = serivce;
        }

        //GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var product = await _service.GetAllAsync();

            return Ok(product);
        }

        //Get by ID : api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        //POST: : api/products
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateDto dto)
        {
            var id = await _service.CreateAsync(dto);
            if (id == 0) return NotFound();

            return CreatedAtAction(nameof(GetById), new {id}, dto);
        }

        //PUT
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);

            return result ? NoContent() : NotFound();
        }

        //DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            return result ? NoContent() : NotFound();
        }
    }
}
