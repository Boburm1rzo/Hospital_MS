using Hospital.Data;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
namespace Hospital.Services;

public class DoctorsService
{
    private readonly HospitalDBContext _context;

    public DoctorsService()
    {
        _context = new HospitalDBContext();
    }
    public List<Doctor> GetDoctors(string searchText = "", int? specializationId = null)
    {
        var query = _context.Doctors
            .AsNoTracking()
            .AsQueryable();
        if (!string.IsNullOrEmpty(searchText))
        {
            query = _context.Doctors.Where(x => x.FirstName.Contains(searchText) ||
                                            x.LastName.Contains(searchText) ||
                                            x.PhoneNumber.Contains(searchText));
        }
        return query.ToList();
    }
    public Doctor? GetDoctorById(int id) => _context.Doctors.FirstOrDefault(x => x.Id == id);
    public void Create(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
        _context.SaveChanges();
    }
    public void Update(Doctor doctor)
    {
        _context.Doctors.Update(doctor);
        _context.SaveChanges();
    }
    public void Delete(Doctor doctor)
    {
        _context.Doctors.Remove(doctor);
        _context.SaveChanges();
    }

}
