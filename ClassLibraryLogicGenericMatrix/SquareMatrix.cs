using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicGenericMatrix
{
    public sealed class SquareMatrix<T> : Matrix<T>
    {
        #region Fields
        private T[] _matrix;
        #endregion

        #region Properties
        public T[] Matrix
        {
            get { return _matrix; }
        }
        #endregion

        #region Ctors

        /// <summary>
        /// Constructor call base ctor, create matrix with default elements.
        /// </summary>
        /// <param name="n">Matrix dimension.</param>
        public SquareMatrix(int n)
        {
            Size = n;
            Capacity = n * n;
            _matrix = new T[Capacity];
        }

        /// <summary>
        /// Constructor call base ctor, fill elements from array.
        /// </summary>
        /// <param name="elements">Elements in matrix.</param>
        public SquareMatrix(T[] array)
        {
            Capacity = array.Length;
            Size = (int)Math.Sqrt(Capacity);
            _matrix = new T[Capacity];
            if (array.Length > 0)
            {
                for (int i = 0; i < Capacity; i++)
                        _matrix[i] = array[i];
            }
            else
                throw new ArgumentNullException(nameof(array));
        }

        #endregion

        #region Overrided methods for indexer

        /// <summary>
        /// Methods GetValue return element from square matrix.
        /// </summary>
        /// <param name="i">First index.</param>
        /// <param name="j">Second index.</param>
        /// <returns>Return element [i, j] from square matrix.</returns>
        protected override T GetValue(int i, int j)
        {
            if (i < Size && j < Size)
                return _matrix[Size * i + j];
            else
                throw new ArgumentException(nameof(GetValue));
        }

        /// <summary>
        /// Method SetValue set element in square matrix.
        /// </summary>
        /// <param name="i">First index.</param>
        /// <param name="j">Second index.</param>
        /// <returns>Set element [i, j] square in matrix.</returns>
        protected override void SetValue(int i, int j, T value)
        {
            if (i < Size && j < Size)
                _matrix[Size * i + j] = value;
            else
                throw new ArgumentException(nameof(SetValue));
        }

        #endregion
    }
}
