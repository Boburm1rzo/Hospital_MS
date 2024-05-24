using Hospital.Data;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Services;

public class PatientsService
{
    private readonly HospitalDBContext _context;

    public PatientsService()
    {
        _context = new HospitalDBContext();
    }
    public List<Patient> GetPatients(string searchText = "")
    {
        var query = _context.Patients
            .Include(x=>x.Appointments)
            .ThenInclude(x=>x.Doctor)
            .Include(x=>x.Appointments)
            .ThenInclude(x=>x.Visit)
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchText))
        {
            query = _context.Patients.Where(x => x.FirstName.Contains(searchText) ||
                                            x.LastName.Contains(searchText) ||
                                            x.PhoneNumber.Contains(searchText));
        }
        return query.ToList();
    }
    public Patient? GetPatientsById(int id)
        => _context.Patients.FirstOrDefault(x => x.Id == id);
    public void Create(Patient patient)
    {
        _context.Patients.Add(patient);
        _context.SaveChanges();
    }
    public void Update(Patient patient)
    {
        _context.Patients.Update(patient);
        _context.SaveChanges();
    }
    public void Delete(Patient patient)
    {
        _context.Patients.Remove(patient);
        _context.SaveChanges();
    }
}
