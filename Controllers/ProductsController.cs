using API2.Data;
using API2.DTOs.Products;
using API2.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProductsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var products = await context.Products.ToListAsync();
            return Ok(products.Adapt<IEnumerable<GetProductDto>>());

        }

        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await context.Products.FindAsync(id);
            return Ok(product.Adapt<GetProductDto>());
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateProductDto request)
        {
            await context.Products.AddAsync(request.Adapt<Product>());
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id , CreateProductDto request)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            
            request.Adapt(product);

            await context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return Ok(product);
        }
    }
}
