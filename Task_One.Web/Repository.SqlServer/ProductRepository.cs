using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Task_One.Web.Models;
using Task_One.Web.Repository.Interfaces;

namespace Task_One.Web.Repository.SqlServer
{
    public class ProductRepository:IProductRepository
    {
        private readonly IConfiguration _configuration;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<ProductSell> GetProductSells(int storeId, double price, DateTime soldDate)
        {
            List<ProductSell> productSells = new List<ProductSell>();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Task1ConnectionString")))
            {

                SqlCommand cmd = new SqlCommand("GetProductsSells", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (storeId==0)
                {
                    cmd.Parameters.AddWithValue("@sid", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@sid", storeId);
                }
                if (price == 0)
                {
                    cmd.Parameters.AddWithValue("@price", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@price", price);
                }

                if (soldDate==new DateTime(1,1,1))
                {
                    cmd.Parameters.AddWithValue("@date", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@date", soldDate);
                }
                
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ProductSell productSell = new ProductSell();
                    productSell.ProductId = Convert.ToInt32(rdr["ProductId"]);
                    productSell.StoreId = Convert.ToInt32(rdr["StoreId"]);
                    productSell.Store = Convert.ToString(rdr["StoreName"]);
                    productSell.Product = Convert.ToString(rdr["ProductName"]);
                    productSell.Price = Convert.ToDouble(rdr["Price"]);
                    productSell.SoldDate = Convert.ToDateTime(rdr["SoldDate"]);

                    productSells.Add(productSell);
                }
                con.Close();
            }
            return productSells;
        }

        public List<DateTime> GetSoldDates()
        {
            List<DateTime> soldDates = new List<DateTime>();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Task1ConnectionString")))
            {

                SqlCommand cmd = new SqlCommand("GetSoldDates", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    DateTime soldDate = new DateTime();
                    soldDate = Convert.ToDateTime(rdr["SoldDate"]);

                    soldDates.Add(soldDate);
                }
                con.Close();
            }
            return soldDates;
        }

        public List<double> GetPrices()
        {
            List<double> prices = new List<double>();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Task1ConnectionString")))
            {

                SqlCommand cmd = new SqlCommand("GetPrices", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    double price =  Convert.ToDouble(rdr["Price"]);

                    prices.Add(price);
                }
                con.Close();
            }
            return prices;
        }

        public List<ChartData> GetPoints(int productId, int storeId)
        {
            List<ChartData> points = new List<ChartData>();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Task1ConnectionString")))
            {
                SqlCommand cmd = new SqlCommand("GetChartData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sid", storeId);
                cmd.Parameters.AddWithValue("@pid", productId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ChartData point = new ChartData();
                    point.Price = Convert.ToDouble(rdr["Price"]);
                    point.SoldDate = Convert.ToDateTime(rdr["SoldDate"]);

                    points.Add(point);
                }
                con.Close();
            }
            return points;
            
        }

        public string GetProductName(int productId)
        {
            string name = "";
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Task1ConnectionString")))
            {
                SqlCommand cmd = new SqlCommand("GetProductName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pid", productId);
                con.Open();
                name = cmd.ExecuteScalar().ToString();

                con.Close();
            }
            return name;
        }

        public string GetStoreName(int storeId)
        {
            string name = "";
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Task1ConnectionString")))
            {
                SqlCommand cmd = new SqlCommand("GetStoreName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sid", storeId);
                con.Open();
                name = cmd.ExecuteScalar().ToString();

                con.Close();
            }
            return name;
        }

        public List<Store> GetStores()
        {
            List<Store> stores = new List<Store>();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Task1ConnectionString")))
            {
                SqlCommand cmd = new SqlCommand("GetStores", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Store store = new Store();
                    store.StoreId = Convert.ToInt32(rdr["StoreId"]);
                    store.StoreName = Convert.ToString(rdr["StoreName"]);

                    stores.Add(store);
                }
                con.Close();
            }
            return stores;
        }
    }
    }

