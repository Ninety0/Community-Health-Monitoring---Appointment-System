using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CHMAS.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace CHMAS.Backend.Data
{
    public class DataContext(DbContextOptions<DataContext> options): DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<AppointmentNote> AppointmentNotes => Set<AppointmentNote>();
        public DbSet<MedicalHistory> MedicalHistories => Set<MedicalHistory>();
    }
}