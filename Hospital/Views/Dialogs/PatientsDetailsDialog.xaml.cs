using Hospital.ViewModels.Dialogs;
using HospitalManagementSystem.Models;
using System.Windows;

namespace Hospital.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for PatientsDetailsDialog.xaml
    /// </summary>
    public partial class PatientsDetailsDialog : Window
    {
        public PatientsDetailsDialog(Patient patient)
        {
            InitializeComponent();
            DataContext = new PatientDetailsViewModel(patient);
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
