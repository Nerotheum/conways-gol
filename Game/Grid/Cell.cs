using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conways.GameOfLife.Game.Grid
{
    internal class Cell
    {
        public Coords Coords { get; set; }
        public bool IsAlive { get; set; }
        public Cell(Coords coords, bool isAlive)
        {
            Coords = coords;
            IsAlive = isAlive;
        }
    }
}
