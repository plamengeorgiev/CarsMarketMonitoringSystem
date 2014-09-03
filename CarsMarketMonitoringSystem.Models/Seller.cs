namespace CarsMarketMonitoringSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Seller
    {
        public Seller()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int SellerId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
