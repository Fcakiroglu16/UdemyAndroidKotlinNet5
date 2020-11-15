using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyAndroidKotlin.API.Models;

namespace UdemyAndroidKotlin.API.Controllers
{
    [Authorize]
    public class ProductsController : ODataController
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [EnableQuery(PageSize = 5)]
        //odata/products
        public IActionResult Get()
        {
            return Ok(_context.Products.AsQueryable());
        }

        //odata/products(2)
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_context.Products.Where(x => x.Id == key));
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        //odata/Products(4)
        [HttpPut]
        public async Task<IActionResult> PutProduct([FromODataUri] int key, [FromBody] Product product)
        {
            product.Id = key;

            _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        //odata/products(3)
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int key)
        {
            var product = await _context.Products.FindAsync(key);

            if (product == null) return NotFound();

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}