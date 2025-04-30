using Microsoft.AspNetCore.Identity.UI.Services;

namespace BidUser.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Console.WriteLine(htmlMessage);
            Console.WriteLine(subject);
            Console.WriteLine(email);
            return Task.CompletedTask;
        }
    }

}
