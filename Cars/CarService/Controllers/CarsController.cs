using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WheresMyCar.CarService.Controllers.CarDtos;
using WheresMyCar.CarService.DB;
using WheresMyCar.CarService.Model;

namespace WheresMyCar.CarService.Controllers
{
    [Route("api/[Controller]")]
    public class CarsController : Controller
    {
        private readonly ICarEventStoreRepository carEventStoreRepository;

        public CarsController(ICarEventStoreRepository carEventStoreRepository)
        {
            this.carEventStoreRepository = carEventStoreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            IEnumerable<CarEventStore> carEventStores = await carEventStoreRepository.GetAllCarEventStoresAsync();

            var cars = carEventStores.Select(ces => ces.GetEntity());

            return base.Ok(cars);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody]Car carDto)
        {
            var careventStore = new CarEventStore(carDto.Name, carDto.LicenseNumber);
            await this.carEventStoreRepository.AddCarEventStoreAsync(careventStore);
            return Ok(careventStore.GetEntity());
        }

        [HttpPost]
        [Route("{carId}/parkRequest")]
        public async Task<IActionResult> ParkCar([FromRoute] Guid carId, [FromBody] ParkRequestDto parkRequest)
        {
            var carEventStore = await this.carEventStoreRepository.GetCarEventStoreAsync(carId);

            if (carEventStore == null)
            {
                return NotFound();
            }

            var location = new Location(parkRequest.Address);

            try
            {
                carEventStore.Park(location);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

            await carEventStoreRepository.UpdateCarEventStoreAsync(carId, carEventStore);

            return Ok(carEventStore.GetEntity());
        }

        [HttpPost]
        [Route("{carId}/takeRequest")]
        public async Task<IActionResult> TakeCar([FromRoute] Guid carId, [FromBody] TakeRequestDto takeRequest)
        {
            var carEventStore = await this.carEventStoreRepository.GetCarEventStoreAsync(carId);

            if (carEventStore == null)
            {
                return NotFound();
            }

            try
            {
                carEventStore.Take(takeRequest.DriverId);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

            await carEventStoreRepository.UpdateCarEventStoreAsync(carId, carEventStore);

            return Ok(carEventStore.GetEntity());
        }

        public class CarDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string LicenseNumber { get; set; }
        }
    }
}