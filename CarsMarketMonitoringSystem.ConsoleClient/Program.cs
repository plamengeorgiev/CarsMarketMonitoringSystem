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

            //var mongoFiller = new MongoDbFiller(manager);
            //mongoFiller.FillDataBase();
            //
           //manager.ImportDataFromMongoDb();
           //manager.ImportExelReports("../../../Sales-reports.zip");
            //
            var sales = manager.DatabaseContex.Sales;
            manager.ExportJSONReports(sales);
            //manager.ExportDataToMySQL(sales);

            manager.ExportPDFReports(2013, 7);
        }
    }
}
