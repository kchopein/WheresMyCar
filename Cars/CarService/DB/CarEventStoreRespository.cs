using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarService.Model;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CarService.DB
{
    public class CarEventStoreRespository : ICarEventStoreRepository
    {
        readonly CarContext context;

        public CarEventStoreRespository(CarContext context)
        {
            this.context = context;
        }

        public async Task AddCarEventStoreAsync(CarEventStore item)
        {
            await context.CarEventStores.InsertOneAsync(item);
        }

        public async Task<IEnumerable<CarEventStore>> GetAllCarEventStoresAsync()
        {
            return await context.CarEventStores.Find(p => true).ToListAsync();
        }

        public async Task<CarEventStore> GetCarEventStoreAsync(Guid id)
        {
            //var filter = Builders<Car>.Filter.Eq("Id", id);
            return await context.CarEventStores.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> RemoveAllCarsAsync()
        {
            return await context.CarEventStores.DeleteManyAsync(new BsonDocument());
        }

        public async Task<DeleteResult> RemoveCarEventStoreAsync(Guid id)
        {
            return await context.CarEventStores.DeleteOneAsync(c => c.Id == id);
        }

        public async Task<ReplaceOneResult> UpdateCarEventStoreAsync(Guid id, CarEventStore item)
        {
            return await context.CarEventStores.ReplaceOneAsync(c => c.Id == id, item, new UpdateOptions { IsUpsert = true });
        }

    }
}
