using System;
using System.Collections.Generic;
using System.Text;

namespace VctFantasy.Application.Interfaces
{
    public interface IEmailService
    {
        public Task SendEmail(string to, string subject, string body);
    }
}
