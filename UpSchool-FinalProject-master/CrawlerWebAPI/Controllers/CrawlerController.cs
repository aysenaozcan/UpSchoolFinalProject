using Common.Models;
using Microsoft.AspNetCore.Mvc;
using CrawlerApp.Interfaces;

namespace CrawlerWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CrawlerController : ControllerBase
    {

        private readonly ILogger<CrawlerController> _logger;
        private readonly ICrawlerService _crawlerService;

        public CrawlerController(ILogger<CrawlerController> logger, ICrawlerService crawlerService)
        {
            _logger = logger;
            _crawlerService = crawlerService;
            _crawlerService.initialize();
        }

        [HttpGet]
        [Route("getAllProducts")]
        public IEnumerable<Product> crawlData()
        {
            var products = _crawlerService.getAllProducts();
            return products;

        }
        [HttpGet]
        [Route("getSaleProducts")]
        public IEnumerable<Product> crawlDataOnSale()
        {
            var products = _crawlerService.getAllProducts().Where(product=>product.IsOnSale);
            return products;

        }
    }
}