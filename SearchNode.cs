/**
 * Author: Kristopher Baker
 * Class: CSC 479A - Intro to Artificial Intelligence
 * Copyright: 2011
 **/

using System.Collections.Generic;

namespace SuperSudoku
{
    /// <summary>
    /// Represents the board and position for a search state
    /// </summary>
    public sealed class SearchNode
    {
        public Position Position { get; set; }
        public Queue<char> AvailableChars { get; set; }
        public SudokuBoard SudokuBoard { get; set; }

        public SearchNode(SudokuBoard board, Position position)
        {
            SudokuBoard = board.Copy();
            Position = position;
            AvailableChars = new Queue<char>(SudokuBoard.AvailableCharsAtPosition(position));
        }

        public void SetValue(char next)
        {
            SudokuBoard[Position] = next;
        }
    }
}
