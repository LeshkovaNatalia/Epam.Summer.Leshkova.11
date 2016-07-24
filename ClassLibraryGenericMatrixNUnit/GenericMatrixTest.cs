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
        [Test]
        public void Test_CreateMatrix()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(4);
            matrix.ChangeElement += (sender, args) => { DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(2); };

            for (int i = 0; i < matrix.Column; i++)
                for (int j = 0; j < matrix.Row; j++)
                    matrix[i, j] = i*j;
        }

        [Test]
        public void Test_CreateSymmetricMatrix()
        {
            SymmetricMatrix<int> actual = new SymmetricMatrix<int>(new int[,] { {1, 2, 3}, {4, 5, 6}, {7, 8, 9} });

            SymmetricMatrix<int> expected = new SymmetricMatrix<int>(new int[,] { { 1, 4, 7 }, { 4, 5, 8 }, { 7, 8, 9 } });

            Assert.AreEqual(expected.GenericMatrix, actual.GenericMatrix);
        }

        [Test]
        public void TestSumMatrix_SumSquareDiagonal_ReturnMatrix()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(4);
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(new []{3, 2, 7, 8});
            Matrix<int> sumMatrix = new Matrix<int>(matrix.Column, matrix.Row);

            for (int i = 0; i < matrix.Column; i++)
                for (int j = 0; j < matrix.Row; j++)
                    matrix[i, j] = i * j;

            sumMatrix = matrix.AddSquareDiagonal(matrix, diagonalMatrix);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSumMatrix_SumStringSquareDiagonal_ReturnMatrix()
        {
            SquareMatrix<string> matrix = new SquareMatrix<string>(3);
            DiagonalMatrix<string> diagonalMatrix = new DiagonalMatrix<string>(new[] { "1", "2", "7" });

            for (int i = 0; i < matrix.Column; i++)
                for (int j = 0; j < matrix.Row; j++)
                    matrix[i, j] = string.Format("{0}, {1}", i, j);

            Matrix<string> sumMatrix = new Matrix<string>(matrix.Column, matrix.Row);
            sumMatrix = diagonalMatrix.AddSquareDiagonal(matrix, diagonalMatrix);
        }
    }
}
