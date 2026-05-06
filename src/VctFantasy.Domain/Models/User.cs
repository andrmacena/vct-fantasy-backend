using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace VctFantasy.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? PasswordSalt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [JsonIgnore]
        public int? RoleID { get; set; }
        public Role? Role { get; set; }
        public Team? Team { get; set; }


    }
}
