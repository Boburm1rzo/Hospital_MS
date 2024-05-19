using Hospital.ViewModels;
using System.Windows.Controls;

namespace Hospital.Views;

/// <summary>
/// Interaction logic for PatientsView.xaml
/// </summary>
public partial class PatientsView : UserControl
{
    public PatientsView()
    {
        InitializeComponent();

        DataContext = new PatientsViewModel();
    }
}
