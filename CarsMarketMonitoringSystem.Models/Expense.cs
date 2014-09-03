namespace CarsMarketMonitoringSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Expense
    {
        public int ExpenseId { get; set; }
        public Nullable<int> ManufacturerId { get; set; }
        public Nullable<decimal> Expenses { get; set; }
        public Nullable<System.DateTime> Month { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
