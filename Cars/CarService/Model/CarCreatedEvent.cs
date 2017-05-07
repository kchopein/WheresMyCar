using MongoDB.Bson.Serialization;
using System;

namespace CarService.Model
{
    public class CarCreatedEvent : Event<Car, CarCreatedPayload>
    {
        public CarCreatedEvent(Guid entityId, string name, string licenseNumber) 
            : base (entityId, new CarCreatedPayload(name, licenseNumber))
        {

        }

        public override Car ApplyTo(Car entity)
        {
            entity.Name = this.Payload.Name;
            entity.LicenseNumber = this.Payload.LicenseNumber;
            entity.Id = this.EntityId;
            return entity;
        }
    }
}