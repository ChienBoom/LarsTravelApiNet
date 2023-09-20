using LarsTravel.Models;
using System.Threading.Tasks;

namespace LarsTravel.Service
{
    public interface ISendMailService
    {
        Task SendMail(MailContent mailContent);

        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
