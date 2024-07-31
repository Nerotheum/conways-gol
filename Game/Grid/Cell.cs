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

        public int GetRow()
        {
            return _coords.GetRow();
        }

        public int GetColumn()
        {
            return _coords.GetColumn();
        }

        public bool GetIsAlive()
        {
            return _isAlive;
        }

        public void SetIsAlive(bool isAlive)
        {
            _isAlive = isAlive;
        }
    }
}
