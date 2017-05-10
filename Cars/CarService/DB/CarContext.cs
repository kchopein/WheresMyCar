using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WheresMyCar.CarService.Model;
using WheresMyCar.MongoDBLibrary;

namespace WheresMyCar.CarService.DB
{
    public class CarContext : MongoDBContext
    {
        public CarContext(IOptions<MongoSettings> settings) : base(settings)
        {
        }

        public IMongoCollection<CarEventStore> CarEventStores
        {
            get
            {
                return Database.GetCollection<CarEventStore>("Car");
            }
        }
    }
}