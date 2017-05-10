using WheresMyCar.EventSourcingLibrary;

namespace WheresMyCar.DriverService.Model
{
    public class DriverEventStore : EventStore<Driver>
    {
        private string driverName;

        public DriverEventStore(string driverName)
        {
            this.driverName = driverName;
        }
    }
}
