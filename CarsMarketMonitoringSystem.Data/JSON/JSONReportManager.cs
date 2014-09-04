using CarsMarketMonitoringSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace CarsMarketMonitoringSystem.Data.JSON
{
    public class JSONReportManager
    {
        private CarsMarketDbContext context;

        public JSONReportManager(CarsMarketDbContext dataBaseContext)
        {
            this.context = dataBaseContext;
        }

        public void GenerateJSONReports(string jsonReportsPath)
        {
            //not working
            


            var selection = context.Sales.Select(sales =>
                new
                {
                    SaleId = sales.SaleId,
                   CarModel = sales.Car.Model,
                   CarManufacturer = sales.Car.Manufacturer.Name,
                   SellerName = sales.Seller.Name,
                   Price = sales.Price,
                Date = sales.Date

                }
                );

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            foreach (var sale in selection)
            {
                //var tempSale = new Sale();
                //tempSale.SaleId = sale.SaleId;
                //tempSale.CarId = sale.CarId;
                //tempSale.SellerId = sale.SellerId;
                //tempSale.Price = sale.Price;
                //tempSale.Date = sale.Date;

                var tempSale = new JsonSale();
                tempSale.SaleId = sale.SaleId;
                tempSale.CarModel =sale.CarModel;
                tempSale.CarManufacturer = sale.CarManufacturer;
                tempSale.SellerName = sale.SellerName;
                tempSale.Price = sale.Price;
                tempSale.Date = sale.Date;

                string jsonSale = JsonConvert.SerializeObject(tempSale);
                //write string to file
                string finalPath = String.Format(@"{0}\{1}.json", jsonReportsPath, sale.SaleId);
                System.IO.File.WriteAllText(finalPath, jsonSale);
            }
        }

    }
}
