using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHMAS.Backend.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public int? UserId { get; set; }

        public string Specialty { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public int AvailabilitySlots { get; set; }

        public User? User { get; set; }
    }
}