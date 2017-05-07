using CarService.DB;
using CarService.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Controllers
{
    [Route("api/[Controller]")]
    public class CarsController : Controller
    {
        readonly ICarEventStoreRepository carEventStoreRepository;

        public CarsController(ICarEventStoreRepository carEventStoreRepository)
        {
            this.carEventStoreRepository = carEventStoreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            IEnumerable<CarEventStore> carEventStores = await carEventStoreRepository.GetAllCarEventStoresAsync();

            var cars = carEventStores.Select(ces => ces.GetCar());

            return base.Ok(cars);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody]Car carDto)
        {
            var careventStore = new CarEventStore(carDto.Name, carDto.LicenseNumber);
            await this.carEventStoreRepository.AddCarEventStoreAsync(careventStore);
            return Ok(careventStore.GetCar());
        }

        public class CarDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string LicenseNumber { get; set; }
        }
    }
}
