using LarsTravel.Context;
using LarsTravel.Models;
using LarsTravel.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LarsTravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : Controller
    {
        private readonly ISendMailService _sendMailService;
        public SendEmailController(ISendMailService sendMailService)
        {
            _sendMailService = sendMailService;
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
    }
}
