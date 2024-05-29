using Hospital.ViewModels.Dialogs;
using HospitalManagementSystem.Models;
using System.Windows;

namespace Hospital.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for PatientsUpdateDialog.xaml
    /// </summary>
    public partial class PatientsUpdateDialog : Window
    {
        public PatientsUpdateDialog(Patient patient)
        {
            InitializeComponent();
            DataContext = new PatientsUpdateViewModel(patient);
        }
        private void CancelButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
