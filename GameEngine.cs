using GreenVsRedGame.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenVsRedGame
{
    public class GameEngine
    {
        private readonly int gridMaxSize = 1000;
        private int greenNeighboursCount;
        private char currentCellColor;
        private readonly char green = '1';
        private readonly char red = '0';
        //count of observed cell color change to green
        private int result;


        public void Start()
        {

            var gridSize = GetGridSize();
            ValidateUserInput(gridSize);

            var grid = new Grid(gridSize);

            PopulateGridWithData(grid);

            // gets on single line user input for cell coords and turns till end of the game
            var input = GetCoordsOfCellToObserveAndTurnsCount();
            var cellRow = input[0];
            var cellCol = input[1];
            if (!IsInGrid(grid.Data, cellRow, cellCol))
            {
                throw new ArgumentException(Message.obserVedCellOutOfBoundaries);
            }

            var cellToObserve = new int[] { cellRow, cellCol };
            var turns = input[2];

            //temp grid to store all data changes on grid we iterate on 
            var temporaryGrid = new Grid(gridSize);


            while (turns > 0)
            {
                temporaryGrid.Data = grid.Data.Select(x => x.ToArray())
                              .ToArray();

                for (int row = 0; row < grid.Data.GetLength(0); row++)
                {
                    for (int col = 0; col < grid.Data[row].Length; col++)
                    {

                        currentCellColor = grid.Data[row][col];

                        GetCurrentCellNeighborColorOnAllSides(grid.Data, row, col);

                        ChangeCurrentCellColorBasedOnNeighborsCount(ref currentCellColor);

                        temporaryGrid.Data[row][col] = currentCellColor;
                        greenNeighboursCount = 0;
                    }
                }

                // getting all the changes 
                grid.Data = temporaryGrid.Data;

                if (ObservedCellHasChangedColorToGreen(grid.Data, cellToObserve))
                {
                    result++;
                }
                turns--;
            }
            Console.WriteLine(result);
        }

        private void ValidateUserInput(int[] gridSize)
        {
            var row = gridSize[0];
            var col = gridSize[1];
            if (row >= gridMaxSize || col >= gridMaxSize)
            {
                throw new ArgumentException(Message.gridMaxSize);
            }
            if (row > col)
            {
                throw new ArgumentException(Message.gridRolBiggerThanCol);
            }
        }

        private void ChangeCurrentCellColorBasedOnNeighborsCount(ref char currentCellColor)
        {
            if (currentCellColor == red)
            {
                if (Rule.HasReasonToChangeFromRedToGreen(greenNeighboursCount))
                {
                    currentCellColor = green;
                }
            }
            else if (currentCellColor == green)
            {
                if (Rule.HasReasonToChangeFromGreenToRed(greenNeighboursCount))
                {
                    currentCellColor = red;
                }
            }
        }

        private bool ObservedCellHasChangedColorToGreen(char[][] grid, int[] cellToObserve)
        {
            return grid[cellToObserve[0]][cellToObserve[1]] == green;
        }

        private void GetCurrentCellNeighborColorOnAllSides(char[][] grid, int row, int col)
        {
            // Check Sides
            GetCellNeighbor(grid, row, col + 1);
            GetCellNeighbor(grid, row, col - 1);
            GetCellNeighbor(grid, row + 1, col);
            GetCellNeighbor(grid, row - 1, col);
            // Check Diagonals
            GetCellNeighbor(grid, row - 1, col - 1);
            GetCellNeighbor(grid, row + 1, col - 1);
            GetCellNeighbor(grid, row + 1, col + 1);
            GetCellNeighbor(grid, row - 1, col + 1);
        }

        private void GetCellNeighbor(char[][] grid, int row, int col)
        {
            if (IsInGrid(grid, row, col))
            {
                if (grid[row][col] == green)
                {
                    greenNeighboursCount++;
                }
            }
        }

        private bool IsInGrid(char[][] grid, int row, int col)
        {

            if (row < 0 || row >= grid.GetLength(0))
            {
                return false;
            }
            if (col < 0 || col >= grid[row].Length)
            {
                return false;
            }
            return true;
        }


        private void PopulateGridWithData(Grid grid)
        {

            for (int i = 0; i < grid.Data.GetLength(0); i++)
            {
                var input = Console.ReadLine()
                                   .ToCharArray();
                grid.Data[i] = input;
            }
        }

        private int[] GetCoordsOfCellToObserveAndTurnsCount() => Console.ReadLine()
                                                                         .Split(",")
                                                                         .Select(int.Parse)
                                                                         .ToArray();



        private int[] GetGridSize() => Console.ReadLine()
                                            .Split(",")
                                            .Select(int.Parse)
                                            .ToArray();



    }
}

