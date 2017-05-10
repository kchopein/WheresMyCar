using System;

namespace WheresMyCar.CarService.Model
{
    public class CarTookEventPayload
    {
        public Guid DriverId { get; private set; }

        public CarTookEventPayload(Guid driverId)
        {
            this.DriverId = driverId;
        }
    }
}