namespace CarsMarketMonitoringSystem.Data
{
    using System;

    using CarsMarketMonitoringSystem.Models;
    using CarsMarketMonitoringSystem.Data.MongoDb;
    using Excel;
    using JSON;
    using MySQL;
    using MongoDb;
    using CarsMarketMonitoringSystem.Data.PdfReporter;
    using System.Collections.Generic;
    using CarsMarketMonitoringSystem.MySqlConnector;

    /// <summary>
    /// Class that controls getting and loading the data from outer
    /// sourses to the central MS SQL Server
    /// </summary>
    public class DataManager
    {
        private const string ExtractedFilesPath = "../../Extracted-reports";
        private const string ConnectionStringMongoDb = "mongodb://localhost";
        private const string DatabaseNameMongoDb = "CarsMarketMonitoringSystem";

        private CarsMarketDbContext dbContext;
        private MongoDbContext mongoDbContext;
        private FluentModel mySqlDbContext;

        public DataManager()
        {
            this.DatabaseContex = new CarsMarketDbContext();
            this.MongoDbContext = new MongoDbContext(ConnectionStringMongoDb, DatabaseNameMongoDb);
            this.MySQLDbContext = new FluentModel();
        }

        public CarsMarketDbContext DatabaseContex 
        {
            get
            {
                return this.dbContext;
            }

            private set
            {
                this.dbContext = value;
            }
        }

        public MongoDbContext MongoDbContext
        {
            get
            {
                return this.mongoDbContext;
            }

            private set
            {
                this.mongoDbContext = value;
            }
        }

        public FluentModel MySQLDbContext
        {
            get 
            {
                return this.mySqlDbContext;
            }
            set 
            {
                this.mySqlDbContext = value;
            }
        }

        public void FillMongoDatabase()
        {
            var mongoFiller = new MongoDbFiller(this.MongoDbContext);
            mongoFiller.FillDataBase();
        }

        public void ImportExelReports(string zipFilePath) 
        {
            var exelManager = new ExcelReportsManager(zipFilePath, ExtractedFilesPath, this.DatabaseContex);
            exelManager.ImportSalesReport();
        }

        public void ImportDataFromMongoDb()
        {
            var mongoDbSeeder = new MongoDbManager(this.dbContext, this.mongoDbContext);
            mongoDbSeeder.ImportData();
        }

        public void ImportManufacturersExpenses(string xmlFilePath)
        {
            throw new NotImplementedException();
        }

        public void ExportJSONReports()
        {
            var jsonManager = new JSONReportManager(this.DatabaseContex);
            jsonManager.GenerateJSONReports("../../Generated-reports");
        }

        public void ExportDataToMySQL() 
        {
            var sqlManager = new MySQLReportsManager(this.MySQLDbContext, this.DatabaseContex);
            sqlManager.UpdateDatabase();
            sqlManager.AddSales();
            
        }

        public void ExportPDFReports(int year, int month)
        {
            var pdfReporter = new PdfReporter.PdfReporter(this.dbContext);
            pdfReporter.GenerateReportsForMonth(year, month);
        }
    }
}
