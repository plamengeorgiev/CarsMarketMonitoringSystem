namespace CarsMarketMonitoringSystem.Data.MongoDb.Mappings
{
    using System;
    using System.Linq;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class CarMap
    {
        [BsonConstructor]
        public CarMap(string model, string manufacturer, int topSpeed, int brakeHorsePower, decimal basePrice)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.TopSpeed = topSpeed;
            this.BrakeHorsePower = brakeHorsePower;
            this.BasePrice = basePrice;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public int TopSpeed { get; set; }

        public int BrakeHorsePower { get; set; }

        public decimal BasePrice { get; set; }
    }
}
