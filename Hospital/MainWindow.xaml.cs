﻿using Hospital.Services;
using System.Windows;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataSeederService.SeedDataBase();
        }
    }
}