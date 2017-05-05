using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarService.Model
{
    public class Car
    {
        [Key]
        public Guid Id { get; protected set; } = Guid.NewGuid();
        public ICollection<CarCreatedEvent> Events { get; private set; } = new List<CarCreatedEvent>();

        public Car(string name, string licenseNumber)
        {
            var carCreatedEvent = new CarCreatedEvent(this.Id, name, licenseNumber);
            this.Events.Add(carCreatedEvent);
        }
    }
}
