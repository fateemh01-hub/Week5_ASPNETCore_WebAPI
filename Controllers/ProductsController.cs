using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week5_ASPNETCore_WebAPI.Data;
using Week5_ASPNETCore_WebAPI.DTOs;
using Week5_ASPNETCore_WebAPI.Models;

namespace Week5_ASPNETCore_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound(new { message = "Product not found." });

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto model)
        {
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Stock = model.Stock
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetProduct),
                new { id = product.Id },
                product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto model)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound(new { message = "Product not found." });

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Stock = model.Stock;

            await _context.SaveChangesAsync();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound(new { message = "Product not found." });

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
