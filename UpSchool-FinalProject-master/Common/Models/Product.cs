using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Product 
    {
        public Product(Guid id, string name, string picture, bool isOnSale, decimal price, decimal salePrice)
        {
            Id = id;
            Name = name;
            Picture = picture;
            IsOnSale = isOnSale;
            Price = price;
            SalePrice = salePrice;
        }

        public Product()
        {
        }
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public string? Picture { get; set; }

        public bool IsOnSale { get; set; }

        public decimal Price { get; set; }

        public decimal SalePrice { get; set; }

    }
}
