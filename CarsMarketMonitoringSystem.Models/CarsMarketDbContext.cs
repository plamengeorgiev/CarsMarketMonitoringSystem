namespace CarsMarketMonitoringSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using CarsMarketMonitoringSystem.Models.Migrations;

    public partial class CarsMarketDbContext : DbContext
    {
        public CarsMarketDbContext()
            : base("name=CarsMarketDatabase")
        {
           // Database.SetInitializer(
           //     // new MigrateDatabaseToLatestVersion<CarsMarketDbContext, Configuration>());
           //     new DropCreateDatabaseAlways<CarsMarketDbContext>());
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
    }
}