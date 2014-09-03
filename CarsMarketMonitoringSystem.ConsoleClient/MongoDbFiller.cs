using CarsMarketMonitoringSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsMarketMonitoringSystem.Data.MongoDb.Mappings;

namespace CarsMarketMonitoringSystem.ConsoleClient
{
    public class MongoDbFiller
    {
        private DataManager manager;

        public MongoDbFiller(DataManager manager)
        {
            this.manager = manager;
        }

        public void FillDataBase()
        {
            AddSellers();
            AddCars();
        }

        private void AddCars()
        {

            this.manager.MongoDbContext.Cars.Insert(new CarMap("Trabant", "Trabant Industries", 76, 15, 13010));
            this.manager.MongoDbContext.Cars.Insert(new CarMap("ML", "Mercedes", 654, 345, 13040));
            this.manager.MongoDbContext.Cars.Insert(new CarMap("Golf", "VW", 726, 153, 13030));
        }



        private void AddSellers()
        {
            this.manager.MongoDbContext.Sellers.Insert(new SellerMap("Pesho Cars", "Bulgaria"));
            this.manager.MongoDbContext.Sellers.Insert(new SellerMap("Gosho Cars", "Bulgaria"));
            this.manager.MongoDbContext.Sellers.Insert(new SellerMap("Tosho Cars", "Bulgaria"));
            this.manager.MongoDbContext.Sellers.Insert(new SellerMap("Misho Cars", "Bulgaria"));
            this.manager.MongoDbContext.Sellers.Insert(new SellerMap("Gancho Cars", "Bulgaria"));
            this.manager.MongoDbContext.Sellers.Insert(new SellerMap("Stoyancho Cars", "Bulgaria"));
        }


    }
}
