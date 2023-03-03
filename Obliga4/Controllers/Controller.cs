using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Obliga4;
using Cars;
using Obliga4.Respository;


namespace Obliga4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private CarRespository _repository;

        public CarsController(CarRespository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAll()
        {
            List<Car> result = _repository.GetCars();
            if (result.Count < 1)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            Car foundCar = _repository.GetCarById(id);
            if (foundCar == null)
            {
                return NotFound();
            }
            return Ok(foundCar);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car newCar)
        {
            Car createdCar = _repository.AddCar(newCar);
            return Created($"api/cars/{createdCar.Id}", createdCar);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Car> Put(int id, [FromBody] Car updates)
        {
            Car updatedCar = _repository.UpdateCar(id, updates);
            if (updatedCar == null)
            {
                return NotFound();
            }
            return Ok(updatedCar);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            Car deletedCar = _repository.DeleteCar(id);
            if (deletedCar == null)
            {
                return NotFound();
            }
            return Ok(deletedCar);
        }
    }
}
