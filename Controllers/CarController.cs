using Microsoft.AspNetCore.Mvc;
using WAA_API.Models;

namespace WAA_API.Controllers
{
    //public class CarController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }
    //}

    [Route("api/v1/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private static List<Car> Cars = new List<Car>
        {
            new Car { Id = 1, Make = "Toyota", Model = "Camry", Year = 2020, Price = 24000 },
            new Car { Id = 2, Make = "Honda", Model = "Civic", Year = 2019, Price = 20000 },
            new Car { Id = 3, Make = "Ford", Model = "Mustang", Year = 2021, Price = 30000 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAllCars()
        {
            return Ok(Cars);
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetCarById(int id)
        {
            var car = Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        public ActionResult<Car> CreateCar(Car newCar)
        {
            newCar.Id = Cars.Max(c => c.Id) + 1;
            Cars.Add(newCar);
            return CreatedAtAction(nameof(GetCarById), new { id = newCar.Id }, newCar);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCar(int id, Car updatedCar)
        {
            var car = Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            car.Make = updatedCar.Make;
            car.Model = updatedCar.Model;
            car.Year = updatedCar.Year;
            car.Price = updatedCar.Price;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCar(int id)
        {
            var car = Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            Cars.Remove(car);
            return NoContent();
        }
    }
}

