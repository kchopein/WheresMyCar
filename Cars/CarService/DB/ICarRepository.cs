using CarService.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.DB
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<Car> GetCarAsync(Guid id);
        Task AddCarAsync(Car item);
        Task<DeleteResult> RemoveCarAsync(Guid id);
        Task<ReplaceOneResult> UpdateCarAsync(Guid id, Car item);

        // demo interface - full document update
        //Task<ReplaceOneResult> UpdateCarDocumentAsync(string id, string body);

        // should be used with high cautious, only in relation with demo setup
        Task<DeleteResult> RemoveAllCarsAsync();
    }
}
