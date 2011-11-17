/**
 * Author: Kristopher Baker
 * Class: CSC 479A - Intro to Artificial Intelligence
 * Copyright: 2011
 **/

namespace SuperSudoku
{
    /// <summary>
    /// Base class for all searches
    /// </summary>
    public abstract class BaseSearch : ISearch
    {
        public int TotalAssignments { get; protected set; }
        public SudokuBoard Solution { get; protected set; }

        public virtual SudokuBoard Search(SudokuBoard sudokuBoard)
        {
            Solution = null;
            TotalAssignments = 0;

            var nextPosition = FindNextPosition(sudokuBoard);

            if (nextPosition != null)
            {
                Solution = PerformSearch(new SearchNode(sudokuBoard, nextPosition));
            }

            return Solution;
        }

        protected abstract Position FindNextPosition(SudokuBoard sudokuBoard);

        protected virtual SudokuBoard PerformSearch(SearchNode searchNode)
        {
            while (searchNode.AvailableChars.Count > 0)
            {
                var nextChar = searchNode.AvailableChars.Dequeue();
                searchNode.SetValue(nextChar);
                TotalAssignments++;

                if (searchNode.SudokuBoard.IsSolved)
                {
                    return searchNode.SudokuBoard;
                }

                var nextPosition = FindNextPosition(searchNode.SudokuBoard);

                if (nextPosition != null)
                {
                    var result = PerformSearch(new SearchNode(searchNode.SudokuBoard, nextPosition));

                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }
    }
}
