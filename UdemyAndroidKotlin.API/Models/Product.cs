using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAndroidKotlin.API.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Color { get; set; }
        public int Stock { get; set; }

        public int PhotoPath { get; set; }

        public int Category_Id { get; set; }

        public virtual Category Category { get; set; }
    }
}