using HospitalManagementSystem.Models;
using MvvmHelpers;
using System.Collections.ObjectModel;

namespace Hospital.ViewModels.Dialogs
{
    public class DoctorDetailsViewModel : BaseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public ObservableCollection<Appointment> Appointments { get; }
        public ObservableCollection<DoctorSpecialization> Specializations { get; }

        public DoctorDetailsViewModel(Doctor doctor)
        {
            ArgumentNullException.ThrowIfNull(doctor);
            FirstName = doctor.FirstName;
            LastName = doctor.LastName;
            PhoneNumber = doctor.PhoneNumber;
            Appointments = new ObservableCollection<Appointment>(doctor.Appointments);
            Specializations = new ObservableCollection<DoctorSpecialization>(doctor.Specializations);
        }
    }
}
