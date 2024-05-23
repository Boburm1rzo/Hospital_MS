using Hospital.Data;
using HospitalManagementSystem.Models;
using System.Windows;

namespace Hospital.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for PatientsDialog.xaml
    /// </summary>
    public partial class PatientsDialog : Window
    {
        private readonly HospitalDBContext _context;
        public PatientsDialog()
        {
            InitializeComponent();
            _context = new HospitalDBContext();
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
            _context.Patients.Add(patient);
            Close();
        }
        private void CancelButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
