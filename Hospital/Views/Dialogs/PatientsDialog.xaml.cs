using Hospital.Services;
using Hospital.ViewModels.Dialogs;
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
        private readonly bool isEditingMode;
        public PatientsDialog()
        {
            InitializeComponent();
            DataContext = new PatientDialogViewModel();
            _patientsService= new PatientsService();
            isEditingMode = false;
            Title = "Add patient";
        }
        public PatientsDialog(Patient patient) : this()
        {
            Title = "Update patient";
            isEditingMode=true;
            FirstNameInput.Text = patient.FirstName.ToString();
            LastNameInput.Text = patient.LastName.ToString();
            PhoneInput.Text = patient.PhoneNumber.ToString();
            DateInput.Text = patient.Birthdate.ToString();  
            GenderInput.Text = patient.Gender.ToString();
        }
        private void CancelButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
