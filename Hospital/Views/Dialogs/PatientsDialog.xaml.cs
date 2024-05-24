using Hospital.Data;
using Hospital.Services;
using HospitalManagementSystem.Models;
using System.Windows;

namespace Hospital.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for PatientsDialog.xaml
    /// </summary>
    public partial class PatientsDialog : Window
    {
        private readonly PatientsService _patientsService;
        public PatientsDialog()
        {
            InitializeComponent();
            _patientsService= new PatientsService();
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            var patient = new Patient()
            {
                FirstName = FirstNameInput.Text,
                LastName = LastNameInput.Text,
                PhoneNumber = PhoneInput.Text,
                Birthdate = DateOnly.Parse(DateInput.Text),
                Gender = GenderInput.Text == "Female" ? Gender.Female : Gender.Male
            };
            _patientsService.Create(patient);
            Close();
        }
        private void CancelButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
