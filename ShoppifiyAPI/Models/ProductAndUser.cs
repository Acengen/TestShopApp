using System;
using System.Collections.Generic;

namespace ShoppifiyAPI.Models
{
    public class ProductAndUser
    {
        public int Id { get; set; }
        public string UserName {get;set;}

        public string ProductName {get;set;}
        public int Price {get;set;}
        public DateTime Day {get;set;}
    }
}