using Hospital.ViewModels;
using System.Windows.Controls;

namespace Hospital.Views
{
    /// <summary>
    /// Interaction logic for VisitsView.xaml
    /// </summary>
    public partial class VisitsView : UserControl
    {
        public VisitsView()
        {
            InitializeComponent();
            DataContext = new VisitsViewModel();
        }
    }
}
