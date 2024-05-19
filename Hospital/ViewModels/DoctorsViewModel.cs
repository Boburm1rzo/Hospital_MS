using Hospital.Services;
using Hospital.Views.Dialogs;
using HospitalManagementSystem.Models;
using MvvmHelpers;
using System.Collections.ObjectModel;
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
            foreach(Specialization specialization in specializations)
            {
                Specializations.Add(specialization);
            }

        }
         
        private void Search()
        {
            var doctors = _doctorsService.GetDoctors(_searchText,_selectedSpecialization?.Id);
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
    }
}
