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
	public class CommentController : ControllerBase
	{
		public DataContext _dataContext;
		public CommentController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		// GET: api/<CommentController>
		[HttpGet]
		public IActionResult GetAllComment()
		{
			try
			{
				return Ok(_dataContext.Comment.Include(c => c.User).Include(c => c.Evaluate).ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// GET api/<CommentController>/5
		[HttpGet("{id}")]
		public IActionResult GetCommentById(long id)
		{
			try
			{
				Comment Comment = _dataContext.Comment.FirstOrDefault(b => b.Id == id);
				if (Comment == null) return NotFound();
				return Ok(Comment);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// POST api/<CommentController>
		[HttpPost]
		public IActionResult Post([FromBody] Comment value)
		{
			try
			{
				_dataContext.Comment.Add(value);
				_dataContext.SaveChanges();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}

		}

		// PUT api/<CommentController>/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] Comment value)
		{
			try
			{
				var Comment = _dataContext.Comment.FirstOrDefault(b => b.Id == id);
				if (Comment != null)
				{
					_dataContext.Entry(Comment).CurrentValues.SetValues(value);
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

		// DELETE api/<CommentController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				var Comment = _dataContext.Comment.FirstOrDefault(b => b.Id == id);
				if (Comment != null)
				{
					_dataContext.Remove(Comment);
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
