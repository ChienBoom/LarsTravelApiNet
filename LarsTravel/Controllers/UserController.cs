using LarsTravel.Context;
using LarsTravel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResponseData = LarsTravel.Models.ResponseData;

namespace LarsTravel.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		public DataContext _dataContext;
		public UserController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public IActionResult GetAllUser()
		{
			try
			{
				return Ok(_dataContext.User.Include(c => c.Tickets).ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetUserById(long id)
		{
			try
			{
				User User = _dataContext.User.FirstOrDefault(b => b.Id == id);
				if (User == null) return NotFound();
				return Ok(User);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

        [HttpPost]
		public IActionResult Post([FromBody] User value)
		{
			try
			{
				_dataContext.User.Add(value);
				_dataContext.SaveChanges();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}

		}

		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] User value)
		{
			try
			{
				var User = _dataContext.User.FirstOrDefault(b => b.Id == id);
				if (User != null)
				{
					_dataContext.Entry(User).CurrentValues.SetValues(value);
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

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				var User = _dataContext.User.FirstOrDefault(b => b.Id == id);
				if (User != null)
				{
					_dataContext.Remove(User);
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

		[HttpPost("/checkUser")]
		public IActionResult CheckUser([FromBody] Account value)
		{
            try
            {
                var User = _dataContext.User.FirstOrDefault(b => b.Username == value.Username);
                if (User != null)
                {
                    if(User.Password.Equals(value.Password)) {
                        return Ok("Success");
                    }
                    else return Ok("Faild");
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost("/checkEmailExis")]
        public async Task<IActionResult> checkEmailExis([FromBody] Account value)
        {
			ResponseData response = new ResponseData();
            try
            {
				response.Success = true;
                var User = _dataContext.User.FirstOrDefault(b => b.Username == value.Username);
                if (User != null)
                {
					response.Message = "Faild";
					response.ResultData = null;
                    return Ok(response);
                }
				else
				{
                    response.Message = "Success";
                    response.ResultData = null;
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.ResultData = null;
                return BadRequest(response);
            }
        }

        [HttpPost("/checkAccountLogin")]
        public async Task<IActionResult> checkAccountLogin([FromBody] Account value)
        {
            ResponseData response = new ResponseData();
            try
            {
                response.Success = true;
                var User = _dataContext.User.FirstOrDefault(b => b.Username == value.Username);
                if (User != null)
                {
					if(value.Password == User.Password)
					{
                        response.Message = "Success";
                        response.ResultData = null;
                        return Ok(response);
                    }
					else
					{
                        response.Message = "Faild";
                        response.ResultData = null;
                        return Ok(response);
                    }
                }
                else
                {
                    response.Message = "Faild";
                    response.ResultData = null;
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.ResultData = null;
                return BadRequest(response);
            }
        }

        [HttpGet("search/{value}")]
        public IActionResult SearchUser(string value)
        {
            try
            {
                List<User> users = _dataContext.User.Where(c => c.Name.Contains(value)).ToList();
                if (users == null) return NotFound();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

    }
}
