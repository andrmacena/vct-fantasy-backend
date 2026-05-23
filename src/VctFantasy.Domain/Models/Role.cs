using System;
using System.Collections.Generic;
using System.Text;

namespace VctFantasy.Domain.Models
{
    public class Role
    {
        public enum RoleType
        {
            Admin = 1,
            User = 2
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<User>? Users { get; set; }
    }
}
