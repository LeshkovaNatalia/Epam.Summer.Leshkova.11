using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicGenericMatrix
{
    public sealed class DiagonalMatrix<T> : Matrix<T>, ISumSquareDiagonal<T>
    {
        #region Ctors

        /// <summary>
        /// Constructor call base ctor, create natrix with default elements.
        /// </summary>
        /// <param name="n">Matrix dimension.</param>
        public DiagonalMatrix(int n) : base(n, n)
        {
            N = n;
        }

        /// <summary>
        /// Constructor call base ctor, change element in in main diagonal.
        /// </summary>
        /// <param name="elements">Elements in main diagonal.</param>
        public DiagonalMatrix(T[] elements) : base(elements.Length, elements.Length)
        {
            for (int i = 0; i < elements.Length; i++)
                for(int j = 0; j < elements.Length; j++)
                    if (i == j)
                        GenericMatrix[i, j] = elements[i];
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method AddSquareDiagonal add square and diagonal matrixs.
        /// </summary>
        /// <param name="squareMatrix">Square matrix.</param>
        /// <param name="diagonalMatrix">Diagonal matrix.</param>
        /// <returns>Return matrix summary of two matrix.</returns>
        public Matrix<T> AddSquareDiagonal(SquareMatrix<T> squareMatrix, DiagonalMatrix<T> diagonalMatrix)
        {
            return squareMatrix.AddSquareDiagonal(squareMatrix, diagonalMatrix);
        }

        #endregion
    }
}
