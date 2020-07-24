using GreenVsRedGame.Exception;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GreenVsRedGame
{
    public class Grid
    {
        public char[][] Data { get; set; }

        public int Row { get; private set; }

        public Grid(int[] gridSize)
        {
            this.Row = gridSize[1];

            this.Data = new char[this.Row][];
        }

    }
}

