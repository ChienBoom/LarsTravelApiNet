using LarsTravel.Context;
using LarsTravel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LarsTravel.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EvaluateController : ControllerBase
	{
		public DataContext _dataContext;
		public EvaluateController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		// GET: api/<EvaluateController>
		[HttpGet]
		public IActionResult GetAllEvaluate()
		{
			try
			{
				return Ok(_dataContext.Evaluate.ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// GET api/<EvaluateController>/5
		[HttpGet("{id}")]
		public IActionResult GetEvaluateById(long id)
		{
			try
			{
				Evaluate Evaluate = _dataContext.Evaluate.FirstOrDefault(b => b.Id == id);
				if (Evaluate == null) return NotFound();
				return Ok(Evaluate);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// POST api/<EvaluateController>
		[HttpPost]
		public IActionResult Post([FromBody] Evaluate value)
		{
			try
			{
				_dataContext.Evaluate.Add(value);
				_dataContext.SaveChanges();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}

		}

		// PUT api/<EvaluateController>/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] Evaluate value)
		{
			try
			{
				var Evaluate = _dataContext.Evaluate.FirstOrDefault(b => b.Id == id);
				if (Evaluate != null)
				{
					_dataContext.Entry(Evaluate).CurrentValues.SetValues(value);
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

		// DELETE api/<EvaluateController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				var Evaluate = _dataContext.Evaluate.FirstOrDefault(b => b.Id == id);
				if (Evaluate != null)
				{
					_dataContext.Remove(Evaluate);
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
