using Hospital.Services;
using Hospital.ViewModels;
using System.Windows.Controls;

namespace Hospital.Views
{
    /// <summary>
    /// Interaction logic for AppointmentsView.xaml
    /// </summary>
    public partial class AppointmentsView : UserControl
    {
        public AppointmentsView()
        {
            InitializeComponent();
            DataContext = new AppointmentsViewModel();
        }
    }
}
