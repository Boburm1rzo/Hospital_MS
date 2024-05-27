using Hospital.Services;
using HospitalManagementSystem.Models;
using System.Windows;

namespace Hospital.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for VisitsDialog.xaml
    /// </summary>
    public partial class VisitsDialog : Window
    {
        private readonly VisitsService _service;
        public VisitsDialog()
        {
            InitializeComponent();
            _service = new VisitsService();
        }
        private void SaveButton(object sender, RoutedEventArgs e)
        {
            var visit = new Visit()
            {
                Comments = CommentsInput.Text,
                TotalDue = decimal.Parse(TotalDueInput.Text)
            };
            _service.Create(visit);
            Close();
        }
        private void CancelButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
