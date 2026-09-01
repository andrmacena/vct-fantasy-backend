using Microsoft.Extensions.Options;
using Resend;
using System.Text;
using VctFantasy.Application.Interfaces;
using VctFantasy.Domain.Util;

namespace VctFantasy.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly AppSettings _appSettings;
        public EmailService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public Task SendEmail(string to, string subject, string body)
        {
            IResend resend = ResendClient.Create(_appSettings.Resendkey);

            var welcomeFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Services","welcome-email.html");
            
            var resp = resend.EmailSendAsync(new EmailMessage()
            {
                From = "onboarding@resend.dev",
                To = "andremacena97@gmail.com",
                Subject = "Bem vindo ao VCT Fantasy!",
                HtmlBody = File.ReadAllText(welcomeFile, Encoding.UTF8),
            });

            return resp;
        }



    }
}
