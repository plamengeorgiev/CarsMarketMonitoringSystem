namespace CarsMarketMonitoringSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Manufacturer
    {
        public Manufacturer()
        {
            this.Cars = new HashSet<Car>();
        }

        public int ManufacturerId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
