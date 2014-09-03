namespace CarsMarketMonitoringSystem.Data.MongoDb.Mappings
{
    using System;
    using System.Linq;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System.Collections.Generic;
    using CarsMarketMonitoringSystem.Models;

    public class SellerMap
    {
        [BsonConstructor]
        public SellerMap(string name, string country)
        {
            this.Name = name;
            this.Country = country;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Country
        {
            get;
            set;
        }
    }
}

