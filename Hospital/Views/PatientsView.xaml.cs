using Hospital.ViewModels;
using System.Drawing.Text;
using System.Windows.Controls;
using System.Windows.Input;

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
