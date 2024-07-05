using Hackathon_Project_Backend.Data;
using Hackathon_Project_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hackathon_Project_Backend.Controllers
{
    [Route("/api")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("City/GetAllCities")]
        public IActionResult GetAllCities()
        {
            var cities = _context.Cities.ToList();
            return Ok(cities);
        }

        [HttpGet]
        [Route("City/GetCityById")]
        public IActionResult GetCityById(int id)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Id == id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpPost]
        [Route("City/StoreCity")]
        public IActionResult StoreCity(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("City name is required");
            }

            var newCity = new City
            {
                Name = name
            };

            _context.Cities.Add(newCity);
            _context.SaveChanges();

            return Ok(newCity);
        }

        [HttpPut]
        [Route("City/UpdateCity")]
        public IActionResult UpdateCity(int id, string name)
        {
            var existingCity = _context.Cities.FirstOrDefault(c => c.Id == id);
            if (existingCity == null)
            {
                return NotFound();
            }

            existingCity.Name = name;

            _context.Cities.Update(existingCity);
            _context.SaveChanges();

            return Ok(existingCity);
        }

        [HttpDelete]
        [Route("City/DeleteCity")]
        public IActionResult DeleteCity(int id)
        {
            var existingCity = _context.Cities.FirstOrDefault(c => c.Id == id);
            if (existingCity == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(existingCity);
            _context.SaveChanges();

            return Ok(true);
        }
    }
}
