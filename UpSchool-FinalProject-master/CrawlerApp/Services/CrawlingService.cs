using CrawlerApp.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Common.Interfaces;

namespace CrawlerApp.Services
{
    public class CrawlingService : ICrawlerService
    {
        private bool isInitialized;
        private readonly ChromeDriver chromeDriver;

        public CrawlingService()
        {
            chromeDriver = new ChromeDriver();
        }

        public List<Product> getAllProducts()
        {
            //, 4, 5, 6, 7, 8, 9, 10
            List<int> pageNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<Product> products = new List<Product>();
            foreach (int pageNumber in pageNumbers)
            {
                chromeDriver.Url = "https://4teker.net/?currentPage=" + pageNumber.ToString();
                var productElements = chromeDriver.FindElements(By.ClassName("h-100"));
                foreach (var productElement in productElements)
                {
                    var product = new Product();
                    product.Id = Guid.NewGuid();
                    product.Name = productElement.FindElement(By.ClassName("product-name")).Text;
                    product.Picture = productElement.FindElement(By.ClassName("card-img-top")).GetAttribute("src");
                    try
                    {
                        product.IsOnSale = productElement.FindElement(By.ClassName("onsale")).Text == "Sale";
                    }
                    catch
                    {
                        product.IsOnSale = false;
                    }

                    if (product.IsOnSale)
                    {
                        string salePriceText = productElement.FindElement(By.ClassName("sale-price")).Text;
                        string priceText = productElement.FindElement(By.ClassName("text-decoration-line-through")).Text; 
                        decimal decimalSalePrice = decimal.Parse(salePriceText.Replace(",", ".").Replace("$", ""));
                        decimal decimalPrice = decimal.Parse(priceText.Replace(",", ".").Replace("$", ""));
                        product.Price = decimalPrice;
                        product.SalePrice = decimalSalePrice;
                    }
                    else
                    {
                        string priceText = productElement.FindElement(By.ClassName("price")).Text;
                        decimal decimalPrice = decimal.Parse(priceText.Replace(",", "").Replace("$", ""));

                        product.Price = decimalPrice;
                    }



                    products.Add(product);
                }


            }

            return products;
        }

        public List<Product> getProducts(int? count, ProductSearchOptionsProductSearchOptions? option)
        {
            throw new NotImplementedException();
        }

        public void initialize()
        {
            if (isInitialized)
            {
                return;
            }
            isInitialized = true;
        }
        public void terminate()
        {
            chromeDriver.Quit();
            isInitialized = false;
        }

        bool Lifecycle.isInitialized()
        {
            return isInitialized;
        }
        private List<String> getProductNames()
        {
            return chromeDriver.FindElements(By.ClassName("product-name"))
                .Select(elem => elem.Text)
                .ToList();
        }

    }
}
