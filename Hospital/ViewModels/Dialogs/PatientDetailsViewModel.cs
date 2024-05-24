using HospitalManagementSystem.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hospital.ViewModels.Dialogs
{
    public class PatientDetailsViewModel:BaseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public ObservableCollection<Appointment> Appointments { get;  }
        public ObservableCollection<Visit> Visits { get;  }
        public ICommand SaveCommand { get;}
        public PatientDetailsViewModel(Patient patient)
        {
            ArgumentNullException.ThrowIfNull(patient);
            FirstName = patient.FirstName;
            LastName = patient.LastName;
            Birthdate = patient.Birthdate;
            PhoneNumber = patient.PhoneNumber;
            Gender = patient.Gender;
            Appointments = new ObservableCollection<Appointment>(patient.Appointments);
            var visits=patient.Appointments
                .Where(x=>x.Visit!=null)
                .Select(x=>x.Visit)
                .ToList();
            Visits=new ObservableCollection<Visit>(visits);
            SaveCommand = new Command(OnSave);
        }
        private void OnSave()
        {

        }
    }
}
