using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppifiyAPI.Data;
using ShoppifiyAPI.Dtos;
using ShoppifiyAPI.Models;

namespace ShoppifiyAPI.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public ProductController(MyDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            var productToRetrun = _mapper.Map<IEnumerable<ProductDto>>(products);
            
            return Ok(productToRetrun);
        }
    }
}