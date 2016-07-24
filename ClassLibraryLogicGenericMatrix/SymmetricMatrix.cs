using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicGenericMatrix
{
    public sealed class SymmetricMatrix<T> : Matrix<T>, ISumSymmetricDiagonal<T>
    {
        #region Ctors

        /// <summary>
        /// Constructor call base ctor, create natrix with default elements.
        /// </summary>
        /// <param name="n">Matrix dimension.</param>
        public SymmetricMatrix(int n) : base(n, n)
        {
            N = n;
        }

        /// <summary>
        /// Constructor call base ctor, fill elements from array.
        /// </summary>
        /// <param name="elements">Elements in matrix.</param>
        public SymmetricMatrix(T[,] array) : base(array)
        {
            if(array.GetLength(0) != array.GetLength(1))
                throw new ArgumentException(nameof(array));

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if (i != j)
                        GenericMatrix[i, j] = GenericMatrix[j, i];
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Method AddSymmetricDiagonal add synmmetric and diagonal matrixs.
        /// </summary>
        /// <param name="squareMatrix">Symmetric matrix.</param>
        /// <param name="diagonalMatrix">Diagonal matrix.</param>
        /// <returns>Return matrix summary of two matrix.</returns>
        public Matrix<T> AddSymmetricDiagonal(SymmetricMatrix<T> symmetricMatrix, DiagonalMatrix<T> diagonalMatrix)
        {
            if (symmetricMatrix.N != diagonalMatrix.N)
                throw new ArgumentException(nameof(AddSymmetricDiagonal));

            try
            {
                Matrix<T> sumMatrix = new Matrix<T>(symmetricMatrix.Column, symmetricMatrix.Row);

                ParameterExpression paramA = Expression.Parameter(typeof(T), "elem1"),
                            paramB = Expression.Parameter(typeof(T), "elem2");
                BinaryExpression body = Expression.Add(paramA, paramB);

                Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();

                for (int i = 0; i < symmetricMatrix.Column; i++)
                    for (int j = 0; j < symmetricMatrix.Row; j++)
                        sumMatrix[i, j] = add(symmetricMatrix[i, j], diagonalMatrix[i, j]);

                return sumMatrix;
            }
            catch(Exception ex)
            {
                throw new ArgumentException(string.Format("The binary operator Add is not defined for the types {0}. {1}", typeof(T), ex.Message));
            }
        }

        #endregion
    }
}
