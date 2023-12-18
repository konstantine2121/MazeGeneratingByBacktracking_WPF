using System.Windows;
using MazeGeneratingByBacktracking_WPF.Models;
using MazeGeneratingByBacktracking_WPF.ViewModels;

namespace MazeGeneratingByBacktracking_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GeneratorViewModel _viewModel;

        public MainWindow()
        {
            _viewModel = new GeneratorViewModel(new Generator(), this.Dispatcher);
            InitializeComponent();
            DataContext = _viewModel;
        }
    }
}
