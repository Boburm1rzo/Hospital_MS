using Hospital.Services;
using Hospital.Views.Dialogs;
using HospitalManagementSystem.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Command = MvvmHelpers.Commands.Command;

namespace Hospital.ViewModels
{
    public class DoctorsViewModel : BaseViewModel
    {
        private readonly DoctorsService _doctorsService;
        private readonly SpecializationsService _specializationsService;
        public ObservableCollection<Doctor> Doctors { get; }
        public ObservableCollection<Specialization> Specializations { get; }
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ShowDetailsCommand { get; }
        private Doctor _selectedDoctor;
        public Doctor SelectedDoctor
        {
            get => _selectedDoctor;
            set=>SetProperty(ref _selectedDoctor, value);
        }

        private Specialization _selectedSpecialization;
        public Specialization SelectedSpecialization
        {
            get => _selectedSpecialization;
            set
            {
                SetProperty(ref _selectedSpecialization, value);
                Search();
            }
        }
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                Search();
            }
        }
        public DoctorsViewModel()
        {
            AddCommand = new Command(OnAdd);
            _doctorsService = new DoctorsService();
            _specializationsService = new SpecializationsService();
            Doctors = new ObservableCollection<Doctor>();
            Specializations = new ObservableCollection<Specialization>();
            EditCommand = new Command<Doctor>(OnEdit);
            DeleteCommand = new Command<Doctor>(OnDelete);
            ShowDetailsCommand = new Command(OnShowDetails);
            Load();
        }
        private void Load()
        {
            var doctors = _doctorsService.GetDoctors();
            var specializations = _specializationsService.GetAll();
            Doctors.Clear();
            Specializations.Clear();
            foreach (Doctor doctor in doctors)
            {
                Doctors.Add(doctor);
            }
            foreach (Specialization specialization in specializations)
            {
                Specializations.Add(specialization);
            }

        }

        private void Search()
        {
            var doctors = _doctorsService.GetDoctors(_searchText, _selectedSpecialization?.Id);
            Doctors.Clear();
            foreach (Doctor doctor in doctors)
            {
                Doctors.Add(doctor);
            }
        }
        private void OnAdd()
        {
            var dialog = new DoctorsDialog();
            dialog.ShowDialog();
        }
        private void OnEdit(Doctor doctor)
        {
            var dialog = new DoctorsDialog();
            dialog.ShowDialog();
        }
        private void OnDelete(Doctor doctor)
        {
            var result = MessageBox.Show($"Are you sure you want delete:{doctor.LastName} {doctor.FirstName}?" , 
            "Confirm your action",
                MessageBoxButton.YesNo, 
                MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                return;
            }
            _doctorsService.Delete(doctor);
            MessageBox.Show(
               $"Patient: {doctor.FirstName} {doctor.LastName} successfully deleted.",
               "Success",
               MessageBoxButton.OK,
               MessageBoxImage.Information);
        }
        private void OnShowDetails()
        {
            if (SelectedDoctor is null)
                return;
            var dialog = new DoctorsDetailsDialog(SelectedDoctor);
            dialog.ShowDialog();
        }
    }
}
