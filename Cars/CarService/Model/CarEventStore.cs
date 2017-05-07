using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarService.Model
{
    public class CarEventStore
    {
        [BsonId]
        public Guid Id { get; protected set; } = Guid.NewGuid();
        public IList<IEvent<Car>> Events { get; private set; } = new List<IEvent<Car>>();

        public CarEventStore(string name, string licenseNumber)
        {
            var carCreatedEvent = new CarCreatedEvent(this.Id, name, licenseNumber);
            this.Events.Add(carCreatedEvent);
        }

        public void Park(Location location)
        {
            var carParkedEvent = new CarParkedEvent(this.Id, location);
            this.Events.Add(carParkedEvent);
        }

        public Car GetCar()
        {
            var car = new Car();
            foreach (IEvent<Car> e in Events)
            {
                car = e.ApplyTo(car);
            }
            return car;
        }

    }
}
