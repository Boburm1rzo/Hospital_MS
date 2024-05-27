using Hospital.Services;
using HospitalManagementSystem.Models;
using System.Windows;

namespace Hospital.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for DoctorsDialog.xaml
    /// </summary>
    public partial class DoctorsDialog : Window
    {
        private readonly DoctorsService _service;
        public DoctorsDialog()
        {
            InitializeComponent();
            _service = new DoctorsService();
        }
        private void SaveButton(object sender, RoutedEventArgs e)
        {
            var doctor = new Doctor()
            {
                FirstName = FirstNameInput.Text,
                LastName = LastNameInput.Text,
                PhoneNumber = PhoneNumberInput.Text
            };
            _service.Create(doctor);
            Close();
        }
        private void CancelButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
