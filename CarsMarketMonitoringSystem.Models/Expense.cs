namespace CarsMarketMonitoringSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Expense
    {
        public int ExpenseId { get; set; }
        public int ManufacturerId { get; set; }
        public decimal Expenses { get; set; }
        public System.DateTime Month { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
