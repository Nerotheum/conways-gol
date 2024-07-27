namespace Conways.GameOfLife.Game
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._panelMenu = new System.Windows.Forms.Panel();
            this._lblHeader = new System.Windows.Forms.Label();
            this._lblGeneration = new System.Windows.Forms.Label();
            this._btnStartGame = new System.Windows.Forms.Button();
            this._btnStopGame = new System.Windows.Forms.Button();
            this._btnClear = new System.Windows.Forms.Button();
            this._lblSpeed = new System.Windows.Forms.Label();
            this._trackbarSpeed = new System.Windows.Forms.TrackBar();
            this._pictureBoxGame = new System.Windows.Forms.PictureBox();
            this._panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._trackbarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxGame)).BeginInit();
            this.SuspendLayout();
            // 
            // _panelMenu
            // 
            this._panelMenu.Controls.Add(this._lblHeader);
            this._panelMenu.Controls.Add(this._lblGeneration);
            this._panelMenu.Controls.Add(this._btnStartGame);
            this._panelMenu.Controls.Add(this._btnStopGame);
            this._panelMenu.Controls.Add(this._btnClear);
            this._panelMenu.Controls.Add(this._lblSpeed);
            this._panelMenu.Controls.Add(this._trackbarSpeed);
            this._panelMenu.Location = new System.Drawing.Point(12, 12);
            this._panelMenu.Name = "_panelMenu";
            this._panelMenu.Size = new System.Drawing.Size(207, 550);
            this._panelMenu.TabIndex = 1;
            // 
            // _lblHeader
            // 
            this._lblHeader.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblHeader.Location = new System.Drawing.Point(3, 3);
            this._lblHeader.Name = "_lblHeader";
            this._lblHeader.Size = new System.Drawing.Size(201, 98);
            this._lblHeader.TabIndex = 0;
            this._lblHeader.Text = "Game of Life";
            this._lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblGeneration
            // 
            this._lblGeneration.Location = new System.Drawing.Point(3, 116);
            this._lblGeneration.Name = "_lblGeneration";
            this._lblGeneration.Size = new System.Drawing.Size(197, 23);
            this._lblGeneration.TabIndex = 3;
            this._lblGeneration.Text = "Cell generation: 0";
            this._lblGeneration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _btnStartGame
            // 
            this._btnStartGame.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnStartGame.Location = new System.Drawing.Point(3, 167);
            this._btnStartGame.Name = "_btnStartGame";
            this._btnStartGame.Size = new System.Drawing.Size(201, 60);
            this._btnStartGame.TabIndex = 1;
            this._btnStartGame.Text = "Start";
            this._btnStartGame.UseVisualStyleBackColor = true;
            // 
            // _btnStopGame
            // 
            this._btnStopGame.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnStopGame.Location = new System.Drawing.Point(3, 233);
            this._btnStopGame.Name = "_btnStopGame";
            this._btnStopGame.Size = new System.Drawing.Size(201, 60);
            this._btnStopGame.TabIndex = 2;
            this._btnStopGame.Text = "Stop";
            this._btnStopGame.UseVisualStyleBackColor = true;
            // 
            // _btnClear
            // 
            this._btnClear.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnClear.Location = new System.Drawing.Point(3, 299);
            this._btnClear.Name = "_btnClear";
            this._btnClear.Size = new System.Drawing.Size(201, 60);
            this._btnClear.TabIndex = 5;
            this._btnClear.Text = "Clear";
            this._btnClear.UseVisualStyleBackColor = true;
            // 
            // _lblSpeed
            // 
            this._lblSpeed.Location = new System.Drawing.Point(7, 376);
            this._lblSpeed.Name = "_lblSpeed";
            this._lblSpeed.Size = new System.Drawing.Size(193, 23);
            this._lblSpeed.TabIndex = 4;
            this._lblSpeed.Text = "Generating speed:";
            this._lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _trackbarSpeed
            // 
            this._trackbarSpeed.Location = new System.Drawing.Point(3, 418);
            this._trackbarSpeed.Maximum = 5;
            this._trackbarSpeed.Minimum = 1;
            this._trackbarSpeed.Name = "_trackbarSpeed";
            this._trackbarSpeed.Size = new System.Drawing.Size(201, 69);
            this._trackbarSpeed.TabIndex = 3;
            this._trackbarSpeed.Value = 3;
            // 
            // _pictureBoxGame
            // 
            this._pictureBoxGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pictureBoxGame.Location = new System.Drawing.Point(225, 12);
            this._pictureBoxGame.Name = "_pictureBoxGame";
            this._pictureBoxGame.Size = new System.Drawing.Size(550, 550);
            this._pictureBoxGame.TabIndex = 2;
            this._pictureBoxGame.TabStop = false;
            this._pictureBoxGame.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxPaint);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 574);
            this.Controls.Add(this._pictureBoxGame);
            this.Controls.Add(this._panelMenu);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(809, 630);
            this.Name = "GameForm";
            this.Text = "Conways - Game of Life";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameFormClosed);
            this._panelMenu.ResumeLayout(false);
            this._panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._trackbarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxGame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _panelMenu;
        private System.Windows.Forms.Label _lblHeader;
        private System.Windows.Forms.Label _lblGeneration;
        private System.Windows.Forms.Button _btnStartGame;
        private System.Windows.Forms.Button _btnStopGame;
        private System.Windows.Forms.Button _btnClear;
        private System.Windows.Forms.Label _lblSpeed;
        private System.Windows.Forms.TrackBar _trackbarSpeed;
        private System.Windows.Forms.PictureBox _pictureBoxGame;
    }
}
