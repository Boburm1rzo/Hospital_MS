using Hospital.Services;
using HospitalManagementSystem.Models;
using System.Windows;

namespace Hospital.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for SpecializationDialog.xaml
    /// </summary>
    public partial class SpecializationDialog : Window
    {
        private readonly SpecializationsService _specializationsService;
        public SpecializationDialog()
        {
            InitializeComponent();
            _specializationsService = new SpecializationsService();
        }
        private void SaveButton(object sender, RoutedEventArgs e)
        {
            var specialization = new Specialization()
            {
                Description = DescriptionInput.Text,
                Name = NameInput.Text
            };
            _specializationsService.Create(specialization);
            Close();
        }
        private void CancelButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
