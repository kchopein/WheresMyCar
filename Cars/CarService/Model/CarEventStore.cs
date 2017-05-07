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
            var carParkedEvent = new CarParkedEvent(this.Id, location);
            this.Events.Add(carParkedEvent);
        }
    }
}
