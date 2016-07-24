using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicBinarySearchTree
{
    public class TreeNode<T>
    {
        #region Fields
        private T _element;
        #endregion

        #region Properties
        public TreeNode<T> LeftNode { get; set; }
        public TreeNode<T> RightNode { get; set; }

        public T Element
        {
            get { return _element; }
            set
            {
                if (value != null)
                    _element = value;
                else
                    throw new ArgumentNullException(nameof(value));
            }
        }
        #endregion

        #region Ctors
        public TreeNode(T element)
        {
            this.Element = element;
        }
        #endregion
    }
}
