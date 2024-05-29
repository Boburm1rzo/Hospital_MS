using Hospital.Services;
using HospitalManagementSystem.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Windows;
using System.Windows.Input;

namespace Hospital.ViewModels.Dialogs
{
    public class PatientsUpdateViewModel : BaseViewModel
    {
        private readonly PatientsService _patientsService;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public int Id { get; set; }
        public ICommand SaveCommand { get; }
        public PatientsUpdateViewModel(Patient patient)
        {
            ArgumentNullException.ThrowIfNull(patient);
            _patientsService = new PatientsService();
            SaveCommand = new Command(OnSave);
            FirstName = patient.FirstName;
            LastName = patient.LastName;
            Birthdate = patient.Birthdate;
            PhoneNumber = patient.PhoneNumber;
            Gender = patient.Gender;
            Id = patient.Id;
        }
        private void OnSave()
        {
            var patient = new Patient()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Birthdate = this.Birthdate,
                PhoneNumber = this.PhoneNumber,
                Gender = this.Gender,
                Id = this.Id
            };
            _patientsService.Update(patient);
            MessageBox.Show($"Patient {FirstName} {LastName} was successfully updated!", "Success", MessageBoxButton.OK, MessageBoxImage.Question);
        }


    }
}
