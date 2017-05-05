using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarService.Model
{
    public class Car
    {
        [BsonId]
        public Guid Id { get; protected set; } = Guid.NewGuid();
        public ICollection<CarCreatedEvent> Events { get; private set; } = new List<CarCreatedEvent>();
        public string Name { get; private set; }
        public string LicenseNumber { get; private set; }

        public Car(string name, string licenseNumber)
        {
            this.Name = name;
            this.LicenseNumber = licenseNumber;
            var carCreatedEvent = new CarCreatedEvent(this.Id, name, licenseNumber);
            this.Events.Add(carCreatedEvent);
        }
    }
}
