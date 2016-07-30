using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLogicGenericMatrix;
using NUnit.Framework;

namespace ClassLibraryGenericMatrixNUnit
{
    [TestFixture]
    public class GenericMatrixTest
    {
        #region Data

        private readonly MatrixVisitor<int> visitor = new MatrixVisitor<int>();
        private readonly MatrixVisitor<string> visitorString = new MatrixVisitor<string>();
        private readonly DiagonalMatrix<int> firstMatrix = new DiagonalMatrix<int>(new[] { 4, 5, 8, 7 });
        private readonly DiagonalMatrix<int> secondMatrix = new DiagonalMatrix<int>(new[] { 3, 2, 7, 8 });
        private readonly SquareMatrix<int> matrix = new SquareMatrix<int>(new [] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16});

        #endregion

        [Test]
        public void TestSumMatrix_SumDiagonal_ReturnMatrix()
        {
            DiagonalMatrix<int> actual = new DiagonalMatrix<int>(4);

            actual = visitor.Add(firstMatrix, secondMatrix);

            DiagonalMatrix<int> expected = new DiagonalMatrix<int>(new []{7, 7, 15, 15});

            Assert.AreEqual(expected.Matrix, actual.Matrix);
        }

        [Test]
        public void TestSumMatrix_SumDiagonalSquare_ReturnMatrix()
        {
            SquareMatrix<int> actual = visitor.Add(matrix, firstMatrix);

            SquareMatrix<int> expected = new SquareMatrix<int>(new[] { 5, 2, 3, 4, 5, 11, 7, 8, 9, 10, 19, 12, 13, 14, 15, 23 });

            Assert.AreEqual(expected.Matrix, actual.Matrix);
        }

        [Test]
        public void TestSumMatrix_SumStringSquareDiagonal_ReturnMatrix()
        {
            SquareMatrix<string> matrix = new SquareMatrix<string>(3);
            DiagonalMatrix<string> diagonalMatrix = new DiagonalMatrix<string>(new[] { "1", "2", "7" });

            for (int i = 0; i < matrix.Size; i++)
                for (int j = 0; j < matrix.Size; j++)
                    matrix[i, j] = string.Format("{0}{1}", i, j);

            SquareMatrix<string> actual = visitorString.Add(matrix, diagonalMatrix);

            SquareMatrix<string> expected = new SquareMatrix<string>(new []{"001", "01", "02", "10", "112", "12", "20", "21", "227"});

            Assert.AreEqual(expected.Matrix, actual.Matrix);
        }

        [Test]
        public void Test_CreateMatrix()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(4);
            matrix.ChangeElement += (sender, args) => { DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(2); };

            for (int i = 0; i < matrix.Size; i++)
                for (int j = 0; j < matrix.Size; j++)
                    matrix[i, j] = i * j;
        }

        [Test]
        public void Test_CreateSymmetricMatrix()
        {
            SymmetricMatrix<int> actual = new SymmetricMatrix<int>(3);
            for (int i = 0; i < actual.Size; i++)
                for (int j = 0; j < actual.Matrix[i].Length; j++)
                    actual[i, j] = i * j + 1;
        }
    }
}
