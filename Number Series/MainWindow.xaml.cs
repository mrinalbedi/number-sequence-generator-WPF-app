//Mrinal Bedi
using System.Windows;

namespace Number_Series
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel vm = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void evaluate_Click(object sender, RoutedEventArgs e)
        {
            vm.Evaluate();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            vm.SaveFileDialog();
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            vm.clear();
        }
    }
}
