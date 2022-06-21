using Kolokwium_powtórka.Models;
using Kolokwium_powtórka.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kolokwium_powtórka.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IDBService dBservice;

        public AnimalController(IDBService dBService)
        {
            this.dBservice = dBService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimals(string sortBy)
        {
            List<Animal> animals = null;

            try
            {
                animals = dBservice.GetAnimals(sortBy);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

            return Ok(animals);
        }

        [HttpPost]
        public async Task<IActionResult> AddAnimal(Animal animal)
        {
            try
            {
                dBservice.AddAnimal(animal);  
            }catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

            return Ok("Success!");
        }
    }
}
