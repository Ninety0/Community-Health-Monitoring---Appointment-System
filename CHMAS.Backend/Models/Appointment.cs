using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHMAS.Backend.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public Patient? Patient { get; set; } // Navigation property

        public Doctor? Doctor { get; set; } // Navigation property


    }

}