/**
 * Author: Kristopher Baker
 * Class: CSC 479A - Intro to Artificial Intelligence
 * Copyright: 2011
 **/

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SuperSudoku
{
    /// <summary>
    /// Represents a Super Sudoku board
    /// </summary>
    public sealed class SudokuBoard
    {
        public const int Columns = 16;
        public const int Rows = 16;
        private static readonly char[] _validCharacters = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', '-' };

        /// <summary>
        /// Array of all valid super sudoku characters
        /// </summary>
        public static char[] ValidCharacters { get { return _validCharacters; } }

        private char[,] _board = new char[Columns, Rows];

        private char[,] Board
        {
            get { return _board; }
            set { _board = value; }
        }

        /// <summary>
        /// Indexer for accessing the board
        /// </summary>
        /// <param name="col">column to select</param>
        /// <param name="row">row to select</param>
        /// <returns>character at the selected column and row</returns>
        public char this[int col, int row]
        {
            get { return Board[col, row]; }
            set { Board[col, row] = value; }
        }

        /// <summary>
        /// Indexer for accessing the board
        /// </summary>
        /// <param name="position">Position to select</param>
        /// <returns>character at the selected position</returns>
        public char this[Position position]
        {
            get { return position != null ? Board[position.Column, position.Row] : '\0'; }
            set { if (position != null) Board[position.Column, position.Row] = value; }
        }

        /// <summary>
        /// Checks to see if the board contains any blank characters,
        /// does not check to see if the characters on the board are all valid
        /// </summary>
        /// <returns>true iff the board does not contain any blank characters</returns>
        public bool IsSolved
        {
            get
            {
                for (var col = 0; col < Columns; col++)
                {
                    for (var row = 0; row < Rows; row++)
                    {
                        if (Board[col, row] == '-')
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        /// <summary>
        /// Initializes the board to all empty characters
        /// </summary>
        public SudokuBoard()
        {
            for (var col = 0; col < Columns; col++)
            {
                for (var row = 0; row < Rows; row++)
                {
                    Board[col, row] = '-';
                }
            }
        }

        /// <summary>
        /// Creates a copy of the board
        /// </summary>
        /// <returns></returns>
        public SudokuBoard Copy()
        {
            var copy = new SudokuBoard();

            for (var col = 0; col < Columns; col++)
            {
                for (var row = 0; row < Rows; row++)
                {
                    copy[col, row] = Board[col, row];
                }
            }

            return copy;
        }

        /// <summary>
        /// Gets all available characters at the selected position
        /// </summary>
        /// <param name="position">Position</param>
        /// <returns>All available characters at the selected position</returns>
        public IEnumerable<char> AvailableCharsAtPosition(Position position)
        {
            return AvailableCharsAtPosition(position.Column, position.Row);
        }

        /// <summary>
        /// Gets all available characters at the selected column and row
        /// </summary>
        /// <param name="col">column</param>
        /// <param name="row">row</param>
        /// <returns>All available characters at the selected column and row</returns>
        public IEnumerable<char> AvailableCharsAtPosition(int col, int row)
        {
            var knownChars = new List<char> { '-' };

            var x2 = col - (col % 4);
            var x2Max = col - (col % 4) + 4;
            var y2Max = row - (row % 4) + 4;

            for (; x2 < x2Max; x2++)
            {
                for (var y2 = row - (row % 4); y2 < y2Max; y2++)
                {
                    if (Board[x2, y2] != '-')
                    {
                        knownChars.Add(Board[x2, y2]);
                    }
                }
            }

            for (var y = 0; y < Rows; y++)
            {
                if (Board[col, y] != '-' && !knownChars.Contains(Board[col, y]))
                {
                    knownChars.Add(Board[col, y]);
                }
            }

            for (var x = 0; x < Columns; x++)
            {
                if (Board[x, row] != '-' && !knownChars.Contains(Board[x, row]))
                {
                    knownChars.Add(Board[x, row]);
                }
            }

            return ValidCharacters.Except(knownChars).OrderBy(val => val);
        }

        /// <summary>
        /// Saves the board to a text file
        /// </summary>
        /// <param name="path">Path of the text file to save</param>
        public void Save(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                for (var col = 0; col < Columns; col++)
                {
                    for (var row = 0; row < Rows; row++)
                    {
                        writer.Write(Board[col, row]);
                    }

                    writer.WriteLine();
                }
            }
        }

        /// <summary>
        /// Loads a text file into a board
        /// </summary>
        /// <param name="path">Path of the text file to load</param>
        /// <returns>Loaded board</returns>
        public static SudokuBoard Load(string path)
        {
            var sudokuBoard = new SudokuBoard();

            using (var reader = new StreamReader(path))
            {
                string line;
                var rowCount = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();

                    if (line.Length == 0)
                    {
                        continue;
                    }

                    if (rowCount >= Rows || line.Length != Columns || line.Where(c => !ValidCharacters.Contains(c)).Any())
                    {
                        return null;
                    }

                    for (var index = 0; index < Columns; index++)
                    {
                        sudokuBoard.Board[index, rowCount] = line[index];
                    }

                    rowCount++;
                }
            }

            return sudokuBoard;
        }
    }
}
