using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicGenericMatrix
{
    public class Matrix<T>
    {
        #region Fields
        private int _n;
        private int _m;
        #endregion

        #region Properties

        public T[,] GenericMatrix { get; set; }

        public int N
        {
            get { return _n; }
            set
            {
                if (value > 0)
                    _n = value;
                else
                    throw new ArgumentNullException(nameof(value));

            }
        }

        public int M
        {
            get { return _m; }
            set
            {
                if (value > 0)
                    _m = value;
                else
                    throw new ArgumentNullException(nameof(value));
            }
        }

        /// <summary>
        /// Count of element in Matrix
        /// </summary>
        public int Count
        {
            get { return N * M; }
        }

        /// <summary>
        /// Count of column in Matrix
        /// </summary>
        public int Column
        {
            get { return N; }
        }

        /// <summary>
        /// Count of row in Matrix
        /// </summary>
        public int Row
        {
            get { return M; }
        }

        #endregion

        #region Ctors

        public Matrix() {   }

        /// <summary>
        /// Constructor create matrix of size n x m with default elements.
        /// </summary>
        /// <param name="n">Count of columns.</param>
        /// <param name="m">Count of rows.</param>
        public Matrix(int n, int m)
        {
            GenericMatrix = new T[n, m];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    GenericMatrix[i, j] = default(T);
        }

        /// <summary>
        /// Constructor create matrix of size n x m with elements from array.
        /// </summary>
        /// <param name="array">Input elements.</param>
        public Matrix(T[,] array)
        {
            N = array.GetLength(0);
            M = array.GetLength(1);
            GenericMatrix = new T[N, M];

            for(int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    GenericMatrix[i, j] = array[i, j];
        }

        #endregion

        #region Indexer

        public T this[int x, int y]
        {
            get { return GenericMatrix[x, y]; }
            set
            {
                GenericMatrix[x, y] = value;
                OnChangeElement(new EventArgs());
            }
        }

        #endregion

        #region Event OnChangeElement

        public event EventHandler<EventArgs> ChangeElement;

        protected virtual void OnChangeElement(EventArgs e)
        {
            EventHandler<EventArgs> temp = ChangeElement;
            
            if (temp != null)
            {
                temp(this, e);
            }
        }

        #endregion
    }
}
