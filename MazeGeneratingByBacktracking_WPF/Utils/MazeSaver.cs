using System.Text;
using System.IO;
using MazeGenerating.Data;
using Microsoft.Win32;
using System;
using System.Windows;

namespace MazeGeneratingByBacktracking_WPF.Utils
{
    internal class MazeSaver
    {
        private const char Wall = '█';
        private const char Floor = ' ';

        SaveFileDialog saveFileDialog = new SaveFileDialog();

        public MazeSaver()
        {
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
        }

        public void Save(Maze maze)
        {
            var content = GetString(maze);
            var result = saveFileDialog.ShowDialog();
            
            if (result.HasValue && result.Value)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, content);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения. {ex.Message}");
                }
            }
        }

        public string GetString(Maze maze)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int y = 0; y < maze.Height; y++)
            {
                AddRowText(maze, stringBuilder, y);
            }

            return stringBuilder.ToString();
        }

        private void AddRowText(Maze maze, StringBuilder stringBuilder, int y)
        {
            for (int x = 0; x < maze.Width; x++)
            {
                stringBuilder.Append(maze[x, y] == CellType.Wall ? Wall : Floor);
            }

            stringBuilder.AppendLine();
        }
    }
}
