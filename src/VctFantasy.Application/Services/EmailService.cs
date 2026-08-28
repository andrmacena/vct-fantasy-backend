using System.Text;
using Resend;
using VctFantasy.Application.Interfaces;

namespace VctFantasy.Application.Services
{
    public class EmailService: IEmailService
    {
        public EmailService() { }

        public Task SendEmail(string to, string subject, string body)
        {
            IResend resend = ResendClient.Create("");

            var resp = resend.EmailSendAsync(new EmailMessage()
            {
                From = "onboarding@resend.dev",
                To = "andremacena97@gmail.com",
                Subject = "Bem vindo ao VCT Fantasy!",
                HtmlBody =  File.ReadAllText("D:\\source\\repos\\vct-fantasy-backend\\src\\VctFantasy.Infrastructure\\Services\\welcome-email.html", Encoding.UTF8),
            });

            return resp;
        }

        

    }
}
