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

            manager.FillMongoDatabase();
            Console.WriteLine("Data Successfully Added To MongoDB");
            manager.ImportDataFromMongoDb();
            Console.WriteLine("Data Successfully Imported From MongoDB to MSSQL");
            manager.ImportExelReports("../../../Sales-reports.zip");
            Console.WriteLine("Data Successfully Imported From Excel Reports");
            manager.ExportJSONReports();
            Console.WriteLine("Json Reports Succesfully Created");
            manager.ExportDataToMySQL();
            Console.WriteLine("Data Successfully Exported To MySQL");
            manager.ExportPDFReports(2013, 7);
            Console.WriteLine("PDF Reports Successfully Created");

        }
    }
}
