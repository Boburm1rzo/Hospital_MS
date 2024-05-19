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
        public List<Specialization> GetAll()
        {
            return _context.Specializations.ToList();
        }


    }
}
