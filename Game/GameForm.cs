using Conways.GameOfLife.Game.Grid;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Conways.GameOfLife.Game
{
    public partial class GameForm : Form
    {
        private Cell[,] _currentGenGrid, _nextGenGrid;
        private int _gridSize, _cellWidthPictureBox, _cellHeightPictureBox, _generation;
        private Timer _gameTimer;
        private bool _gameRunning;

        public GameForm(int gridSize)
        {
            _gridSize = gridSize;
            _gameTimer = new Timer();
            _gameTimer.Interval = 3 * 1000 / 2;
            _gameTimer.Tick += new EventHandler(GameTimerTick);
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
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
                    if (cell.GetIsAlive())
                    {
                        int rectWidth = cell.GetRow() * _cellWidthPictureBox;
                        int rectHeight = cell.GetColumn() * _cellHeightPictureBox;
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
            int column = clickCoordinates.X / _cellWidthPictureBox;
            int row = clickCoordinates.Y / _cellHeightPictureBox;

            if (row < 0 || row >= _currentGenGrid.GetLength(0) || column < 0 || column >= _currentGenGrid.GetLength(1))
                return; // Out of bounds, do nothing

            Cell clickedCell = _currentGenGrid[row, column];
            clickedCell.SetIsAlive(!clickedCell.GetIsAlive());
            _pictureBoxGame.Invalidate();
        }

        private void BtnRandomizeClick(object sender, EventArgs e)
        {
            ResetGrid(generateRandomCells: true);
        }

        private void BtnStartClick(object sender, EventArgs e)
        {
            _gameRunning = !_gameRunning;
            if (_gameRunning)
                _gameTimer.Start();
            else
                _gameTimer.Stop();
            _btnStartGame.Text = _gameRunning ? "Stop" : "Start";
        }

        private void BtnClearClick(object sender, EventArgs e)
        {
            ResetGrid(generateRandomCells: false);
        }

        private void ResetGrid(bool generateRandomCells)
        {
            Random random = new Random();
            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    bool isAlive = false;
                    if(generateRandomCells)
                        isAlive = random.NextDouble() >= 0.5;
                    _currentGenGrid[i, j].SetIsAlive(isAlive);
                }
            }
            _pictureBoxGame.Invalidate();
        }

        private void TrackbarSpeedScroll(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            _gameTimer.Interval = nums[nums.Length - _trackbarSpeed.Value] * 500;
        }

        private void GameTimerTick(object sender, EventArgs e)
        {
            CalculateNextGeneration();
            _pictureBoxGame.Invalidate();
        }

        private void CalculateNextGeneration()
        {
            _nextGenGrid = new Cell[_gridSize, _gridSize];
            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    _nextGenGrid[i, j] = new Cell(new Coords(i, j));

                    bool isAlive = _currentGenGrid[i, j].GetIsAlive();
                    int aliveNbs = GetNumOfAliveNeighbourCells(i, j);

                    if ((isAlive && aliveNbs == 2 || isAlive && aliveNbs == 3) || (!isAlive && aliveNbs == 3))
                        _nextGenGrid[i, j].SetIsAlive(true);
                }
            }
            _currentGenGrid = _nextGenGrid;
            _generation++;
        }

        private int GetNumOfAliveNeighbourCells(int row, int column)
        {
            Coords[] neighborOffsets = new Coords[]
            {
                new Coords(-1, -1),
                new Coords(-1, 0),
                new Coords(-1, 1),
                new Coords(0, -1),
                new Coords(0, 1),
                new Coords(1, -1),
                new Coords(1, 0),
                new Coords(1, 1)
            };

            int numOfAliveNeighbors = 0;
            foreach (Coords neighborOffset in neighborOffsets)
            {
                int neighborRow = row + neighborOffset.GetRow();
                int neighborColumn = column + neighborOffset.GetColumn();

                if (neighborRow >= 0 && neighborRow < _gridSize &&
                    neighborColumn >= 0 && neighborColumn < _gridSize)
                {
                    Cell neighborCell = _currentGenGrid[neighborRow, neighborColumn];
                    if (neighborCell != null && neighborCell.GetIsAlive())
                        numOfAliveNeighbors++;
                }
            }
            return numOfAliveNeighbors;
        }

        private void GameFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
