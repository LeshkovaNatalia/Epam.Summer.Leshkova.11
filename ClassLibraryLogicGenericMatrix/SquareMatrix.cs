using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicGenericMatrix
{
    public sealed class SquareMatrix<T> : Matrix<T>, ISumSquareDiagonal<T>
    {
        #region Ctors

        /// <summary>
        /// Constructor call base ctor, create natrix with default elements.
        /// </summary>
        /// <param name="n">Matrix dimension.</param>
        public SquareMatrix(int n) : base(n, n)
        {
            N = n;
        }

        /// <summary>
        /// Constructor call base ctor, fill elements from array.
        /// </summary>
        /// <param name="elements">Elements in matrix.</param>
        public SquareMatrix(T[,] array) : base(array)
        {
            if (array.GetLength(0) != array.GetLength(1))
                throw new ArgumentException(nameof(array));
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
            if(squareMatrix.N != diagonalMatrix.N)
                throw new ArgumentException(nameof(AddSquareDiagonal));

            try
            {
                Matrix<T> sumMatrix = new Matrix<T>(squareMatrix.Column, squareMatrix.Row);

                ParameterExpression paramA = Expression.Parameter(typeof(T), "elem1"),
                            paramB = Expression.Parameter(typeof(T), "elem2");
                BinaryExpression body = Expression.Add(paramA, paramB);

                Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();

                for (int i = 0; i < squareMatrix.Column; i++)
                    for (int j = 0; j < squareMatrix.Row; j++)
                        sumMatrix[i, j] = add(squareMatrix[i, j], diagonalMatrix[i, j]);

                return sumMatrix;
            }
            catch
            {
                throw new ArgumentException(string.Format("The binary operator Add is not defined for the types {0}", typeof(T)));
            }
        }

        #endregion
    }
}
