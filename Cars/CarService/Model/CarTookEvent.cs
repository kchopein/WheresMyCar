using System;
using WheresMyCar.EventSourcingLibrary;

namespace WheresMyCar.CarService.Model
{
    public class CarTookEvent : Event<Car, CarTookEventPayload>
    {
        public CarTookEvent(Guid entityId, CarTookEventPayload payload) : base(entityId, payload)
        {
        }

        public override Car ApplyTo(Car entity)
        {
            entity.Status = CarStatus.Moving;
            entity.CurrentDriverId = this.Payload.DriverId;
            entity.Location = null;

            return entity;
        }
    }
}