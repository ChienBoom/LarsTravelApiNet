using LarsTravel.Context;
using LarsTravel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LarsTravel.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TicketDetailController : ControllerBase
	{
		public DataContext _dataContext;
		public TicketDetailController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		// GET: api/<TicketDetailController>
		[HttpGet]
		public IActionResult GetAllTicketDetail()
		{
			try
			{
				return Ok(_dataContext.TicketDetail.Include(c => c.Hotel).Include(c => c.MemberPackage).ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// GET api/<TicketDetailController>/5
		[HttpGet("{id}")]
		public IActionResult GetTicketDetailById(long id)
		{
			try
			{
				TicketDetail TicketDetail = _dataContext.TicketDetail.FirstOrDefault(b => b.Id == id);
				if (TicketDetail == null) return NotFound();
				return Ok(TicketDetail);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// POST api/<TicketDetailController>
		[HttpPost]
		public IActionResult Post([FromBody] TicketDetail value)
		{
			try
			{
				_dataContext.TicketDetail.Add(value);
				_dataContext.SaveChanges();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}

		}

		// PUT api/<TicketDetailController>/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] TicketDetail value)
		{
			try
			{
				var TicketDetail = _dataContext.TicketDetail.FirstOrDefault(b => b.Id == id);
				if (TicketDetail != null)
				{
					_dataContext.Entry(TicketDetail).CurrentValues.SetValues(value);
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

		// DELETE api/<TicketDetailController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				var TicketDetail = _dataContext.TicketDetail.FirstOrDefault(b => b.Id == id);
				if (TicketDetail != null)
				{
					_dataContext.Remove(TicketDetail);
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
