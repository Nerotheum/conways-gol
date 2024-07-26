namespace Conways.GameOfLife.Menu
{
    partial class MenuForm
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
            this._lblHeader = new System.Windows.Forms.Label();
            this._lblGridSize = new System.Windows.Forms.Label();
            this._textBoxGridSize = new System.Windows.Forms.TextBox();
            this._btnOpenGameForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lblHeader
            // 
            this._lblHeader.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblHeader.Location = new System.Drawing.Point(12, 9);
            this._lblHeader.Name = "_lblHeader";
            this._lblHeader.Size = new System.Drawing.Size(371, 70);
            this._lblHeader.TabIndex = 0;
            this._lblHeader.Text = "Game of Life";
            this._lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblGridSize
            // 
            this._lblGridSize.Location = new System.Drawing.Point(20, 81);
            this._lblGridSize.Name = "_lblGridSize";
            this._lblGridSize.Size = new System.Drawing.Size(363, 23);
            this._lblGridSize.TabIndex = 1;
            this._lblGridSize.Text = "Set size of the quadratic grid: min. 3, max. 30";
            this._lblGridSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _textBoxGridSize
            // 
            this._textBoxGridSize.Location = new System.Drawing.Point(12, 121);
            this._textBoxGridSize.Name = "_textBoxGridSize";
            this._textBoxGridSize.Size = new System.Drawing.Size(371, 26);
            this._textBoxGridSize.TabIndex = 2;
            this._textBoxGridSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _btnOpenGameForm
            // 
            this._btnOpenGameForm.Location = new System.Drawing.Point(12, 157);
            this._btnOpenGameForm.Name = "_btnOpenGameForm";
            this._btnOpenGameForm.Size = new System.Drawing.Size(371, 71);
            this._btnOpenGameForm.TabIndex = 3;
            this._btnOpenGameForm.Text = "Next";
            this._btnOpenGameForm.UseVisualStyleBackColor = true;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 241);
            this.Controls.Add(this._btnOpenGameForm);
            this.Controls.Add(this._textBoxGridSize);
            this.Controls.Add(this._lblGridSize);
            this.Controls.Add(this._lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MenuForm";
            this.Text = "Conways - Game of Life";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label _lblHeader;
        private System.Windows.Forms.Label _lblGridSize;
        private System.Windows.Forms.TextBox _textBoxGridSize;
        private System.Windows.Forms.Button _btnOpenGameForm;
    }
}