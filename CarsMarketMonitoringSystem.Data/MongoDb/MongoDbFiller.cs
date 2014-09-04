using CarsMarketMonitoringSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsMarketMonitoringSystem.Data.MongoDb.Mappings;
using CarsMarketMonitoringSystem.Data.MongoDb;

namespace CarsMarketMonitoringSystem.Data
{
    public class MongoDbFiller
    {
        private MongoDbContext context;

        public MongoDbFiller(MongoDbContext mongoDbContext)
        {
            this.MongoDbContext = mongoDbContext;
        }

        public MongoDbContext MongoDbContext
        {
            get { return this.context; }
            set { this.context = value; }
        }

        public void FillDataBase()
        {
            AddSellers();
            AddCars();
        }

        private void AddCars()
        {

            context.Cars.Insert(new CarMap("Trabant", "Trabant Industries", 80, 50, 14500));
            context.Cars.Insert(new CarMap("ML", "Mercedes", 210, 240, 50000));
            context.Cars.Insert(new CarMap("Golf", "VW", 130, 220, 35000));
            context.Cars.Insert(new CarMap("Trabant GT", "Trabant Industries", 76, 15, 13010));
            context.Cars.Insert(new CarMap("G", "Mercedes", 654, 345, 13040));
            context.Cars.Insert(new CarMap("Polo", "VW", 726, 153, 13030));
            context.Cars.Insert(new CarMap("Trabant SL", "Trabant Industries", 76, 15, 13010));
            context.Cars.Insert(new CarMap("SLK", "Mercedes", 654, 345, 13040));
            context.Cars.Insert(new CarMap("Golf II", "VW", 726, 153, 13030));
            context.Cars.Insert(new CarMap("Trabant Tourer", "Trabant Industries", 76, 15, 13010));
            context.Cars.Insert(new CarMap("CRV", "Honda", 150, 150, 20000));
            context.Cars.Insert(new CarMap("Civic", "Honda", 110, 190, 29000));
            context.Cars.Insert(new CarMap("Q7", "Audi", 250, 230, 54000));
            context.Cars.Insert(new CarMap("Miata", "Mazda", 110, 180, 24000));
            context.Cars.Insert(new CarMap("Forester", "Subaru", 140, 220, 35000));
            context.Cars.Insert(new CarMap("Passat", "VW", 130, 200, 18000));
        }

        private void AddSellers()
        {
            context.Sellers.Insert(new SellerMap("Pesho Cars", "Bulgaria"));
            context.Sellers.Insert(new SellerMap("Gosho Cars", "Bulgaria"));
            context.Sellers.Insert(new SellerMap("Tosho Cars", "Bulgaria"));
            context.Sellers.Insert(new SellerMap("Misho Cars", "Bulgaria"));
            context.Sellers.Insert(new SellerMap("Gancho Cars", "Bulgaria"));
            context.Sellers.Insert(new SellerMap("Stoyancho Cars", "Bulgaria"));
            context.Sellers.Insert(new SellerMap("Mariika Cars", "Bulgaria"));
            context.Sellers.Insert(new SellerMap("Ivanka Cars", "Bulgaria"));
            context.Sellers.Insert(new SellerMap("Pepo Cars", "Bulgaria"));
            context.Sellers.Insert(new SellerMap("Pernik Cars", "Bulgaria"));
            context.Sellers.Insert(new SellerMap("Vraca Cars", "Bulgaria"));
            context.Sellers.Insert(new SellerMap("Pleven Cars", "Bulgaria"));
        }


    }
}
