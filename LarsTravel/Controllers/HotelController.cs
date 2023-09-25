using LarsTravel.Context;
using LarsTravel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LarsTravel.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HotelController : ControllerBase
	{
		public DataContext _dataContext;
		public HotelController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		// GET: api/<HotelController>
		[HttpGet]
		public IActionResult GetAllHotel()
		{
			try
			{
				return Ok(_dataContext.Hotel.ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// GET api/<HotelController>/5
		[HttpGet("{id}")]
		public IActionResult GetHotelById(long id)
		{
			try
			{
				Hotel Hotel = _dataContext.Hotel.FirstOrDefault(b => b.Id == id);
				if (Hotel == null) return NotFound();
				return Ok(Hotel);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		[HttpGet("search/{value}")]
		public IActionResult SearchHotel(string value)
		{
			try
			{
				List<Hotel> hotels = _dataContext.Hotel.Where(c => c.Name.Contains(value)).ToList();
				if (hotels == null) return NotFound();
				return Ok(hotels);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// POST api/<HotelController>
		[HttpPost]
		public IActionResult Post([FromBody] Hotel value)
		{
			try
			{
				_dataContext.Hotel.Add(value);
				_dataContext.SaveChanges();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}

		}

		// PUT api/<HotelController>/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] Hotel value)
		{
			try
			{
				var Hotel = _dataContext.Hotel.FirstOrDefault(b => b.Id == id);
				if (Hotel != null)
				{
					_dataContext.Entry(Hotel).CurrentValues.SetValues(value);
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

		// DELETE api/<HotelController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				var Hotel = _dataContext.Hotel.FirstOrDefault(b => b.Id == id);
				if (Hotel != null)
				{
					_dataContext.Remove(Hotel);
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
