using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conways.GameOfLife.Game.Grid
{
    internal class Coords
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Coords(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
