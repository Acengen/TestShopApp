using System;
using System.Collections.Generic;
using System.Linq;
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
    [Route("[controller]/register")]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public UserController(MyDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        [HttpPost]
        public async Task<IActionResult> PostUser(UserToCreateDto userToCreateDto)
        {
            var userToCreate = _mapper.Map<User>(userToCreateDto);
            await _context.Users.AddAsync(userToCreate);
            await _context.SaveChangesAsync();

            return Ok(userToCreate);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            var usersToReturn = _mapper.Map<IEnumerable<UserDto>>(users);

            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id) {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            var usersToReturn = _mapper.Map<UserDto>(user);

            return Ok(usersToReturn);
        }

        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(int id, UserDto userDto) {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
           
            userDto.Id = user.Id;

            var userToDelete = _mapper.Map(userDto,user);

            _context.Remove(userToDelete);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("product/{id}/buy/{userid}")]
        public async Task<IActionResult> BuyProduct(int id,int userid, ProductAndUserDto productAndUserDto) {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userid);
            var products = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            var productToBuyToAdd = _mapper.Map<ProductAndUser>(productAndUserDto);

            productToBuyToAdd.ProductName = products.Name;
            productToBuyToAdd.UserName = user.Name;
            productToBuyToAdd.Price = products.Price;
            productToBuyToAdd.Day = DateTime.Now;
    
            await _context.ProductAndUsers.AddAsync(productToBuyToAdd);
            await _context.SaveChangesAsync();

            return Ok(productToBuyToAdd);
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateSingleUser(int id, UserToUpdateDto userToUpdateDto) {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);


            _mapper.Map(userToUpdateDto,user);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}