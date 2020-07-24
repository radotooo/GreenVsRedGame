using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRedGame.Exception
{
    public static class Message
    {
        public static readonly string gridMaxSize = "Grid Size must be under 1000!";
        public static readonly string gridRolBiggerThanCol = "Grid Row can't be bigger than Col!";
        public static readonly string obserVedCellOutOfBoundaries = "No such cell coordinates!";
    }
}
