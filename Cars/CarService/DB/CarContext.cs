using CarService.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarService.DB
{
    public class CarContext
    {
        private readonly IMongoDatabase _database = null;

        public CarContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Car> Cars
        {
            get
            {
                return _database.GetCollection<Car>("Car");
            }
        }
    }
}
