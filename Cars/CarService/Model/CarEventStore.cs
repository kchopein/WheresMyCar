using System;
using WheresMyCar.EventSourcingLibrary;

namespace WheresMyCar.CarService.Model
{
    public class CarEventStore : EventStore<Car>
    {
        public CarEventStore(string name, string licenseNumber)
        {
            var carCreatedEvent = new CarCreatedEvent(this.Id, name, licenseNumber);
            Events.Add(carCreatedEvent);
        }

        /// <summary>
        /// Parks the car at the specified location.
        /// </summary>
        /// <param name="location">The new location of the car.</param>
        /// <exception cref="System.InvalidOperationException">The car is already parked and can't be parked again.</exception>
        public void Park(Location location)
        {
            var car = this.GetEntity();
            if (car.Status == CarStatus.Parked)
            {
                throw new InvalidOperationException("The car is already parked and can't be parked again.");
            }

            var carParkedEvent = new CarParkedEvent(this.Id, location);
            this.Events.Add(carParkedEvent);
        }

        /// <summary>
        /// The car is taken by the driver whose id is specified.
        /// </summary>
        /// <param name="driverId">The driver identifier.</param>
        /// <exception cref="System.InvalidOperationException">The car is already took and can't be taken again.</exception>
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