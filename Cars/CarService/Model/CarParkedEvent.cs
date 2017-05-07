using EventSourcingLibrary;
using System;

namespace CarService.Model
{
    public class CarParkedEvent : Event<Car, Location>
    {
        public CarParkedEvent(Guid entityId, Location location)
            : base(entityId, location)
        {
        }

        public override Car ApplyTo(Car entity)
        {
            entity.Location = this.Payload;
            entity.Status = CarStatus.Parked;
            return entity;
        }
    }
}