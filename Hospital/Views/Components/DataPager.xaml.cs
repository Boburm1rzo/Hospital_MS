using System.Windows.Controls;

namespace Hospital.Views.Components
{
    /// <summary>
    /// Interaction logic for DataPager.xaml
    /// </summary>
    public partial class DataPager : UserControl
    {
        public DataPager()
        {
            InitializeComponent();
        }
        public int ItemsCount { get; set; }
        private int _currentPage = 1;
        public int CurrentPage
        {
            get => _currentPage;
            private set => _currentPage = value;
        }
    }
}
