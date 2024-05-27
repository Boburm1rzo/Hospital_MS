using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data
{
    internal class HospitalDBContext : DbContext
    {
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }
        public virtual DbSet<DoctorSpecialization> DoctorSpecialization { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-FB3OGEQ;Initial Catalog=Hospital_MS;Integrated Security=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        public HospitalDBContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .ToTable(nameof(Patient));
            modelBuilder.Entity<Patient>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Doctor>()
                .ToTable(nameof(Doctor))
                .HasKey(x => x.Id);

            modelBuilder.Entity<Specialization>()
                .ToTable(nameof(Specialization))
                .HasKey(x => x.Id);

            modelBuilder.Entity<Visit>()
                .ToTable(nameof(Visit))
                .HasKey(x => x.Id);
            modelBuilder.Entity<Visit>()
                .HasOne(x => x.Appointment)
                .WithOne(x => x.Visit)
                .HasForeignKey<Visit>(x => x.AppointmentId);
            modelBuilder.Entity<Visit>()
                .Property(x => x.TotalDue)
                .HasColumnType("Money");

            modelBuilder.Entity<Appointment>()
                .ToTable(nameof(Appointment))
                .HasKey(x => x.Id);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Visit)
                .WithOne(x => x.Appointment)
                .HasForeignKey<Visit>(e => e.AppointmentId);

            modelBuilder.Entity<DoctorSpecialization>()
                .ToTable(nameof(DoctorSpecialization));
            modelBuilder.Entity<Doctor>()
                .HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
