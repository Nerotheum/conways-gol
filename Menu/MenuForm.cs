using Conways.GameOfLife.Game;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Conways.GameOfLife.Menu
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void BtnOpenGameFormClick(object sender, EventArgs e)
        {
            int gridSize;
            bool validInput = Int32.TryParse(_textBoxGridSize.Text, out gridSize);
            if (validInput && gridSize > 2 && gridSize < 31)
            {
                this.Hide();
                GameForm gameForm = new GameForm(gridSize);
                gameForm.ShowDialog();
            }
            else
            {
                _textBoxGridSize.BackColor = Color.Red;
            }
        }

        private void MenuFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
