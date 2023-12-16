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
        private readonly GeneratorViewModel _viewModel = new GeneratorViewModel(new Generator());

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModel;
            _viewModel.CellsChanged += OnCellsChanged;
        }

        private void OnCellsChanged(object? sender, System.EventArgs e)
        {
            canvas.Children.Clear();

            foreach (var cell in _viewModel.Cells) 
            {
                canvas.Children.Add(cell);
            }
        }
    }
}
