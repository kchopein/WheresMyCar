using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarService.Model;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CarService.DB
{
    public class CarRespository : ICarRepository
    {
        readonly CarContext context;

        public CarRespository(CarContext context)
        {
            this.context = context;
        }

        public async Task AddCarAsync(Car item)
        {
            await context.Cars.InsertOneAsync(item);
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await context.Cars.Find(p => true).ToListAsync();
        }

        public async Task<Car> GetCarAsync(Guid id)
        {
            //var filter = Builders<Car>.Filter.Eq("Id", id);
            return await context.Cars.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> RemoveAllCarsAsync()
        {
            return await context.Cars.DeleteManyAsync(new BsonDocument());
        }

        public async Task<DeleteResult> RemoveCarAsync(Guid id)
        {
            return await context.Cars.DeleteOneAsync(c => c.Id == id);
        }

        public async Task<ReplaceOneResult> UpdateCarAsync(Guid id, Car item)
        {
            return await context.Cars.ReplaceOneAsync(c => c.Id == id, item, new UpdateOptions { IsUpsert = true });
        }

    }
}
