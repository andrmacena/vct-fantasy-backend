using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace VctFantasy.Domain.Util
{
    public class AppSettings
    {
        public string DefaultConnection { get; set; }
        public string SecretKey { get; set; }
    }
}
