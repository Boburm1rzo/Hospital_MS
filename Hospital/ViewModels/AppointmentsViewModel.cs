using Hospital.Services;
using Hospital.Views.Dialogs;
using HospitalManagementSystem.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hospital.ViewModels
{
    public class AppointmentsViewModel : BaseViewModel
    {
        private readonly AppointmentService _appointmentService;
        public ObservableCollection<Appointment> Appointments { get; }
        public ICommand AddCommand { get; }
        public AppointmentsViewModel()
        {
            _appointmentService = new AppointmentService();
            Appointments = new ObservableCollection<Appointment>();
            AddCommand = new Command(OnAdd);
            Load();
        }
        public void OnAdd()
        {
            var dialog = new AppointmentsDialog();
        }
        public void Load()
        {
            var appointments = _appointmentService.GetAppointments();
            Appointments.Clear();
            foreach (Appointment appointment in appointments)
            {
                Appointments.Add(appointment);
            }
        }
    }
}
