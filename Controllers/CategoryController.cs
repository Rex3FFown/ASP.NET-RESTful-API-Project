using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using efcoreRestFull.Context;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreRestFull.Controllers
{
    [Route("category")]
    public class CategoryController : Controller
    {
        private readonly DataContext _context;
        public CategoryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }


    }
}