namespace CarsMarketMonitoringSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Car
    {
        public Car()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int CarId { get; set; }
        public string Model { get; set; }
        public Nullable<int> ManufacturerId { get; set; }
        public Nullable<int> TopSpeed { get; set; }
        public Nullable<int> BrakeHorsePower { get; set; }
        public Nullable<decimal> BasePrice { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
