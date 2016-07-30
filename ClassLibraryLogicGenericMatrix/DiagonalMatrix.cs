using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicGenericMatrix
{
    public sealed class DiagonalMatrix<T> : Matrix<T>
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
        public DiagonalMatrix(int n)
        {
            Size = n;
            Capacity = n*n;
            _matrix = new T[Size];
        }

        /// <summary>
        /// Constructor call base ctor, change element in in main diagonal.
        /// </summary>
        /// <param name="elements">Elements in main diagonal.</param>
        public DiagonalMatrix(T[] elements)
        {
            Size = elements.Length;

            _matrix = new T[Size];
            for (int i = 0; i < elements.Length; i++)
                _matrix[i] = elements[i];
        }

        #endregion

        #region Overrided methods for indexer.

        /// <summary>
        /// Methods GetValue return element from diagonal matrix.
        /// </summary>
        /// <param name="i">First index.</param>
        /// <param name="j">Second index.</param>
        /// <returns>Return element [i, j] from diagonal matrix.</returns>
        protected override T GetValue(int i, int j)
        {
            if (i < Size && j < Size)
            {
                if (i == j)
                    return _matrix[i];
                else
                    return default(T);
            }
            else
                throw new ArgumentException(nameof(GetValue));
        }

        /// <summary>
        /// Method SetValue set element in diagonal matrix.
        /// </summary>
        /// <param name="i">First index.</param>
        /// <param name="j">Second index.</param>
        /// <returns>Set element [i, i] in diagonal matrix.</returns>
        protected override void SetValue(int i, int j, T value)
        {
            if (i < Size && j < Size)
            {
                if (i == j)
                    _matrix[i] = value;
            }
            else
                throw new ArgumentException(nameof(SetValue));
        }

        #endregion
    }
}
