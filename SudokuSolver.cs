/// <summary>
/// 
/// CBK
/// Language - I have used row, column, and threeBy, to describe places on the board - 
/// line is then used when talking about one instance of them (including threeBy which isn't a line).
/// To put it another way - once you pull out _a_ row, column, or threeBy, it will then be referred to as a line (even though threeBys aren't actually a line).
/// 
/// </summary>

using System;

namespace SudokuSolver
{
    public class SudokuSolver
    {
        // Grid solution = new Grid();

        public SudokuSolver(int?[,] grid)
        {
            var b = new Board(grid);

            SolveIt(b);

            //for (int i = 0; i < 9; i++)
            //{
            //    var arr = b.Column(i);

            //    for (int x = 0; x < 9; x++)
            //        Console.Write(arr[x]);
            //    Console.ReadLine();
            //}

            //for (int x = 0; x < 3; x++)
            //{
            //    for (int y = 0; y < 3; y++)
            //    {
            //        var arr = b.ThreeBy(x, y);

            //        Console.Write("x {0} y {1} ", x, y);

            //        foreach (int z in arr)
            //            Console.Write(z);

            //        Console.WriteLine();
            //    }
            //}
        }

        private void SolveIt(Board b)
        {
            int incompleteness = b.Incompleteness();

            while (incompleteness > 0)
            {
                // If there's only the one missing number in a row, column, or three by, then fill it in
                OneOnALineCheck(b);

                if (b.Incompleteness() == 0) break;

                // If boardering rows and / or rows can be used to infer a number, do so.
                InferFromNeighbouringLines(b);

                // [TODO] I'd like this bit to be tidier - 
                // [TODO] possibly by adding into the while loop clause doby.  
                var newIncompleteness = b.Incompleteness();
                if (newIncompleteness == incompleteness)
                    throw new Exception("SolveIt is unfinished, and hasn't progressed");
                else
                    incompleteness = newIncompleteness;
            }
        }

        private delegate int NullCount(int?[] line);
        private delegate int?[] ReplaceSingleValue(int?[] line);

        /// <summary>
        /// Check each row and column - 
        /// if there's only the one unfilled cell, 
        /// it's easy to figure out what the value should be.
        /// </summary>
        private void OneOnALineCheck(Board b)
        {
            // [TODO] Should probably look at using a local method
            NullCount nullCount = delegate (int?[] line)
            {
                int nullsOnLineCount = 0;

                for (int x = 0; x < 9; x++) {
                    if (line[x] == null)
                    {
                        nullsOnLineCount++;
                    }
                }

                return nullsOnLineCount;
            };

            ReplaceSingleValue replaceSingleValue = delegate (int?[] line)
            {
                // ... figure out the missing value ... 
                // 45
                int summedV = 0;
                foreach (int? v in line)
                    summedV += v ?? 0;

                // ... and insert it.
                for (int i = 0; i < 9; i++)
                {
                    if (line[i] == null)
                    {
                        line[i] = 45 - summedV;
                        break;
                    }
                }

                return line;
            };

            // Check each row for how many nulls
            for (int x = 0; x < 9; x++)
            {
                if (nullCount(b.Row(x)) == 1)
                    b.Row(x, replaceSingleValue(b.Row(x)));
            }

            // Check each column for how many nulls
            for (int y = 0; y < 9; y++)
            {
                if (nullCount(b.Column(y)) == 1)
                    b.Column(y, replaceSingleValue(b.Column(y)));
            }

            // Check each threeBy for how many nulls
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (nullCount(b.ThreeBy(x, y)) == 1)
                        b.ThreeBy(x, y, replaceSingleValue(b.ThreeBy(x, y)));
                }
            }

            // var row = b.Line(x);

            //for (int y = 0; y < 9; y++)
            //{
            //    if (row[y] == null)
            //    {
            //        nullsOnRowCount++;
            //    }
            //}

            //// If there's only the one empty cell ... 
            //if (nullsOnRowCount == 1)
            //{
            //    // ... figure out the missing value ... 
            //    // 45
            //    int summedV = 0;
            //    foreach (int? v in row)
            //        summedV += v ?? 0;

            //    // ... and insert it.
            //    for(int i = 0; i < 9; i++)
            //    {
            //        if (row[i] == null)
            //        {
            //            row[i] = 45 - summedV;
            //            break;
            //        }
            //    }
            //}
            // }

            // Check each column for how many nulls
            for (int y = 0; y < 9; y++)
            {
                
            }
        }

        private void InferFromNeighbouringLines (Board b)
        {
            for (int x = 0; x < 9; x++)
            {
                int?[] line = b.Row(x);
                for (int y = 0; y < 9; y++)
                {
                    // If a blank item is found ... 
                    if (line[y] == null)
                    {
                        // ... start by figuring which threeBy it's in ... 

                    }
                }
            }

            for (int y = 0; y < 9; y++)
            {
                b.Column(y);
            }
        }

        public int?[,] Response()
        {
            return new int?[,] { { 9, 6, 3, 7, 2, 1, 5, 8, 4 },
                                 { 5, 2, 1, 3, 8, 4, 6, 9, 7 },
                                 { 7, 8, 4, 5, 9, 6, 2, 1, 3 },
                                 { 3, 9, 2, 4, 5, 8, 1, 7, 6 },
                                 { 8, 4, 7, 6, 1, 3, 9, 2, 5 },
                                 { 1, 5, 6, 9, 7, 2, 4, 3, 8 },
                                 { 2, 3, 5, 1, 6, 7, 8, 4, 9 },
                                 { 6, 7, 8, 2, 4, 9, 3, 5, 1 },
                                 { 4, 1, 9, 8, 3, 5, 7, 6, 2 } };
        }
    }

    //internal class Box
    //{
    //    internal int[,] box = new int[3, 3];
    //}
    //internal class Grid
    //{
    //    public Box[,] grid = new Box[3, 3];
    //}

    internal class Board
    {
        private int?[,] board = new int?[9, 9];

        internal Board(int?[,] initialBoard)
        {
            board = initialBoard;
        }

        internal int?[] Row(int line)
        {
            int?[] arrLine = new int?[9];

            for (int i = 0; i < 9; i++)
            {
                arrLine[i] = board[line, i];
            }

            return arrLine;
        }

        // [TODO] could board be set to a property, with get and set?
        internal void Row(int x, int?[] line)
        {
            for (int i = 0; i < 9; i++)
            {
                board[x, i] = line[i];
            }
        }

        internal int?[] Column(int column)
        {
            int?[] arrColumn = new int?[9];

            for (int i = 0; i < 9; i++)
            {
                arrColumn[i] = board[i, column];
            }

            return arrColumn;
        }

        internal void Column(int y, int?[] line)
        {
            for (int i = 0; i < 9; i++)
            {
                board[i, y] = line[i];
            }
        }

        internal int?[] ThreeBy(int x, int y)
        {
            int?[] arrThreeBy = new int?[9];
            //int index = 0;
            //for (int ix = x * 3; ix < (x * 3) + 3; ix++)
            //{
            //    for (int iy = y * 3; iy < (y * 3) + 3; iy++)
            //    {
            //        // arrThreeBy[(ix / 3) + (iy / 3)] = board[ix, iy];
            //        arrThreeBy[index] = board[ix, iy];
            //        index++;
            //    }
            //}

            var sx = x * 3;
            var sy = y * 3;
            var index = 0;
            for (int ix = sx; ix < sx + 3; ix++)
            {
                for (int iy = sy; iy < sy + 3; iy++)
                {
                    arrThreeBy[index] = board[ix, iy];
                    index++;
                }
            }

            return arrThreeBy;
        }

        internal void ThreeBy(int x, int y, int?[] line)
        {
            var sx = x * 3;
            var sy = y * 3;
            var index = 0;
            for (int ix = sx; ix < sx + 3; ix++)
            {
                for (int iy = sy; iy < sy + 3; iy++)
                {
                    board[ix, iy] = line[index];
                    index++;
                }
            }
        }

        /// <summary>
        /// Returns the number of squares that have not been completed - 
        /// 0 on all filled
        /// > 0 the puzzle's not completed.
        /// It might make sense to check the 'previous' calls' response
        /// to check whethere progress is being made.
        /// </summary>
        /// <returns></returns>
        internal int Incompleteness()
        {
            var unfilled = 0;

            for(int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (board[x, y] == null)
                        unfilled++;
                }
            }

            return unfilled;
        }
    }
}