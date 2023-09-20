using LarsTravel.Context;
using LarsTravel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LarsTravel.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TourController : ControllerBase
	{
		public DataContext _dataContext;
		public TourController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		// GET: api/<TourController>
		[HttpGet]
		public IActionResult GetAllTour()
		{
			try
			{
				return Ok(_dataContext.Tour.Include(c => c.Evaluate).ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// GET api/<TourController>/5
		[HttpGet("{id}")]
		public IActionResult GetTourById(long id)
		{
			try
			{
				Tour Tour = _dataContext.Tour.FirstOrDefault(b => b.Id == id);
				if (Tour == null) return NotFound();
				return Ok(Tour);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

        //[HttpGet("/search/{value}")]
        //public IActionResult SearchTour(string value)
        //{
        //    try
        //    {
        //        List<Tour> tours = _dataContext.Tour.Where(c => c.Name.Contains(value)).ToList();
        //        if (tours == null) return NotFound();
        //        return Ok(tours);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message.ToString());
        //    }
        //}

        // POST api/<TourController>
        [HttpPost]
		public IActionResult Post([FromBody] Tour value)
		{
			try
			{
				_dataContext.Tour.Add(value);
				_dataContext.SaveChanges();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}

		}

		// PUT api/<TourController>/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] Tour value)
		{
			try
			{
				var Tour = _dataContext.Tour.FirstOrDefault(b => b.Id == id);
				if (Tour != null)
				{
					_dataContext.Entry(Tour).CurrentValues.SetValues(value);
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

		// DELETE api/<TourController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				var Tour = _dataContext.Tour.FirstOrDefault(b => b.Id == id);
				if (Tour != null)
				{
					_dataContext.Remove(Tour);
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
