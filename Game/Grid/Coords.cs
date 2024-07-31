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

        public int GetRow()
        {
            return _row;
        }

        public int GetColumn()
        {
            return _column;
        }
    }
}
