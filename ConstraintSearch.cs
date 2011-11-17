/**
 * Author: Kristopher Baker
 * Class: CSC 479A - Intro to Artificial Intelligence
 * Copyright: 2011
 **/

using System.Linq;

namespace SuperSudoku
{
    /// <summary>
    /// CSP Search
    /// </summary>
    public sealed class ConstraintSearch : BaseSearch
    {
        /// <summary>
        /// Finds the next position by finding the next character using the MRV
        /// </summary>
        /// <param name="sudokuBoard">SudokuBoard to find the next position for</param>
        /// <returns>Position of the next blank character using MRV if one is found, null otherwise</returns>
        protected override Position FindNextPosition(SudokuBoard sudokuBoard)
        {
            Position position = null;
            var foundChars = int.MaxValue;

            for (var row = 0; row < SudokuBoard.Rows; row++)
            {
                for (var col = 0; col < SudokuBoard.Columns; col++)
                {
                    if (sudokuBoard[col, row] == '-')
                    {
                        var availableChars = sudokuBoard.AvailableCharsAtPosition(col, row);
                        var count = availableChars.Count();
                        if (count < foundChars)
                        {
                            foundChars = count;

                            if (position == null)
                            {
                                position = new Position(col, row);
                            }
                            else
                            {
                                position.Column = col;
                                position.Row = row;
                            }
                        }
                    }
                }
            }

            return position;
        }
    }
}
