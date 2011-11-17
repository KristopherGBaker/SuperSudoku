/**
 * Author: Kristopher Baker
 * Class: CSC 479A - Intro to Artificial Intelligence
 * Copyright: 2011
 **/

namespace SuperSudoku
{
    /// <summary>
    /// Common interface for all searches
    /// </summary>
    public interface ISearch
    {
        SudokuBoard Search(SudokuBoard sudokuBoard);
        int TotalAssignments { get; }
        SudokuBoard Solution { get; }
    }
}
