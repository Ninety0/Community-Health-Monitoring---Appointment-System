using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHMAS.Backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; }=string.Empty;
        public DateTime CreatedAt { get; set; }
        
    }
}