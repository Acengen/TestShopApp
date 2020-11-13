using System;

namespace ShoppifiyAPI.Dtos
{
    public class ProductAndUserDto
    {
         
        public string UserName {get;set;}
        public string ProductName {get;set;}
        
        public int Price {get;set;}
        public DateTime Day {get;set;}
    }
}