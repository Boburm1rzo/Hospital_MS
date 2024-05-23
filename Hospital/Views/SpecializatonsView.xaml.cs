using Hospital.ViewModels;
using System.Windows.Controls;

namespace Hospital.Views
{
    /// <summary>
    /// Interaction logic for SpecializatonsView.xaml
    /// </summary>
    public partial class SpecializatonsView : UserControl
    {
        public SpecializatonsView()
        {
            InitializeComponent();
            DataContext = new SpecializationsViewModel();

        }
    }
}
