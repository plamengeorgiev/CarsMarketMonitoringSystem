namespace CarsMarketMonitoringSystem.Data
{
    using System;
    using System.Linq;

    using CarsMarketMonitoringSystem.Models;
    using CarsMarketMonitoringSystem.Data.MongoDb;

    public class MongoDbManager
    {
        public MongoDbManager(CarsMarketDbContext carsMarketDbContext, MongoDbContext mongoDb)
        {
            this.CarsMarketDbContext = carsMarketDbContext;
            this.MongoDb = mongoDb;
        }

        public MongoDbContext MongoDb { get; set; }

        public CarsMarketDbContext CarsMarketDbContext { get; set; }


        public void ImportData()
        {
            //this.AddExpenses();
            this.AddSellers();
            this.AddCars();

        }

        public void AddCars()
        {
            if (this.CarsMarketDbContext.Cars.Any())
            {
                return;
            }

            foreach (var car in this.MongoDb.Cars.FindAll())
            {
                if (CarsMarketDbContext.Manufacturers.FirstOrDefault(m => m.Name == car.Manufacturer) == null)
                {
                    var newManufacturer = new Manufacturer()
                        {
                            Name = car.Manufacturer
                        };
                    CarsMarketDbContext.Manufacturers.Add(newManufacturer);
                    CarsMarketDbContext.SaveChanges();
                }

                var elementWithNeededId = CarsMarketDbContext.Manufacturers.FirstOrDefault(x => x.Name == car.Manufacturer);

                this.CarsMarketDbContext.Cars.Add(new Car()
                {
                    Model = car.Model,
                    ManufacturerId = elementWithNeededId.ManufacturerId,
                    TopSpeed = car.TopSpeed,
                    BrakeHorsePower = car.BrakeHorsePower,
                    BasePrice = car.BasePrice,
                });
                CarsMarketDbContext.SaveChanges();
            }
        }

        //public void AddExpenses()
        //{
        //    if (this.CarsMarketDbContext.Expenses.Any())
        //    {
        //        return;
        //    }

        //    foreach (var expense in this.MongoDb.Expenses.FindAll())
        //    {
        //        this.CarsMarketDbContext.Expenses.Add(new Expense()
        //        {
        //            ExpenseId = expense.ExpenseId,
        //            ManufacturerId = expense.ManufacturerId,
        //            Expenses = expense.Expenses,
        //            Month = expense.Month
        //        });
        //    }

        //}

        public void AddSellers()
        {

            foreach (var seller in this.MongoDb.Sellers.FindAll())
            {

                if (CarsMarketDbContext.Sellers.FirstOrDefault(s => s.Name == seller.Name) == null)
                {
                    var newSeller = new Seller()
                    {
                        Name = seller.Name,
                        Country = seller.Country
                    };
                    CarsMarketDbContext.Sellers.Add(newSeller);
                    CarsMarketDbContext.SaveChanges();
                }
            }
        }

        public void SaveChanges()
        {
            this.CarsMarketDbContext.SaveChanges();
        }
    }
}