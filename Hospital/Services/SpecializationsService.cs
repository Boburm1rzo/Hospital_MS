using Hospital.Data;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Services
{
    public class SpecializationsService
    {
        private readonly HospitalDBContext _context;
        public SpecializationsService()
        {
            _context = new HospitalDBContext();
        }
        public List<Specialization> GetAll(string SearchText = "")
        {
            var query = _context.Specializations
                .AsNoTracking()
                .AsQueryable();
            if (!string.IsNullOrEmpty(SearchText))
            {
                query = _context.Specializations.Where(x => x.Name.Contains(SearchText));
            }

            return query.ToList();
        }
        public void Create(Specialization specialization)
        {
            _context.Specializations.Add(specialization);
            _context.SaveChanges();
        }


    }
}
