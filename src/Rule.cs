using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace GreenVsRedGame
{
    /// <summary>
    /// Rules for cell color change 
    /// </summary>
    public static class Rule
    {

        // Collection of green neighbors count needed to chance the color to green 
        private static readonly HashSet<int> redToGreen = new HashSet<int> { 3, 6 };
        // Collection of green neighbors count needed to chance the color to red 
        private static readonly HashSet<int> greenToRed = new HashSet<int> { 0, 1, 4, 5, 7, 8 };

        /// <summary>
        /// Determines if given collection contains value
        /// </summary>
        
        public static bool HasReasonToChangeFromRedToGreen(int neighborsCount)
        {
            return redToGreen.Contains(neighborsCount);
        }
        /// <summary>
        /// Determines if given collection contais value
        /// </summary>
        
        public static bool HasReasonToChangeFromGreenToRed(int neighborsCount)
        {
            return greenToRed.Contains(neighborsCount);
        }
    }
}
