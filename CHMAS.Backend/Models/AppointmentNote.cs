using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHMAS.Backend.Models
{
    public class AppointmentNote
    {
        public int Id { get; set; }
        public string Notes { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;
        public string Prescription { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public int? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; } // Navigation property
    }
}