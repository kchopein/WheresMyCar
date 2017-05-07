using System;

namespace CarService.Model
{
    public class CarEventStore : EventStore<Car>
    {

        public CarEventStore(string name, string licenseNumber)
        {
            var carCreatedEvent = new CarCreatedEvent(this.Id, name, licenseNumber);
            Events.Add(carCreatedEvent);
        }

        public void Park(Location location)
        {
            var car = this.GetEntity();
            if(car.Status == CarStatus.Parked)
            {
                throw new InvalidOperationException("The car is already parked and can't be parked again.");
            }

            var carParkedEvent = new CarParkedEvent(this.Id, location);
            this.Events.Add(carParkedEvent);
        }

        public void Take(Guid driverId)
        {
            var car = this.GetEntity();
            if (car.Status == CarStatus.Moving)
            {
                throw new InvalidOperationException("The car is already took and can't be taken again.");
            }

            var eventPayload = new CarTookEventPayload(driverId);
            var carTookEvent = new CarTookEvent(this.Id, eventPayload);
            this.Events.Add(carTookEvent);
        }


    }
}
