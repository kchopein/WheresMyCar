using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WheresMyCar.DriverService.Model;
using WheresMyCar.MongoDBLibrary;

namespace WheresMyCar.DriverService.DB
{
    public class DriverContext : MongoDBContext
    {
        public DriverContext(IOptions<MongoSettings> settings) : base(settings)
        {
        }

        public IMongoCollection<DriverEventStore> DriverEventStores
        {
            get
            {
                return Database.GetCollection<DriverEventStore>("Driver");
            }
        }
    }
}