﻿using Conways.GameOfLife.Game.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Conways.GameOfLife.Game
{
    public partial class GameForm : Form
    {
        private Cell[,] _currentGenGrid, _nextGenGrid;
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
            int column = clickCoordinates.X / _cellWidthPictureBox;
            int row = clickCoordinates.Y / _cellHeightPictureBox;

            if (row < 0 || row >= _currentGenGrid.GetLength(0) || column < 0 || column >= _currentGenGrid.GetLength(1))
                return; // Out of bounds, do nothing

            Cell clickedCell = _currentGenGrid[row, column];
            clickedCell.IsAlive = !clickedCell.IsAlive;
            _pictureBoxGame.Invalidate();
        }

        private void BtnStartClick(object sender, EventArgs e)
        {
            CalculateNextGeneration();
            _pictureBoxGame.Invalidate();
        }

        public void CalculateNextGeneration()
        {
            _nextGenGrid = new Cell[_gridSize, _gridSize];
            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    Coords coords = new Coords(i, j);
                    _nextGenGrid[i, j] = new Cell(coords);
                }
            }

            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    bool isAlive = _currentGenGrid[i, j].IsAlive;
                    int aliveNbs = GetNumOfAliveNeighbourCells(i, j);

                    if (isAlive && aliveNbs < 2)
                    {
                        _nextGenGrid[i, j].IsAlive = false;
                    }
                    else if (isAlive && aliveNbs >= 4)
                    {
                        _nextGenGrid[i, j].IsAlive = false;
                    }
                    else if (isAlive && aliveNbs == 2 || isAlive && aliveNbs == 3)
                    {
                        _nextGenGrid[i, j].IsAlive = true;
                    }
                    else if (!isAlive && aliveNbs == 3)
                    {
                        _nextGenGrid[i, j].IsAlive = true;
                    }
                }
            }
            _currentGenGrid = _nextGenGrid;
        }

        public int GetNumOfAliveNeighbourCells(int row, int column)
        {
            if (_currentGenGrid[row, column] == null)
                return 0;

            List<Coords> neighbourCellsPosition = new List<Coords>
            {
                {new Coords(-1, -1)},
                {new Coords(-1, 0)},
                {new Coords(-1, +1)},
                {new Coords(0, -1)},
                {new Coords(0, +1)},
                {new Coords(+1, -1)},
                {new Coords(+1, 0)},
                {new Coords(+1, +1)},
            };

            int numOfPossibleNbs = 0;
            int numOfAliveNbs = 0;

            foreach (Coords neighbourCellPosition in neighbourCellsPosition)
            {
                int neighbourCellRow = row + neighbourCellPosition.Row;
                int neighbourCellColumn = column + neighbourCellPosition.Column;

                if (neighbourCellRow >= 0 && neighbourCellRow < _gridSize)
                {
                    if (neighbourCellColumn >= 0 && neighbourCellColumn < _gridSize)
                    {
                        numOfPossibleNbs++;
                        Cell neighbourCell = _currentGenGrid[neighbourCellRow, neighbourCellColumn];
                        if (neighbourCell.IsAlive) numOfAliveNbs++;
                    }
                }
            }

            return numOfAliveNbs;
        }


        private void GameFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
