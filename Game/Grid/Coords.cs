using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conways.GameOfLife.Game.Grid
{
    internal class Coords
    {
        private int _row, _column;

        public Coords(int row, int column)
        {
            _row = row;
            _column = column;
        }

        public int getRow()
        {
            return _row;
        }

        public int getColumn()
        {
            return _column;
        }
    }
}
