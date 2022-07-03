
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Domain.Models.Labs;
using Domain.Models.Users;
using Domain.SeedData;
using Domain.Models.Pharmacy;

namespace Domain.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //table per hierarchy, the table "Users" will have a column named "Role"

            //builder.Entity<Doctor>().Property(e => e.specialization).HasColumnName("Specialization");
            //builder.Entity<Nurse>().Property(e => e.Specialization).HasColumnName("Specialization");
            //builder.Entity<Doctor>().Property(e => e.Degree).HasColumnName("Degree");
            //builder.Entity<Nurse>().Property(e => e.Degree).HasColumnName("Degree");

            builder.Entity<User>()
                .ToTable("Users")
                .HasDiscriminator<string>("Role")
                .HasValue<Patient>("Patient")
                .HasValue<Nurse>("Nurse")
                .HasValue<Admin>("Admin")
                .HasValue<Receptionist>("Receptionist")
                .HasValue<Doctor>("Doctor");

            builder.Entity<TestParameter>()
                 .ToTable("TestParameters")
                 .HasDiscriminator<string>("Type")
                 .HasValue<TestParameterCategorical>("Categorical")
                 .HasValue<TestParameterNumerical>("Numerical");

            builder.Entity<TestDetails>()
                .ToTable("TestDetails")
                .HasDiscriminator<string>("Type")
                .HasValue<TestDetailsCategorical>("Categorical")
                .HasValue<TestDetailsNumerical>("Numerical");
            ModelBuilderExtensions.Seed(builder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Test> Tests { get; set; }

        public DbSet<PatientTest> patientTests { get; set; }
        public DbSet<TestDetailsCategorical> TestDetailsCategoricals { get; set; }
        public DbSet<TestDetailsNumerical> TestDetailsNumericals { get; set; }

        public DbSet<TestParameterCategorical> TestParametersCategoricals { get; set; }
        public DbSet<TestParameterNumerical> TestParameterNumericals { get; set; }
        public DbSet<LabRequest> LabRequests { get; set; }
        public DbSet<PatientTest> PatientTests { get; set; }
        public DbSet<ScanRequest> ScanRequests { get; set; }
        public DbSet<PatientScan> PatientScans { get; set; }
        public DbSet<ScanImage> ScanImages { get; set; }




        public DbSet<Bill> Bills { get; set; }

        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionItem> PrescriptionItems { get; set; }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockMedicine> StockMedicines { get; set; }

        public DbSet<Appointment> Appointments { get; set; }
        //public DbSet<BloodElement> Bloods { get; set; }
        //public DbSet<Donner> Donners { get; set; }
        //public DbSet<BloodBank> BloodBanks { get; set; }

        public DbSet<Note> Notes { get; set; }
        public DbSet<IndoorPatientRecord> IndoorPatients { get; set; }
         public DbSet<ClinicPatientRecord> ClinicPatients { get; set; }
        public DbSet<VitalSign> VitalSigns { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Bed> Beds { get; set; }

       public DbSet<Room> Rooms { get; set; }


    }
}
