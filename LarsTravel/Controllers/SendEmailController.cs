using LarsTravel.Context;
using LarsTravel.Models;
using LarsTravel.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace LarsTravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : Controller
    {
        public DataContext _dataContext;
        private readonly ISendMailService _sendMailService;
        public SendEmailController(ISendMailService sendMailService, DataContext dataContext)
        {
            _sendMailService = sendMailService;
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult Send()
        {
            MailContent content = new MailContent
            {
                To = "virusss1241@gmail.com",
                Subject = "Kiểm tra thử",
                Body = "<p><strong>Xin chào</strong></p>"
            };
            _sendMailService.SendMail(content);
            return Ok(content);
        }

        [HttpPost]
        public IActionResult Send([FromBody] MailContent content)
        {
            //MailContent content = new MailContent
            //{
            //    To = "virusss1241@gmail.com",
            //    Subject = "Kiểm tra thử",
            //    Body = "<p><strong>Xin chào</strong></p>"
            //};
            _sendMailService.SendMail(content);
            return Ok(content);
        }

        [HttpPost("RecoverPassword")]
        public IActionResult RecoverPassword([FromBody] Account value)
        {
            ResponseData response = new ResponseData();
            try
            {
                response.Success = true;
                var User = _dataContext.User.FirstOrDefault(b => b.Username == value.Username);
                if (User != null)
                {
                    MailContent content = new MailContent
                    {
                        To = value.Username,
                        Subject = "LarsTravel - Xác minh mật khẩu",
                        Body = "Mật khẩu của bạn là:" + User.Password
                    };
                    _sendMailService.SendMail(content);
                    response.Message = "Success";
                    response.ResultData = User.Role;
                    return Ok(response);
                }
                else
                {
                    response.Message = "Faild";
                    response.ResultData = null;
                    return NotFound(response);
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

    }
}
