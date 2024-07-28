using Conways.GameOfLife.Game.Grid;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Conways.GameOfLife.Game
{
    public partial class GameForm : Form
    {
        private Cell[,] _currentGenGrid;
        private int _gridSize, _cellWidthPictureBox, _cellHeightPictureBox;
        public GameForm(int gridSize)
        {
            _gridSize = gridSize;
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            _pictureBoxGame.Width = Math.Max(_pictureBoxGame.Width, _pictureBoxGame.Height);
            _pictureBoxGame.Height = _pictureBoxGame.Width;

            _cellWidthPictureBox = _pictureBoxGame.Width / _gridSize;
            _cellHeightPictureBox = _pictureBoxGame.Height / _gridSize;
            _pictureBoxGame.Width = _gridSize * _cellWidthPictureBox + 1;
            _pictureBoxGame.Height = _gridSize * _cellHeightPictureBox + 1;

            _currentGenGrid = new Cell[_gridSize, _gridSize];

            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    Coords coords = new Coords(i, j);
                    _currentGenGrid[i, j] = new Cell(coords);
                }
            }
        }

        private void PictureBoxPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            e.Graphics.Clear(Color.White);
            Pen penBlack = new Pen(Color.Black);
            SolidBrush brushBlack = new SolidBrush(Color.Black);

            for (int i = 0; i < _gridSize + 1; i++)
            {
                graphics.DrawLine(penBlack, 0, i * _cellWidthPictureBox, _gridSize * _cellWidthPictureBox, i * _cellWidthPictureBox); //Draw rows
                graphics.DrawLine(penBlack, i * _cellHeightPictureBox, 0, i * _cellHeightPictureBox, _gridSize * _cellHeightPictureBox); //Draw columns
            }

            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    Cell cell = _currentGenGrid[i, j];
                    if (cell.IsAlive)
                    {
                        int rectWidth = cell.Coords.Row * _cellWidthPictureBox;
                        int rectHeight = cell.Coords.Column * _cellHeightPictureBox;
                        Rectangle rectangle = new Rectangle(rectHeight, rectWidth, _cellWidthPictureBox, _cellHeightPictureBox);
                        e.Graphics.FillRectangle(brushBlack, rectangle);
                    }
                }
            }
        }

        private void PictureBoxGameClick(object sender, EventArgs e)
        {
            MouseEventArgs mouseEventArgs = (MouseEventArgs)e;
            Point clickCoordinates = mouseEventArgs.Location;

            int coordinateToColumn, coordinateToRow;
            coordinateToColumn = clickCoordinates.X / _cellWidthPictureBox;
            coordinateToRow = clickCoordinates.Y / _cellHeightPictureBox;

            try
            {
                Cell clickedCell = _currentGenGrid[coordinateToRow, coordinateToColumn];
                clickedCell.IsAlive = !clickedCell.IsAlive;
            }
            catch
            {
                //Out of bonds, do nothing
            }
            _pictureBoxGame.Invalidate();
        }

        private void GameFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
