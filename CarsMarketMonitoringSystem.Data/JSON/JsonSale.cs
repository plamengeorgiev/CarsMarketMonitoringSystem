using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsMarketMonitoringSystem.Data.JSON
{
    public class JsonSale
    {
        public int SaleId { get; set; }

        public string CarModel { get; set; }

        public string CarManufacturer { get; set; }

        public string SellerName { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }
    }
}
