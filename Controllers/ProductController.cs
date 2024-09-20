using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using efcoreRestFull.Context;
using efcoreRestFull.DTOs;
using efcoreRestFull.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingProject.Entities;

namespace efcoreRestFull.Controllers
{
 
    [Route("products")]
    [AllowAnonymous]
    public class ProductController:Controller
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ProductController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var passwordMigrationService = new PasswordMigrationService(_context);
            await passwordMigrationService.MigrateAllPasswordsAsync();
            
            var products = await _context.Products.
                Include(p=>p.Category).OrderBy(o=>o.CategoryId).ToListAsync();
             /*   .
            Select(p=> new ProductDTO
            {
                id = p.Id,
                name=p.Name,
                seq=p.Seq,
                stock=p.Stock,
                price=p.Price,
                description=p.Description,
                imageUrl = p.ImageUrl,
                categoryName = p.Category.Name,
                categoryId = p.CategoryId
                  
            })*/
            var productsDto = _mapper.Map<List<ProductDTO>>(products);
            return Ok(products);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory([FromRoute] int categoryId)
        {
            var products = await _context.Products.Where(p=> p.CategoryId==categoryId).ToListAsync();
            return Ok(products);
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetProductById([FromRoute]int productId){
            return Ok(await _context.Products.FirstOrDefaultAsync(p=>p.Id==productId));
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateProduct([FromRoute] int productId, [FromBody] Product product)
        {
            Product thisProduct = _context.Products.Find(productId);
            thisProduct.Name = product.Name;
            thisProduct.Price = product.Price;
            thisProduct.Description = product.Description;
            thisProduct.ImageUrl = product.ImageUrl;
            thisProduct.CategoryId = product.CategoryId;
            _context.Products.Update(thisProduct);
            _context.SaveChanges();
            return Ok(thisProduct);
        }
        [HttpDelete("{productId}")]
        public void DeleteProduct([FromRoute] int productId)
        {
            
            Product thisProduct= _context.Products.Find(productId);
            _context.Products.Remove(thisProduct);
            _context.SaveChanges();
            
        }
    }
}