using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicGenericMatrix
{
    public abstract class Matrix<T>
    {
        #region Event
        public event EventHandler<EventArgs> ChangeElement;
        #endregion

        #region Fields
        private int _size;
        private int _capacity;
        #endregion

        #region Properties

        public int Size
        {
            get { return _size; }
            set
            {
                if (value > 0)
                    _size = value;
                else
                    throw new ArgumentException(nameof(value));
            }
        }

        public int Capacity
        {
            get { return _capacity; }
            set
            {
                if (value > 0)
                    _capacity = value;
                else
                    throw new ArgumentException(nameof(value));
            }
        }

        #endregion

        #region Indexer

        /// <summary>
        /// Definition indexer for matrix.
        /// </summary>
        /// <param name="i">First indexer.</param>
        /// <param name="j">Second indexer.</param>
        /// <returns></returns>
        public T this[int i, int j]
        {
            get { return GetValue(i, j); }
            set
            {
                SetValue(i, j, value);
                OnChangeElement(new EventArgs());
            }
        }

        /// <summary>
        /// Methods GetValue return element from generic matrix.
        /// </summary>
        protected abstract T GetValue(int i, int j);

        /// <summary>
        /// Method SetValue set element in generic matrix.
        /// </summary>
        protected abstract void SetValue(int i, int j, T value);

        #endregion

        #region Event OnChangeElement

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
