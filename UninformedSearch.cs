/**
 * Author: Kristopher Baker
 * Class: CSC 479A - Intro to Artificial Intelligence
 * Copyright: 2011
 **/

namespace SuperSudoku
{
    /// <summary>
    /// Uninformed search
    /// </summary>
    public sealed class UninformedSearch : BaseSearch
    {
        /// <summary>
        /// Finds the next position by finding the next blank character, 
        /// going from top to bottom, left to right
        /// </summary>
        /// <param name="sudokuBoard">SudokuBoard to find the next position for</param>
        /// <returns>Position of the next blank character if one is found, null otherwise</returns>
        protected override Position FindNextPosition(SudokuBoard sudokuBoard)
        {
            for (var row = 0; row < SudokuBoard.Rows; row++)
            {
                for (var col = 0; col < SudokuBoard.Columns; col++)
                {
                    if (sudokuBoard[col, row] == '-')
                    {
                        return new Position(col, row);
                    }
                }
            }

            return null;
        }
    }
}
