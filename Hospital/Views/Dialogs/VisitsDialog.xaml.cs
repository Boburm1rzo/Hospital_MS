using Hospital.Services;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            _service=new VisitsService();
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
