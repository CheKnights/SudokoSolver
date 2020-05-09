using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int?[,] sudokuList = new int?[,] { { 11, 12, 13, 14, 15, 16, 17, 18, 19 },
                                               { 21, 22, 23, 24, 25, 26, 27, 28, 29 },
                                               { 31, 32, 33, 34, 35, 36, 37, 38, 39 },
                                               { 41, 42, 43, 44, 45, 46, 47, 48, 49 },
                                               { 51, 52, 53, 54, 55, 56, 57, 58, 59 },
                                               { 61, 62, 63, 64, 65, 66, 67, 68, 69 },
                                               { 71, 72, 73, 74, 75, 76, 77, 78, 79 },
                                               { 81, 82, 83, 84, 85, 86, 87, 88, 89 },
                                               { 91, 92, 93, 94, 95, 96, 97, 98, 99 } };

            int?[,] sudokuEasy1Liners = new int?[,] { { 9, null, 3, 7, 2, 1, 5, 8, 4 },
                                                      { 5, 2, 1, 3, null, 4, 6, 9, 7 },
                                                      { 7, 8, 4, 5, 9, 6, 2, 1, null },
                                                      { 3, 9, 2, 4, 5, 8, 1, 7, 6 },
                                                      { 8, 4, 7, 6, 1, 3, 9, 2, 5 },
                                                      { 1, 5, 6, 9, 7, 2, 4, 3, 8 },
                                                      { 2, 3, 5, 1, 6, 7, 8, 4, 9 },
                                                      { 6, 7, 8, 2, 4, 9, 3, 5, 1 },
                                                      { 4, 1, 9, 8, 3, 5, 7, 6, 2 } };

            int?[,] sudokuEasy1LinersMultipleColumns = new int?[,] { { 9, null, 3, 7, 2, 1, 5, 8, 4 },
                                                                     { 5, 2, 1, 3, null, 4, 6, 9, 7 },
                                                                     { 7, 8, 4, 5, 9, 6, 2, 1, null },
                                                                     { 3, null, 2, 4, 5, 8, 1, 7, 6 },
                                                                     { 8, 4, 7, 6, null, 3, 9, 2, 5 },
                                                                     { 1, 5, 6, 9, 7, 2, 4, 3, null },
                                                                     { 2, null, 5, 1, 6, 7, 8, 4, 9 },
                                                                     { 6, 7, 8, 2, null, 9, 3, 5, 1 },
                                                                     { 4, 1, 9, 8, 3, 5, 7, 6, null } };

            int?[,] threeByTest = new int?[,] { { null, 6, 3, null, 2, 1, null, 8, 4 },
                                                { 5, 2, 1, 3, 8, 4, 6, 9, 7 },
                                                { 7, 8, 4, 5, 9, 6, 2, 1, 3 },
                                                { null, 9, 2, null, 5, 8, null, 7, 6 },
                                                { 8, 4, 7, 6, 1, 3, 9, 2, 5 },
                                                { 1, 5, 6, 9, 7, 2, 4, 3, 8 },
                                                { null, 3, 5, null, 6, 7, null, 4, 9 },
                                                { 6, 7, 8, 2, 4, 9, 3, 5, 1 },
                                                { 4, 1, 9, 8, 3, 5, 7, 6, 2 } };

            int?[,] sudokuEasy = new int?[,] { { 9, 6, null, null, 2, 1, null, 8, null },
                                               { null, 2, 1, null, null, 4, 6, null, null },
                                               { null, null, 4, 5, 9, null, null, null, null },
                                               { 3, 9, 2, null, 5, null, null, 7, null },
                                               { 8, null, 7, null, null, null, 9, null, 5 },
                                               { null, 5, null, null, 7, null, 4, 3, 8 },
                                               { null, null, null, null, 6, 7, 8, null, null },
                                               { null, null, 8, 2, null, null, 3, 5, null },
                                               { null, 1, null, 8, 3, null, null, 6, 2 } };
            


            //var cba = new SudokuSolver.SudokuSolver(sudokuEasy1Liners).response();
            //cba = new SudokuSolver.SudokuSolver(sudokuEasy1LinersMultipleColumns).response();
            var cba = new SudokuSolver.SudokuSolver(threeByTest).Response();

            cba = new SudokuSolver.SudokuSolver(sudokuEasy).Response();

            // cba = new SudokuSolver.SudokuSolver(sudokuEasy1LinersMultipleColumns);

            // var cba = new SudokuSolver.SudokuSolver(sudokuEasy);
            // var cba = new SudokuSolver.SudokuSolver(sudokuList);

            int?[,] solutionCorrect = new int?[,] { { 9, 6, 3, 7, 2, 1, 5, 8, 4 },
                                                    { 5, 2, 1, 3, 8, 4, 6, 9, 7 },
                                                    { 7, 8, 4, 5, 9, 6, 2, 1, 3 },
                                                    { 3, 9, 2, 4, 5, 8, 1, 7, 6 },
                                                    { 8, 4, 7, 6, 1, 3, 9, 2, 5 },
                                                    { 1, 5, 6, 9, 7, 2, 4, 3, 8 },
                                                    { 2, 3, 5, 1, 6, 7, 8, 4, 9 },
                                                    { 6, 7, 8, 2, 4, 9, 3, 5, 1 },
                                                    { 4, 1, 9, 8, 3, 5, 7, 6, 2 } };

            //if (solutionResponse.Equals(solutionCorrect))
            //// if (solutionResponse.Equals(solutionResponse))
            //    Console.WriteLine("yay");
            //else
            //    Console.WriteLine("nay");
        }
    }
}

//9, 6, 3, 7, 2, 1, 5, 8, 4
//5, 2, 1, 3, 8, 4, 6, 9, 7
//7, 8, 4, 5, 9, 6, 2, 1, 3
//3, 9, 2, 4, 5, 8, 1, 7, 6
//8, 4, 7, 6, 1, 3, 9, 2, 5
//1, 5, 6, 9, 7, 2, 4, 3, 8
//2, 3, 5, 1, 6, 7, 8, 4, 9
//6, 7, 8, 2, 4, 9, 3, 5, 1
//4, 1, 9, 8, 3, 5, 7, 6, 2
