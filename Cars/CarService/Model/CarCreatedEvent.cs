using System;

namespace CarService.Model
{
    public class CarCreatedEvent : Event<CarCreatedPayload>
    {
        public CarCreatedEvent(Guid entityId, string name, string licenseNumber) 
            : base (entityId, new CarCreatedPayload(name, licenseNumber))
        {

        }
    }
}