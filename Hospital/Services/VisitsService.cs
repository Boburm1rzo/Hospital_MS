using Hospital.Data;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Services
{

    public class VisitsService
    {
        private readonly HospitalDBContext _context;
        public VisitsService()
        {
            _context = new HospitalDBContext();
        }
        public List<Visit> GetVisits()
        {
            var query = _context.Visits
                .AsNoTracking()
                .AsQueryable();
            return query.ToList();
        }
        public void Create(Visit visit)
        {
            _context.Visits.Add(visit);
            _context.SaveChanges();
        }
    }
}
