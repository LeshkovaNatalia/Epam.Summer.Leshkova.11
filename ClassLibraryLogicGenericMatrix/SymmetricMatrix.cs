using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicGenericMatrix
{
    public sealed class SymmetricMatrix<T> : Matrix<T>
    {
        #region Fields
        private T[][] _matrix;
        #endregion

        #region Properties
        public T[][] Matrix
        {
            get { return _matrix; }
        }
        #endregion

        #region Ctors

        /// <summary>
        /// Constructor call base ctor, create matrix with default elements.
        /// </summary>
        /// <param name="n">Matrix dimension.</param>
        public SymmetricMatrix(int n)
        {
            Size = n;
            _matrix = new T[Size][];
            for (int i = 0; i < Size; i++)
            {
                _matrix[i] = new T[n];
                n--;
            }
        }

        /// <summary>
        /// Constructor call base ctor, fill elements from array.
        /// </summary>
        /// <param name="elements">Elements in matrix.</param>
        public SymmetricMatrix(T[][] array):this(array.GetLength(0))
        {
            if(array.GetLength(0) != array.GetLength(1))
                throw new ArgumentException(nameof(array));

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                        _matrix[i][j] = array[i][j];
        }

        #endregion

        #region Overrided methods for indexer

        /// <summary>
        /// Methods GetValue return element from symmetric matrix.
        /// </summary>
        /// <param name="i">First index.</param>
        /// <param name="j">Second index.</param>
        /// <returns>Return element [i, j] from symmetric matrix.</returns>
        protected override T GetValue(int i, int j)
        {
            if (i < Size && j < Size)
                if(i <= j)
                    return _matrix[i][j];
                else
                    return _matrix[j][i];
            else
                throw new ArgumentException(nameof(GetValue));
        }

        /// <summary>
        /// Method SetValue set element in symmetric matrix.
        /// </summary>
        /// <param name="i">First index.</param>
        /// <param name="j">Second index.</param>
        /// <returns>Set element [i, j] in matrix.</returns>
        protected override void SetValue(int i, int j, T value)
        {
            if (i < Size && j < Size)
                    _matrix[i][j] = value;
            else
                throw new ArgumentException(nameof(SetValue));
        }

        #endregion
    }
}
