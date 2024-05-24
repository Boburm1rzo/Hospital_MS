using Hospital.Services;
using HospitalManagementSystem.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hospital.ViewModels.Dialogs
{
    public class PatientDialogViewModel : BaseViewModel
    {
        private readonly PatientsService _patientsService;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthdate { get; set; }
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
                FirstName = this.FirstName,
                LastName = this.LastName,
                Birthdate = this.Birthdate,
                PhoneNumber = this.PhoneNumber,
                Gender = this.Gender
            };
            _patientsService.Create(patient);
        }
    }
}
