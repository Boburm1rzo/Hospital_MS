using Hospital.Services;
using Hospital.Views.Dialogs;
using HospitalManagementSystem.Models;
using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Command = MvvmHelpers.Commands.Command;

namespace Hospital.ViewModels
{
    public class PatientsViewModel : BaseViewModel
    {
        private readonly PatientsService _patientsService;
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                SearchPatients(value);
            }
        }
        public ObservableCollection<Patient> Patients { get; }
        public ICommand AddCommand { get; }
        public PatientsViewModel()
        {
            _patientsService = new PatientsService();
            Patients = new ObservableCollection<Patient>();
            AddCommand = new Command(OnAdd);
            Load();
        }
        public void Load()
        {
            var patients = _patientsService.GetPatients();
            Patients.Clear();
            foreach (var patient in patients)
            {
                Patients.Add(patient);
            }
        }
        public void SearchPatients(string searchText)
        {
            var patients = _patientsService.GetPatients(searchText);
            Patients.Clear();
            foreach (var patient in patients)
            {
                Patients.Add(patient);
            }
        }
        public void OnAdd()
        {
            var dialog = new PatientsDialog();
            dialog.ShowDialog();
        }
    }
}
