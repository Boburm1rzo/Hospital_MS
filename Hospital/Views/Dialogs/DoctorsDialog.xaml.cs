﻿using Hospital.Services;
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
    /// Interaction logic for DoctorsDialog.xaml
    /// </summary>
    public partial class DoctorsDialog : Window
    {
        private readonly DoctorsService _service;
        public DoctorsDialog()
        {
            InitializeComponent();
            _service= new DoctorsService();
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
