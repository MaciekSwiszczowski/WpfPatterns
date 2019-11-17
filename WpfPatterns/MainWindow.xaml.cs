using WpfPatterns.ViewModels;

namespace WpfPatterns
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
        }
    }
}
