using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHMAS.Backend.Models
{
    public class MedicalHistory
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string Condition { get; set; } = string.Empty;
        public DateTime DiagnosisDate { get; set; }
        public string Notes { get; set; } = string.Empty;

    }
}