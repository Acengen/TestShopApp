using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppifiyAPI.Data;
using ShoppifiyAPI.Dtos;

namespace ShoppifiyAPI.Controllers
{
    [ApiController]
    [Route("buy")]
    public class ProductAndUserController : ControllerBase
    {   
   
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public ProductAndUserController(MyDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        
        [HttpGet]
        public async Task<IActionResult> GetProductBuy() {
            var prod =  await _context.ProductAndUsers.ToListAsync();
            var prodtoreturn = _mapper.Map<IEnumerable<ProductAndUserDto>>(prod);
            return Ok(prodtoreturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdInCart(int id, ProductAndUserDto productAndUserDto)
        {
            var productBuy = await _context.ProductAndUsers.FirstOrDefaultAsync(pu => pu.Id == id);

            var producttodelete = _mapper.Map(productAndUserDto, productBuy);

            _context.Remove(producttodelete);

            await _context.SaveChangesAsync();

            return NoContent();
        }
       
    }
}