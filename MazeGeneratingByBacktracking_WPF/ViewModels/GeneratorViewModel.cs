﻿using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using MazeGenerating.Data;
using MazeGeneratingByBacktracking_WPF.Models;
using MazeGeneratingByBacktracking_WPF.Utils;

namespace MazeGeneratingByBacktracking_WPF.ViewModels
{
    internal class GeneratorViewModel : INotifyPropertyChanged
    {
        #region Fields

        private readonly Generator _generator;
        private readonly Dispatcher _dispatcher;
        private readonly MazeDrawer _mazeDrawer = new MazeDrawer();
        private readonly MazeSaver _saver = new MazeSaver();
        private int _canvasWidth;
        private int _canvasHeight;
        private ImageSource _mazeImage;

        #endregion Fields

        #region Events

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion Events

        public GeneratorViewModel(Generator generator, Dispatcher dispatcher)
        {
            _generator = generator;
            _dispatcher = dispatcher;
            _generator.MazeGenerated += OnMazeGenerated;

            GenerateMazeCommand = new Command(
                async () => await GenerateMazeAsync(),
                () => true);

            SaveMazeCommand = new Command(
                () => _saver.Save(Maze),
                () => Maze.Width != 1 && Maze.Height != 1);

            UpdateImage();
        }

        #region Properties

        public int MazeWidth
        {
            get => _generator.Width;
            set => _generator.Width = value;
        }

        public int MazeHeight
        {
            get => _generator.Height;
            set => _generator.Height = value;
        }

        public int CanvasWidth
        {
            get => _canvasWidth;
            set
            {
                if (_canvasWidth == value)
                {
                    return;
                }

                _canvasWidth = value;
                RaisePropertyChanged(nameof(CanvasWidth));
            }
        }

        public int CanvasHeight
        {
            get => _canvasHeight;
            set
            {
                if (_canvasHeight == value)
                {
                    return;
                }

                _canvasHeight = value;
                RaisePropertyChanged(nameof(CanvasHeight));
            }
        }

        public int CellSize { get; set; } = 5;

        public ImageSource MazeImage
        {
            get => _mazeImage;
            set 
            { 
                _mazeImage = value; 
                RaisePropertyChanged(nameof(MazeImage));
            }
        }

        public ICommand GenerateMazeCommand { get; }

        public ICommand SaveMazeCommand { get; }

        private Maze Maze => _generator.Maze;

        #endregion Properties

        #region Event Handlers

        private async Task GenerateMazeAsync()
        {
            await Task.Run(_generator.GenerateMaze);
        }

        private void OnMazeGenerated(object? sender, System.EventArgs e)
        {
            _dispatcher.Invoke(UpdateImage, DispatcherPriority.Render);
        }

        #endregion Event Handlers

        #region Methods

        private async void UpdateImage()
        {
            var canvasSize = GetCanvasSize(CellSize);
            ((Command)SaveMazeCommand).RaiseCanExecuteChanged();

            CanvasHeight = canvasSize.Height;
            CanvasWidth = canvasSize.Width;

            var floor = Color.FromRgb(255, 255, 255);
            var wall = Color.FromRgb(0, 0, 0);

            MazeImage = await Task.Run(() => _mazeDrawer.Draw(Maze, (uint)CellSize, floor, wall));
        }

        private Size GetCanvasSize(int cellSize)
        {
            return new Size(
                Maze.Width * cellSize,
                Maze.Height * cellSize);
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion Methods
    }
}
