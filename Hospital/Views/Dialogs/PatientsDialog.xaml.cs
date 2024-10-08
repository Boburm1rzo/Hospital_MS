﻿using Hospital.ViewModels.Dialogs;
using System.Windows;

namespace Hospital.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for PatientsDialog.xaml
    /// </summary>
    public partial class PatientsDialog : Window
    {
        public PatientsDialog()
        {
            InitializeComponent();
            DataContext = new PatientDialogViewModel();
        }
        private void CancelButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
