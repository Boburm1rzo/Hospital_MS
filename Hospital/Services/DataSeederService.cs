using Bogus;
using Bogus.DataSets;
using Hospital.Data;
using HospitalManagementSystem.Models;

namespace Hospital.Services
{
    public class DataSeederService : Faker
    {
        private static Faker faker = new();

        public static void SeedDataBase()
        {
            using var context = new HospitalDBContext();

            CreatePatients(context);
            CreateDoctors(context);
            CreateSpecializations(context);
            CreateDoctorSpecializations(context);
            CreateAppointments(context);
            CreateVisits(context);

        }
        static void CreatePatients(HospitalDBContext context)
        {
            if (context.Patients.Any())
                return;

            for (int i = 0; i < 100; i++)
            {
                var patient = new Patient();
                var (gender, genderName) = GetGender();
                patient.FirstName = faker.Name.FirstName(genderName);
                patient.LastName = faker.Name.LastName(genderName);
                patient.PhoneNumber = faker.Phone.PhoneNumber("+998-##-###-##-##");
                patient.Gender = gender;
                patient.Birthdate = GetRandomDate();

                context.Patients.Add(patient);
            }
            context.SaveChanges();
        }
        static void CreateDoctors(HospitalDBContext context)
        {
            if (context.Doctors.Any()) return;

            for (int i = 0; i < 20; i++)
            {
                var doctor = new Doctor();
                var (gender, genderName) = GetGender();
                doctor.FirstName = faker.Name.FirstName(genderName);
                doctor.LastName = faker.Name.LastName(genderName);
                doctor.PhoneNumber = faker.Phone.PhoneNumber("+998-##-###-##-##");

                context.Doctors.Add(doctor);
            }
            context.SaveChanges();
        }
        static void CreateSpecializations(HospitalDBContext context)
        {
            if (context.Specializations.Any()) return;

            var values = Enum.GetNames(typeof(DoctorSpecializationType));
            foreach (var value in values)
            {
                var specialization = new Specialization()
                {
                    Name = value,
                    Description = faker.Lorem.Text()
                };

                context.Specializations.Add(specialization);
            }

            context.SaveChanges();
        }
        static void CreateDoctorSpecializations(HospitalDBContext context)
        {
            if (context.DoctorSpecialization.Any())
                return;

            var specializationsIds = context.Specializations.Select(x => x.Id).ToArray();
            var doctorsIds = context.Doctors.Select(x => x.Id).ToArray();

            foreach (var doctorId in doctorsIds)
            {
                var specializationsCount = faker.Random.Number(1, 3);
                HashSet<int> specializations = new();

                for (int i = 0; i < specializationsCount; i++)
                {
                    var randomSpecialization = faker.PickRandom(specializationsIds);
                    specializations.Add(randomSpecialization);
                }

                foreach (var specializationId in specializations)
                {
                    var doctorSpecialization = new DoctorSpecialization()
                    {
                        DoctorId = doctorId,
                        SpecializationId = specializationId
                    };
                    context.DoctorSpecialization.Add(doctorSpecialization);
                }
            }
            context.SaveChanges();
        }
        static void CreateAppointments(HospitalDBContext context)
        {
            if (context.Appointments.Any())
                return;

            var doctorIds = context.Doctors.Select(d => d.Id).ToArray();
            var patientIds = context.Patients.Select(p => p.Id).ToArray();
            var minDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-2));
            var maxDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(2));
            var minTime = TimeOnly.FromTimeSpan(TimeSpan.FromHours(8));
            var maxTime = TimeOnly.FromTimeSpan(TimeSpan.FromHours(20));

            foreach (var patientId in patientIds)
            {
                var appointmentsCount = faker.Random.Number(1, 5);
                for (var i = 0; i < appointmentsCount; i++)
                {
                    var randomDoctor = faker.PickRandom(doctorIds);
                    var appointment = new Appointment()
                    {
                        Comments = faker.Lorem.Text(),
                        Date = faker.Date.BetweenDateOnly(minDate, maxDate),
                        Time = faker.Date.BetweenTimeOnly(minTime, maxTime),
                        DoctorId = randomDoctor,
                        PatientId = patientId
                    };
                    appointment.Status = GetRandomStatus(appointment);
                    context.Appointments.Add(appointment);
                }
            }
            context.SaveChanges();
        }
        static void CreateVisits(HospitalDBContext context)
        {
            if (context.Visits.Any())
                return;
            var appointmentsIds = context.Appointments
                .Where(x => x.Status == AppointmentStatus.Closed)
                .Select(x => x.Id)
                .ToArray();

            foreach (var appointmentId in appointmentsIds)
            {
                var visit = new Visit()
                {
                    AppointmentId = appointmentId,
                    Comments = faker.Lorem.Sentences(),
                    TotalDue = faker.Random.Number(100000, 1500000),
                };
                context.Visits.Add(visit);
            }
            context.SaveChanges();
        }


        static AppointmentStatus GetRandomStatus(Appointment appointment)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var now = TimeOnly.FromDateTime(DateTime.Now);
            if (appointment.Date > today && appointment.Time > now)
                return AppointmentStatus.Pending;

            var randomStatus = faker.Random.Number(1, 10);

            return randomStatus % 2 == 0 ? AppointmentStatus.Cancelled : AppointmentStatus.Closed;
        }
        static (Gender, Name.Gender) GetGender()
        {
            var gender = faker.Random.Enum<Gender>();
            var genderName = gender == Gender.Male ? Name.Gender.Male : Name.Gender.Female;
            return (gender, genderName);
        }
        static DateOnly GetRandomDate()
        {
            var minDate = new DateOnly(1940, 1, 1);
            var maxDate = new DateOnly(2022, 1, 1);
            return faker.Date.BetweenDateOnly(minDate, maxDate);
        }
    }
}
