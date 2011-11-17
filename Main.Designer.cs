namespace SuperSudoku
{
    partial class SuperSudokuForm
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
            this.BoardPictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uninformedAgentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cspAgentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PositionLabel = new System.Windows.Forms.Label();
            this.TotalAssignmentsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BoardPictureBox)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // BoardPictureBox
            // 
            this.BoardPictureBox.BackColor = System.Drawing.Color.White;
            this.BoardPictureBox.Location = new System.Drawing.Point(80, 80);
            this.BoardPictureBox.Name = "BoardPictureBox";
            this.BoardPictureBox.Size = new System.Drawing.Size(640, 640);
            this.BoardPictureBox.TabIndex = 0;
            this.BoardPictureBox.TabStop = false;
            this.BoardPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.BoardPictureBox_Paint);
            this.BoardPictureBox.MouseLeave += new System.EventHandler(this.BoardPictureBox_MouseLeave);
            this.BoardPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BoardPictureBox_MouseMove);
            this.BoardPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BoardPictureBox_MouseUp);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.solveMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMenuItem,
            this.openMenuItem,
            this.saveMenuItem,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "&File";
            // 
            // newMenuItem
            // 
            this.newMenuItem.Name = "newMenuItem";
            this.newMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newMenuItem.Text = "&New";
            this.newMenuItem.Click += new System.EventHandler(this.newMenuItem_Click);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openMenuItem.Text = "&Open";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveMenuItem.Text = "&Save";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitMenuItem.Text = "E&xit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // solveMenuItem
            // 
            this.solveMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uninformedAgentMenuItem,
            this.cspAgentMenuItem});
            this.solveMenuItem.Name = "solveMenuItem";
            this.solveMenuItem.Size = new System.Drawing.Size(47, 20);
            this.solveMenuItem.Text = "Sol&ve";
            // 
            // uninformedAgentMenuItem
            // 
            this.uninformedAgentMenuItem.Name = "uninformedAgentMenuItem";
            this.uninformedAgentMenuItem.Size = new System.Drawing.Size(173, 22);
            this.uninformedAgentMenuItem.Text = "&Uninformed Agent";
            this.uninformedAgentMenuItem.Click += new System.EventHandler(this.uninformedAgentMenuItem_Click);
            // 
            // cspAgentMenuItem
            // 
            this.cspAgentMenuItem.Name = "cspAgentMenuItem";
            this.cspAgentMenuItem.Size = new System.Drawing.Size(173, 22);
            this.cspAgentMenuItem.Text = "&CSP Agent";
            this.cspAgentMenuItem.Click += new System.EventHandler(this.cspAgentMenuItem_Click);
            // 
            // PositionLabel
            // 
            this.PositionLabel.AutoSize = true;
            this.PositionLabel.Location = new System.Drawing.Point(77, 740);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(47, 13);
            this.PositionLabel.TabIndex = 2;
            this.PositionLabel.Text = "Position:";
            // 
            // TotalAssignmentsLabel
            // 
            this.TotalAssignmentsLabel.AutoSize = true;
            this.TotalAssignmentsLabel.Location = new System.Drawing.Point(77, 41);
            this.TotalAssignmentsLabel.Name = "TotalAssignmentsLabel";
            this.TotalAssignmentsLabel.Size = new System.Drawing.Size(0, 13);
            this.TotalAssignmentsLabel.TabIndex = 3;
            // 
            // SuperSudokuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 762);
            this.Controls.Add(this.TotalAssignmentsLabel);
            this.Controls.Add(this.PositionLabel);
            this.Controls.Add(this.BoardPictureBox);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "SuperSudokuForm";
            this.Text = "Super Sudoku";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SuperSudokuForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.BoardPictureBox)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BoardPictureBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.Label PositionLabel;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uninformedAgentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cspAgentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMenuItem;
        private System.Windows.Forms.Label TotalAssignmentsLabel;
    }
}

