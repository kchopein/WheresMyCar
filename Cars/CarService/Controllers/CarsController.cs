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
        readonly ICarRepository carRepository;

        public CarsController(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            IEnumerable<Car> cars = await carRepository.GetAllCarsAsync();
            var carDtos = cars.Select(c => new CarDto { Id = c.Id, Name = c.Name, LicenseNumber = c.LicenseNumber });
            return base.Ok(carDtos);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody]CarDto carDto)
        {
            var car = new Car(carDto.Name, carDto.LicenseNumber);
            await this.carRepository.AddCarAsync(car);
            return Ok(car);
        }

        public class CarDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string LicenseNumber { get; set; }
        }
    }
}
