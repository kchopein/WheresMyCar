using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CarService.Model
{
    public class Location
    {
        [BsonId]
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Address { get; private set; }

        public Location(string address)
        {
            Address = address;
        }
    }
}