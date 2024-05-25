using Hospital.ViewModels.Dialogs;
using HospitalManagementSystem.Models;
using System.Windows;

namespace Hospital.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for DoctorsDetailsDialog.xaml
    /// </summary>
    public partial class DoctorsDetailsDialog : Window
    {
        public DoctorsDetailsDialog(Doctor doctor)
        {
            InitializeComponent();
            DataContext = new DoctorDetailsViewModel(doctor);
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
