using Hospital.Data;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
