using LarsTravel.Context;
using LarsTravel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LarsTravel.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CityController : ControllerBase
	{
		public DataContext _dataContext;
		public CityController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		// GET: api/<CityController>
		[HttpGet]
		public IActionResult GetAllCity()
		{
			try
			{
				return Ok(_dataContext.City.Include(c => c.Tours).ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// GET api/<CityController>/5
		[HttpGet("{id}")]
		public IActionResult GetCityById(long id)
		{
			try
			{
				City city = _dataContext.City.FirstOrDefault(b => b.Id == id);
				if (city == null) return NotFound();
				return Ok(city);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

        [HttpGet("/search/{value}")]
        public IActionResult SearchCity(string value)
        {
            try
            {
                List<City> cities = _dataContext.City.Where(c => c.Name.Contains(value)).ToList();
                if (cities == null) return NotFound();
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        // POST api/<CityController>
        [HttpPost]
		public IActionResult Post([FromBody] City value)
		{
			//City city = JsonConvert.DeserializeObject<City>(value);
			City city = value;
            try
			{
				_dataContext.City.Add(city);
				_dataContext.SaveChanges();
				return Ok(city);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}

		}

		// PUT api/<CityController>/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] City value)
		{
			try
			{
				var City = _dataContext.City.FirstOrDefault(b => b.Id == id);
				if (City != null)
				{
					_dataContext.Entry(City).CurrentValues.SetValues(value);
					_dataContext.SaveChanges();
					return Ok(value);
				}
				return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}

		}

		// DELETE api/<CityController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				var City = _dataContext.City.FirstOrDefault(b => b.Id == id);
				if (City != null)
				{
					_dataContext.Remove(City);
					_dataContext.SaveChanges();
					return Ok();
				}
				return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}

		}
	}
}
