using CrawlerApp.Services;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;

namespace CrawlerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var logger = new LoggerFactory().CreateLogger<Type>();

            logger.LogInformation("Crawler app has been started");
        }
    }
}