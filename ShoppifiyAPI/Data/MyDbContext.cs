using Microsoft.EntityFrameworkCore;
using ShoppifiyAPI.Models;

namespace ShoppifiyAPI.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options) 
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products {get;set;}

        public DbSet<ProductAndUser> ProductAndUsers {get;set;}
    }
}