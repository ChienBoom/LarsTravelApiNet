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
	public class MemberPackageController : ControllerBase
	{
		public DataContext _dataContext;
		public MemberPackageController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		// GET: api/<MemberPackageController>
		[HttpGet]
		public IActionResult GetAllMemberPackage()
		{
			try
			{
				return Ok(_dataContext.MemberPackage.ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// GET api/<MemberPackageController>/5
		[HttpGet("{id}")]
		public IActionResult GetMemberPackageById(long id)
		{
			try
			{
				MemberPackage MemberPackage = _dataContext.MemberPackage.FirstOrDefault(b => b.Id == id);
				if (MemberPackage == null) return NotFound();
				return Ok(MemberPackage);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// POST api/<MemberPackageController>
		[HttpPost]
		public IActionResult Post([FromBody] MemberPackage value)
		{
			try
			{
				_dataContext.MemberPackage.Add(value);
				_dataContext.SaveChanges();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}

		}

		// PUT api/<MemberPackageController>/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] MemberPackage value)
		{
			try
			{
				var MemberPackage = _dataContext.MemberPackage.FirstOrDefault(b => b.Id == id);
				if (MemberPackage != null)
				{
					_dataContext.Entry(MemberPackage).CurrentValues.SetValues(value);
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

		// DELETE api/<MemberPackageController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				var MemberPackage = _dataContext.MemberPackage.FirstOrDefault(b => b.Id == id);
				if (MemberPackage != null)
				{
					_dataContext.Remove(MemberPackage);
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

		[HttpGet("search/{value}")]
		public IActionResult SearchMemberPackage(string value)
		{
			try
			{
				List<MemberPackage> memberPackages = _dataContext.MemberPackage.Where(c => c.Name.Contains(value)).ToList();
				if (memberPackages == null) return NotFound();
				return Ok(memberPackages);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

	}
}
