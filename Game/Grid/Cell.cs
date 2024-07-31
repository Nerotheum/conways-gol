using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conways.GameOfLife.Game.Grid
{
    internal class Cell
    {
        private Coords _coords;
        private bool _isAlive;

        public Cell(Coords coords)
        {
            _coords = coords;
            _isAlive = false;
        }

        public int getRow()
        {
            return _coords.getRow();
        }

        public int getColumn()
        {
            return _coords.getColumn();
        }

        public bool getIsAlive()
        {
            return _isAlive;
        }

        public void setIsAlive(bool isAlive)
        {
            _isAlive = isAlive;
        }
    }
}
