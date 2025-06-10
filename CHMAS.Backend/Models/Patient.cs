using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHMAS.Backend.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public int? UserId { get; set; }

        public string Age { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public string MedicalHistory { get; set; } = string.Empty;
        public User? User { get; set; }
        
    }
}