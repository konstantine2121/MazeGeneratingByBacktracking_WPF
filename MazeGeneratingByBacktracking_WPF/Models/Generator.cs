using System;
using MazeGenerating;
using MazeGenerating.Data;

namespace MazeGeneratingByBacktracking_WPF.Models
{
    internal class Generator
    {
        private const int MinSize = 1;
        #region FIelds

        private readonly MazeGenerator _generator = new MazeGenerator();        
        private Maze _maze = new Maze(new Size(MinSize, MinSize));
        
        private int _width = 30;
        private int _height = 15;

        #endregion FIelds

        #region Properties

        public int Width
        {
            get => _width;
            set
            {
                if (_width == value)
                    return;

                if (value < MinSize)
                {
                    _width = MinSize;
                }
                else
                {
                    _width = value;
                }
            }
        } 

        public int Height
        {
            get => _height;
            set
            {
                if (_height == value)
                    return;

                if (value < MinSize)
                {
                    _height = MinSize;
                }
                else
                {
                    _height = value;
                }
            }
        }

        public Maze Maze => _maze;

        #endregion Properties

        #region Events

        public event EventHandler MazeGenerated;

        #endregion Events

        #region Methods

        public void GenerateMaze()
        {
            _maze = _generator.Generate(new Size(Width,Height));
            MazeGenerated?.Invoke(this, EventArgs.Empty);
        }

        #endregion Methods
    }
}
