using Hospital.Data;
using Hospital.Services;
using Hospital.Views.Dialogs;
using HospitalManagementSystem.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Command = MvvmHelpers.Commands.Command;

namespace Hospital.ViewModels
{
    public class DoctorsViewModel : BaseViewModel
    {
        private readonly DoctorsService _doctorsService;
        private ObservableCollection<Doctor> Doctors { get; }
        private string _searchText;
        public ICommand AddCommand { get; }
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                Search(value);
            }
        }
        public DoctorsViewModel()
        {
            AddCommand = new Command(OnAdd);
            _doctorsService = new DoctorsService();
            Doctors = new ObservableCollection<Doctor>();

            Load();
        }
        public void Load()
        {
            var doctors = _doctorsService.GetDoctors();
            Doctors.Clear();
            foreach (Doctor doctor in doctors)
            {
                Doctors.Add(doctor);
            }
        }
        public void Search(string searchText)
        {
            var doctors = _doctorsService.GetDoctors(searchText);
            Doctors.Clear();
            foreach (Doctor doctor in doctors)
            {
                Doctors.Add(doctor);
            }
        }
        public void OnAdd()
        {
            var dialog = new DoctorsDialog();
            dialog.ShowDialog();
        }
    }
}
