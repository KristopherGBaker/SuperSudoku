/**
 * Author: Kristopher Baker
 * Class: CSC 479A - Intro to Artificial Intelligence
 * Copyright: 2011
 **/

using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperSudoku
{
    public partial class SuperSudokuForm : Form
    {
        private OpenFileDialog OpenDialog { get; set; }
        private SaveFileDialog SaveDialog { get; set; }
        private SudokuBoard _sudokuBoard = new SudokuBoard();
        private Position HighlightedPosition { get; set; }
        private Position SelectedPosition { get; set; }
        private Font BoardFont { get; set; }

        private int CellSize { get; set; }

        public SudokuBoard SudokuBoard
        {
            get { return _sudokuBoard; }
            set { _sudokuBoard = value; }
        }

        public SuperSudokuForm()
        {
            InitializeComponent();

            OpenDialog = new OpenFileDialog
            {
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory,
                CheckFileExists = true,
                Multiselect = false
            };

            SaveDialog = new SaveFileDialog
            {
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
            };

            CellSize = BoardPictureBox.Size.Width >> 4;
            BoardFont = new Font("Arial", 20.0f);
        }

        private void BoardPictureBox_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            DrawLines(graphics);
            DrawHighlightedPosition(graphics);
            DrawSelectedPosition(graphics);
            DrawBoard(graphics);
        }

        private void DrawSelectedPosition(Graphics graphics)
        {
            if (SelectedPosition != null)
            {
                var x = SelectedPosition.Column - (SelectedPosition.Column % CellSize) + 1;
                var y = SelectedPosition.Row - (SelectedPosition.Row % CellSize) + 1;
                graphics.FillRectangle(Brushes.LightGreen, x, y, CellSize - 1, CellSize - 1);
            }
        }

        private void DrawHighlightedPosition(Graphics graphics)
        {
            if (HighlightedPosition != null)
            {
                var x = HighlightedPosition.Column - (HighlightedPosition.Column % CellSize) + 1;
                var y = HighlightedPosition.Row - (HighlightedPosition.Row % CellSize) + 1;
                graphics.FillRectangle(Brushes.LightSkyBlue, x, y, CellSize - 1, CellSize - 1);
            }
        }

        private void DrawLines(Graphics graphics)
        {

            var black = new Pen(Brushes.Black, 2.0f);

            for (var x = 0; x <= BoardPictureBox.Size.Width; x += CellSize)
            {
                graphics.DrawLine(Pens.Red, x, 2, x, BoardPictureBox.Size.Height);
                graphics.DrawLine(Pens.Red, 2, x, BoardPictureBox.Size.Width, x);
            }

            for (var x = 0; x <= BoardPictureBox.Size.Width; x += CellSize)
            {
                if (x % 32 == 0)
                {
                    var xPos = x == BoardPictureBox.Size.Width ? x - 1 : x == 0 ? 1 : x;

                    graphics.DrawLine(black, xPos, 0, xPos, BoardPictureBox.Size.Height);
                    graphics.DrawLine(black, 0, xPos, BoardPictureBox.Size.Width, xPos);
                }
            }
        }

        private void DrawBoard(Graphics graphics)
        {
            for (var col = 0; col < SudokuBoard.Columns; col++)
            {
                for (var row = 0; row < SudokuBoard.Rows; row++)
                {
                    if (SudokuBoard[col, row] == '-')
                    {
                        continue;
                    }

                    var x = col * CellSize + 7;
                    var y = row * CellSize + 5;
                    graphics.DrawString(SudokuBoard[col, row].ToString(), BoardFont, Brushes.DarkBlue, x, y);
                }
            }
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            TotalAssignmentsLabel.Text = string.Empty;

            if (OpenDialog.ShowDialog(this) == DialogResult.OK)
            {
                Task.Factory.StartNew(() =>
                {
                    SudokuBoard = SudokuBoard.Load(OpenDialog.FileName);
                    BeginInvoke((Action)(BoardPictureBox.Refresh));
                });
            }
        }

        private void BoardPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            HighlightedPosition = new Position(e.X, e.Y);
            PositionLabel.Text = string.Format("Position: ({0}, {1})", HighlightedPosition.Column / CellSize, HighlightedPosition.Row / CellSize);
            BoardPictureBox.Refresh();
        }

        private void BoardPictureBox_MouseLeave(object sender, EventArgs e)
        {
            HighlightedPosition = null;
            BoardPictureBox.Refresh();
        }

        private void BoardPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SelectedPosition = new Position(e.X, e.Y);
            }
            else if (e.Button == MouseButtons.Right)
            {
                SelectedPosition = null;
            }
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveDialog.ShowDialog(this) == DialogResult.OK)
            {
                Task.Factory.StartNew(() => SudokuBoard.Save(SaveDialog.FileName));
            }
        }

        private void SuperSudokuForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (SelectedPosition != null)
            {
                var col = SelectedPosition.Column / CellSize;
                var row = SelectedPosition.Row / CellSize;
                var val = default(char);

                if (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.D0)
                {
                    val = '0';
                }
                else if (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1)
                {
                    val = '1';
                }
                else if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2)
                {
                    val = '2';
                }
                else if (e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.D3)
                {
                    val = '3';
                }
                else if (e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.D4)
                {
                    val = '4';
                }
                else if (e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.D5)
                {
                    val = '5';
                }
                else if (e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.D6)
                {
                    val = '6';
                }
                else if (e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.D7)
                {
                    val = '7';
                }
                else if (e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.D8)
                {
                    val = '8';
                }
                else if (e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.D9)
                {
                    val = '9';
                }
                else if (e.KeyCode == Keys.A)
                {
                    val = 'A';
                }
                else if (e.KeyCode == Keys.B)
                {
                    val = 'B';
                }
                else if (e.KeyCode == Keys.C)
                {
                    val = 'C';
                }
                else if (e.KeyCode == Keys.D)
                {
                    val = 'D';
                }
                else if (e.KeyCode == Keys.E)
                {
                    val = 'E';
                }
                else if (e.KeyCode == Keys.F)
                {
                    val = 'F';
                }
                else if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back || e.KeyCode == Keys.Subtract)
                {
                    val = '-';
                }

                if (val == '-' || SudokuBoard.AvailableCharsAtPosition(col, row).Contains(val))
                {
                    SudokuBoard[col, row] = val;
                }

                BoardPictureBox.Refresh();
            }
        }

        private void newMenuItem_Click(object sender, EventArgs e)
        {
            TotalAssignmentsLabel.Text = string.Empty;
            SudokuBoard = new SudokuBoard();
            BoardPictureBox.Refresh();
        }

        private void cspAgentMenuItem_Click(object sender, EventArgs e)
        {
            Search(new ConstraintSearch());
        }

        private void uninformedAgentMenuItem_Click(object sender, EventArgs e)
        {
            Search(new UninformedSearch());
        }

        private void Search(ISearch searcher)
        {
            TotalAssignmentsLabel.Text = "Searching...";

            Task.Factory.StartNew(() =>
            {
                var solution = searcher.Search(SudokuBoard);

                BeginInvoke((Action)(() =>
                {
                    TotalAssignmentsLabel.Text = string.Format("Total Assignments: {0}", searcher.TotalAssignments);

                    if (solution != null)
                    {
                        SudokuBoard = solution;
                        BoardPictureBox.Refresh();
                    }
                }));
            });
        }
    }
}

