using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Common.Interfaces;

namespace CrawlerApp.Interfaces
{
    public interface ICrawlerService : Lifecycle
    {
        public List<Product> getAllProducts();
        public List<Product> getProducts(int? count, ProductSearchOptionsProductSearchOptions? option);

    }
}
