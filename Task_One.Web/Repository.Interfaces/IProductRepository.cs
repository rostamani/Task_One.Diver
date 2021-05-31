using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_One.Web.Models;

namespace Task_One.Web.Repository.Interfaces
{
    public interface IProductRepository
    {
        List<ProductSell> GetProductSells(int storeId,double price,DateTime soldDate);
        List<ChartData> GetPoints(int productId,int storeId);
        string GetProductName(int productId);
        string GetStoreName(int storeId);
        List<Store> GetStores();
        List<DateTime> GetSoldDates();
        List<double> GetPrices();
    }
}
