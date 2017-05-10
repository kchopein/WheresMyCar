using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WheresMyCar.CarService.Model;

namespace WheresMyCar.CarService.DB
{
    public interface ICarEventStoreRepository
    {
        Task<IEnumerable<CarEventStore>> GetAllCarEventStoresAsync();

        Task<CarEventStore> GetCarEventStoreAsync(Guid id);

        Task AddCarEventStoreAsync(CarEventStore item);

        Task<DeleteResult> RemoveCarEventStoreAsync(Guid id);

        Task<ReplaceOneResult> UpdateCarEventStoreAsync(Guid id, CarEventStore item);
    }
}