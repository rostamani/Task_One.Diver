using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task_One.Web.Models;
using Task_One.Web.Repository.Interfaces;

namespace Task_One.Web.Controllers
{
    public class ProductSellsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductSellsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index(int storeId,DateTime soldDate,double price)
        {
            ViewBag.Stores = new SelectList(_productRepository.GetStores(), "StoreId", "StoreName");
            ViewBag.SoldDates = new SelectList(_productRepository.GetSoldDates(),"Date","Date");
            ViewBag.Prices = new SelectList(_productRepository.GetPrices());

            var productSells = _productRepository.GetProductSells(storeId, price,
                soldDate);
            return View(productSells);
        }

        [Route("[controller]/[action]/{productId}/{storeId}")]
        public IActionResult GetChart(int productId, int storeId)
        {
            var chart = new Chart();
            chart.ProductName = _productRepository.GetProductName(productId);
            chart.StoreName = _productRepository.GetStoreName(storeId);
            chart.Points = _productRepository.GetPoints(productId, storeId);
            return View(chart);
        }


    }
}
