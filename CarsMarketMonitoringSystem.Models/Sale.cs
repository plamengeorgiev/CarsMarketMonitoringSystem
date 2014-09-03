namespace CarsMarketMonitoringSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Sale
    {
        public int SaleId { get; set; }
        public Nullable<int> CarId { get; set; }
        public Nullable<int> SellerId { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> Date { get; set; }

        public virtual Car Car { get; set; }
        public virtual Seller Seller { get; set; }
    }
}
