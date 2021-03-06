﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsMarketMonitoringSystem.Models;
using Telerik.OpenAccess;
using CarsMarketMonitoringSystem.MySqlConnector;


namespace CarsMarketMonitoringSystem.Data.MySQL
{
    public class MySQLReportsManager
    {
        private FluentModel mySqlDbContext;
        private CarsMarketDbContext dbContext;
        public MySQLReportsManager(FluentModel mySqlDbContext, CarsMarketDbContext dataBaseContext)
        {
            this.mySqlDbContext = mySqlDbContext;
            this.dbContext = dataBaseContext;
        }

        public void AddSales()
        {
            var sales = dbContext.Sales;
            foreach (var sale in sales)
            {
                var tempSale = new SaleModel();
                tempSale.SaleId = sale.SaleId;
                tempSale.CarId = sale.CarId;
                tempSale.SellerId = sale.SellerId;
                tempSale.Price = sale.Price;
                tempSale.Date = sale.Date;

                mySqlDbContext.Add(tempSale);
                mySqlDbContext.SaveChanges();
            }
            
        }

        public void UpdateDatabase()
        {
            using (var context = new FluentModel())
            {
                var schemaHandler = context.GetSchemaHandler();
                EnsureDB(schemaHandler);
            }
        }

        public void EnsureDB(ISchemaHandler schemaHandler)
        {
            string script = null;
            if (schemaHandler.DatabaseExists())
            {
                script = schemaHandler.CreateUpdateDDLScript(null);
            }
            else
            {
                schemaHandler.CreateDatabase();
                script = schemaHandler.CreateDDLScript();
            }

            if (!string.IsNullOrEmpty(script))
            {
                schemaHandler.ExecuteDDLScript(script);
            }
        }
    }
}
