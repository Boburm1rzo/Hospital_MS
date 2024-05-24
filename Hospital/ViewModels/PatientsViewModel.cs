using Hospital.Services;
using Hospital.Views.Dialogs;
using HospitalManagementSystem.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
        private Patient _selectedPatient;
        public Patient SelectedPatient
        {
            get=> _selectedPatient;
            set=>SetProperty(ref _selectedPatient, value);
        }
        public ObservableCollection<Patient> Patients { get; }
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ShowDetailsCommand { get; }
        public PatientsViewModel()
        {
            _patientsService = new PatientsService();
            Patients = new ObservableCollection<Patient>();
            AddCommand = new Command(OnAdd);
            EditCommand = new Command<Patient>(OnEdit);
            DeleteCommand = new Command<Patient>(OnDelete);
            ShowDetailsCommand = new Command(OnShowDetails);

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
        public void OnEdit(Patient patient)
        {
            var dialog = new PatientsDialog();
            dialog.ShowDialog();
        }
        public void OnDelete(Patient patient)
        {
            var dialog = new PatientsDialog();
            dialog.ShowDialog();
        }
        public void OnShowDetails()
        {
            if (SelectedPatient is null)
                return;

            var dialog = new PatientsDetailsDialog(SelectedPatient);
            dialog.ShowDialog();
        }

    }
}
