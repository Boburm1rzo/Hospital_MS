using Hospital.Services;
using HospitalManagementSystem.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Windows.Input;

namespace Hospital.ViewModels.Dialogs
{
    public class PatientDialogViewModel : BaseViewModel
    {
        private readonly PatientsService _patientsService;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthdate { get ; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public ICommand SaveCommand { get; }
        public PatientDialogViewModel()
        {
            _patientsService = new PatientsService();
            SaveCommand = new Command(OnSave);
        }
        private void OnSave()
        {
            var patient = new Patient()
            {
                FirstName=this.FirstName,
                LastName=this.LastName,
                Gender=this.Gender, 
                PhoneNumber=this.PhoneNumber,
                Birthdate=this.Birthdate,
            };
                _patientsService.Create(patient);
        }
    }
}
