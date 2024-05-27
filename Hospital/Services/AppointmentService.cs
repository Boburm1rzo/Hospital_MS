using Hospital.Data;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Services
{
    public class AppointmentService
    {
        private readonly HospitalDBContext _context;
        public AppointmentService()
        {
            _context = new HospitalDBContext();
        }
        public List<Appointment> GetAppointments()
        {
            var query = _context.Appointments
                .AsNoTracking()
                .Include(x => x.Doctor)
                .AsQueryable();
            return query.ToList();
        }

    }
}
