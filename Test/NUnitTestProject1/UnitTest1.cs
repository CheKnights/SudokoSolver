using NUnit.Framework;

namespace NUnitTestProject1
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int?[,] sudokuEasy = new int?[,] { { 9, 6, null, null, 2, 1, null, 8, null },
                                               { null, 2, 1, null, null, 4, 6, null, null },
                                               { null, null, 4, 5, 9, null, null, null, null },
                                               { 3, 9, 2, null, 5, null, null, 7, null },
                                               { 8, null, 7, null, null, null, 9, null, 5 },
                                               { null, 5, null, null, 7, null, 4, 3, 8 },
                                               { null, null, null, null, 6, 7, 8, null, null },
                                               { null, null, 8, 2, null, null, 3, 5, null },
                                               { null, 1, null, 8, 3, null, null, 6, 2 } };

            var cba = new SudokuSolver.SudokuSolver(sudokuEasy);


            int?[,] solutionCorrect = new int?[,] { { 9, 6, 3, 7, 2, 1, 5, 8, 4 },
                                                    { 5, 2, 1, 3, 8, 4, 6, 9, 7 },
                                                    { 7, 8, 4, 5, 9, 6, 2, 1, 3 },
                                                    { 3, 9, 2, 4, 5, 8, 1, 7, 6 },
                                                    { 8, 4, 7, 6, 1, 3, 9, 2, 5 },
                                                    { 1, 5, 6, 9, 7, 2, 4, 3, 8 },
                                                    { 2, 3, 5, 1, 6, 7, 8, 4, 9 },
                                                    { 6, 7, 8, 2, 4, 9, 3, 5, 1 },
                                                    { 4, 1, 9, 8, 3, 5, 7, 6, 2 } };

            int?[,] solutionReturned = cba.Response();

            Assert.AreEqual(solutionCorrect, solutionReturned);

            //int?[,] solution = new int?[,] { { 9, 6,  ,  , 2, 1,  , 8,   },
            //                                 {  , 2, 1,  ,  , 4, 6,  ,   },
            //                                 {  ,  , 4, 5, 9,  ,  ,  ,   },
            //                                 { 3, 9, 2,  , 5,  ,  , 7,   },
            //                                 { 8,  , 7,  ,  ,  , 9,  , 5 },
            //                                 {  , 5,  ,  , 7,  , 4, 3, 8 },
            //                                 {  ,  ,  ,  , 6, 7, 8,  ,   },
            //                                 {  ,  , 8, 2,  ,  , 3, 5,   },
            //                                 {  , 1,  , 8, 3,  ,  , 6, 2 } };

        }

        [Test]
        public void TestThreeBy()
        {
            int?[,] solutionCorrect = new int?[,] { { 9, 6, 3, 7, 2, 1, 5, 8, 4 },
                                                    { 5, 2, 1, 3, 8, 4, 6, 9, 7 },
                                                    { 7, 8, 4, 5, 9, 6, 2, 1, 3 },
                                                    { 3, 9, 2, 4, 5, 8, 1, 7, 6 },
                                                    { 8, 4, 7, 6, 1, 3, 9, 2, 5 },
                                                    { 1, 5, 6, 9, 7, 2, 4, 3, 8 },
                                                    { 2, 3, 5, 1, 6, 7, 8, 4, 9 },
                                                    { 6, 7, 8, 2, 4, 9, 3, 5, 1 },
                                                    { 4, 1, 9, 8, 3, 5, 7, 6, 2 } };

            int?[,] threeByTest = new int?[,] { { null, 6, 3, null, 2, 1, null, 8, 4 },
                                                { 5, 2, 1, 3, 8, 4, 6, 9, 7 },
                                                { 7, 8, 4, 5, 9, 6, 2, 1, 3 },
                                                { null, 9, 2, null, 5, 8, null, 7, 6 },
                                                { 8, 4, 7, 6, 1, 3, 9, 2, 5 },
                                                { 1, 5, 6, 9, 7, 2, 4, 3, 8 },
                                                { null, 3, 5, null, 6, 7, null, 4, 9 },
                                                { 6, 7, 8, 2, 4, 9, 3, 5, 1 },
                                                { 4, 1, 9, 8, 3, 5, 7, 6, 2 } };

            var cba = new SudokuSolver.SudokuSolver(threeByTest).Response();

            Assert.AreEqual(solutionCorrect, threeByTest);
        }

        /// <summary>
        /// https://en.wikipedia.org/wiki/Sudoku_solving_algorithms
        /// Should be bruteforcible.
        /// </summary>
        [Test]
        public void TestNotBruteForcible()
        {
            int?[,] solutionCorrect = new int?[,] { { null, null, null, null, null, null, null, null, null },
                                                    { null, null, null, null, null, 3, null,  8, 5 },
                                                    { null, null, 1, null, 2, null, null, null, null },
                                                    { null, null, null, 5, null, 7, null, null, null },
                                                    { null, null, 4, null, null, null, 1, null, null },
                                                    { null, 9, null, null, null, null, null, null, null },
                                                    { 5, null, null, null, null, null, null, 7, 3 },
                                                    { null, null, 2, null, 1, null, null, null, null },
                                                    { null, null, null, null, 4, null, null, null, 9} };
        }
    }
}