using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CarService.Model
{
    public class Location
    {
        [BsonId]
        public Guid Id { get; protected set; }
        public string Address { get; }

        public Location(string address)
        {
            Address = address;
        }
    }
}