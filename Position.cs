/**
 * Author: Kristopher Baker
 * Class: CSC 479A - Intro to Artificial Intelligence
 * Copyright: 2011
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperSudoku
{
    public class Position
    {
        public int Column { get; set; }
        public int Row { get; set; }

        public Position()
        {
        }

        public Position(int column, int row)
        {
            Column = column;
            Row = row;
        }
    }
}
