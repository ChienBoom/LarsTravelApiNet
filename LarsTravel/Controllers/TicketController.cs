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
	public class TicketController : ControllerBase
	{
		public DataContext _dataContext;
		public TicketController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		// GET: api/<TicketController>
		[HttpGet]
		public IActionResult GetAllTicket()
		{
			try
			{
				return Ok(_dataContext.Ticket.Include(c => c.Tour).ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// GET api/<TicketController>/5
		[HttpGet("{id}")]
		public IActionResult GetTicketById(long id)
		{
			try
			{
				Ticket Ticket = _dataContext.Ticket.FirstOrDefault(b => b.Id == id);
				if (Ticket == null) return NotFound();
				return Ok(Ticket);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

        // POST api/<TicketController>
        [HttpPost]
		public IActionResult Post([FromBody] Ticket value)
		{
			try
			{
				_dataContext.Ticket.Add(value);
				_dataContext.SaveChanges();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}

		}

		// PUT api/<TicketController>/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] Ticket value)
		{
			try
			{
				var Ticket = _dataContext.Ticket.FirstOrDefault(b => b.Id == id);
				if (Ticket != null)
				{
					_dataContext.Entry(Ticket).CurrentValues.SetValues(value);
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

		// DELETE api/<TicketController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				var Ticket = _dataContext.Ticket.FirstOrDefault(b => b.Id == id);
				if (Ticket != null)
				{
					_dataContext.Remove(Ticket);
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

		//[HttpGet("search/{value}")]
		//public IActionResult SearchTicket(string value)
		//{
		//	try
		//	{
		//		List<Ticket> cities = _dataContext.Ticket.Where(c => c.Name.Contains(value)).ToList();
		//		if (cities == null) return NotFound();
		//		return Ok(cities);
		//	}
		//	catch (Exception ex)
		//	{
		//		return BadRequest(ex.Message.ToString());
		//	}
		//}

	}
}
