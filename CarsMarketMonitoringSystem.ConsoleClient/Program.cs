namespace CarsMarketMonitoringSystem.ConsoleClient
{
    using CarsMarketMonitoringSystem.Data;
    using CarsMarketMonitoringSystem.Models;
    using CarsMarketMonitoringSystem.MySqlConnector;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Telerik.OpenAccess; 

    public class Program
    {
        static void Main(string[] args)
        {
            var manager = new DataManager();

            var mongoFiller = new MongoDbFiller(manager);
            mongoFiller.FillDataBase();

            manager.ImportDataFromMongoDb();
            manager.ImportExelReports("../../../Sales-reports.zip");

            var sales = manager.DatabaseContex.Sales;
            manager.ExportJSONReports(sales);

            //foreach (var sale in sales)
            //{
            //    var saleModel = new SaleModel();

            //    saleModel.SaleId = sale.SaleId;
            //    saleModel.CarId = sale.CarId;
            //    saleModel.SellerId = 1;
            //    saleModel.Price = 1300;
            //    saleModel.Date = DateTime.Now;

            //    manager.ExportDataToMySQL(new List<SaleModel>() { saleModel });
            //}
            
            
        }

        //private static void DatabaseModelTest(DataManager manager)
        //{
            
        //    manager.DatabaseContex.Manufacturers.Add(new Manufacturer()
        //    {
        //        LocationId = 1,
        //        Name = "BMW-Sofia"
        //    });

        //    manager.DatabaseContex.Cars.Add(new Car()
        //    {
        //        ManufacturerId = 1,
        //        Model = "318M",
        //        BasePrice = 20000m
        //    });
            
        //    manager.DatabaseContex.Sellers.Add(new Seller()
        //    {
        //        Name = "PeshoCars",
        //        LocationId = 1
        //    });

        //    manager.DatabaseContex.Sales.Add(new Sale()
        //    {
        //        CarId = 1,
        //        Date = DateTime.Now,
        //        Price = 32000m,
        //        SellerId = 1
        //    });

        //    manager.DatabaseContex.SaveChanges();
        //}

    }
}
