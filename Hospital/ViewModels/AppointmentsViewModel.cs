using Hospital.Services;
using HospitalManagementSystem.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hospital.ViewModels
{
    public class AppointmentsViewModel:BaseViewModel
    {
        private readonly AppointmentService _appointmentService;
        public ObservableCollection<Appointment > Appointments { get;}
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
