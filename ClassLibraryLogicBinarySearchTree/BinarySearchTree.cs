using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicBinarySearchTree
{
    public sealed class BinarySearchTree<T> : IEnumerable<T>
    {
        private class TreeNode<TValue>
        {
            #region Fields
            private TValue _element;
            #endregion

            #region Properties
            public TreeNode<TValue> LeftNode { get; set; }
            public TreeNode<TValue> RightNode { get; set; }

            public TValue Element
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
            public TreeNode(TValue element)
            {
                this.Element = element;
            }
            #endregion
        }

        #region Properties
        private TreeNode<T> RootNode { get; set; }

        public IComparer<T> Comparer { get; set; }

        public int Count { get; set; }
        #endregion

        #region Ctors
        public BinarySearchTree() : this(Comparer<T>.Default) { }

        public BinarySearchTree(IComparer<T> comparer)
        {
            try
            {
                comparer.Compare(default(T), default(T));
            }
            catch (Exception)
            {
                throw new ArgumentException(nameof(comparer));
            }

            Comparer = comparer;
        }

        public BinarySearchTree(T[] array): this(Comparer<T>.Default)
        {
            if (array.Length > 0)
                for (int i = 0; i < array.Length; i++)
                    Add(array[i]);
            else
                throw new ArgumentNullException(nameof(array));
        }

        public BinarySearchTree(T[] array, IComparer<T> comparer):this(comparer)
        {
            if (array.Length > 0)
                for (int i = 0; i < array.Length; i++)
                    Add(array[i]);
            else
                throw new ArgumentNullException(nameof(array));
        }

        public BinarySearchTree(T[] array, Comparison<T> comparer)
        {
            if (comparer != null)
                Comparer = new CompareAdapter(comparer);
            else
                Comparer = Comparer<T>.Default;
            if (array.Length > 0)
                for (int i = 0; i < array.Length; i++)
                    Add(array[i]);
            else
                throw new ArgumentNullException(nameof(array));
        }

        #endregion

        #region Public Methods

        #region Methods Add | Find | MinElement | MaxElement

        /// <summary>
        /// Method Insert add element to its position in binary tree. 
        /// </summary>
        /// <param name="x">Add element</param>
        public void Add(T x)
        {
            this.RootNode = Add(x, this.RootNode);
            Count++;
        }

        /// <summary>
        /// Method Find return element from binary tree. 
        /// </summary>
        /// <param name="x">Find element</param>
        public T Find(T x)
        {
            return ElementAt(Find(x, this.RootNode));
        }

        /// <summary>
        /// Method MinElement find min element in binary tree. 
        /// </summary>
        /// <returns>Min element in binary tree.</returns>
        public T MinElement()
        {
            return FindMinElement(this.RootNode.LeftNode);
        }

        /// <summary>
        /// Method MaxElement find max element in binary tree. 
        /// </summary>
        /// <returns>Max element in binary tree.</returns>
        public T MaxElement()
        {
            return FindMaxElement(this.RootNode.RightNode);
        }

        /// <summary>
        /// Binary tree traversal Inorder.
        /// </summary>
        public IEnumerable<T> Inorder() => Inorder(RootNode);

        /// <summary>
        /// Binary tree traversal Preorder.
        /// </summary>
        public IEnumerable<T> Preorder() => Preorder(RootNode);

        /// <summary>
        /// Binary tree traversal Postorder.
        /// </summary>
        public IEnumerable<T> Postorder() => Postorder(RootNode);

        /// <summary>
        /// Method GetEnumerator returns an enumerator that iterates through the collection.
        /// </summary>
        public IEnumerator<T> GetEnumerator() => Inorder().GetEnumerator();

        #endregion

        #endregion

        #region Private Methods

        #region Methods Preorder | Inorder | Postorder

        /// <summary>
        /// Binary tree traversal Preorder: visit the root | traverse the left subtree | traverse the right subtree.
        /// </summary>
        /// <param name="node">TreeNode element.</param>
        /// <returns>Elements from binary tree.</returns>
        private IEnumerable<T> Preorder(TreeNode<T> node)
        {
            if (node != null)
            {
                yield return node.Element;

                foreach (T t in Preorder(node.LeftNode))
                    yield return t;

                foreach (T t in Preorder(node.RightNode))
                    yield return t;
            }
        }

        /// <summary>
        /// Binary tree traversal Inorder: traverse the left subtree | visit the root | traverse the right subtree.
        /// </summary>
        /// <param name="node">TreeNode element.</param>
        /// <returns>Elements from binary tree.</returns>
        private IEnumerable<T> Inorder(TreeNode<T> node)
        {
            if (node != null)
            {
                foreach (T t in Inorder(node.LeftNode))
                    yield return t;

                yield return node.Element;

                foreach (T t in Inorder(node.RightNode))
                    yield return t;
            }
        }

        /// <summary>
        /// Binary tree traversal Postorder: traverse all the left external nodes | traverse the right subtree | visit the root.
        /// </summary>
        /// <param name="node">TreeNode element.</param>
        /// <returns>Elements from binary tree.</returns>
        private IEnumerable<T> Postorder(TreeNode<T> node)
        {
            if (node != null)
            {
                foreach (T t in Postorder(node.LeftNode))
                    yield return t;

                foreach (T t in Postorder(node.RightNode))
                    yield return t;

                yield return node.Element;
            }
        }
        #endregion

        /// <summary>
        /// Method ElementAt
        /// </summary>
        /// <param name="t">Current tree node.</param>
        /// <returns>Return element.</returns>
        private T ElementAt(TreeNode<T> t)
        {
            if (t == null)
                return default(T);

            return t.Element;
        }

        /// <summary>
        /// Method Find finds element in binary tree.
        /// </summary>
        /// <param name="x">Finds element</param>
        /// <param name="t">Current tree node.</param>
        /// <returns>Return TreeNode.</returns>
        private TreeNode<T> Find(T x, TreeNode<T> t)
        {
            while (t != null)
            {
                if (Comparer.Compare(x, t.Element) < 0)
                    t = t.LeftNode;
                else if (Comparer.Compare(x, t.Element) > 0)
                    t = t.RightNode;
                else
                    return t;
            }

            return null;
        }

        /// <summary>
        /// Method Insert add element to its position in binary tree.
        /// </summary>
        /// <param name="x">Inserted element.</param>
        /// <param name="rootNode">Current tree node.</param>
        /// <returns>Return TreeNode.</returns>
        private TreeNode<T> Add(T x, TreeNode<T> rootNode)
        {
            if (rootNode == null)
                rootNode = new TreeNode<T>(x);
            else if (Comparer.Compare(x, rootNode.Element) < 0)
                rootNode.LeftNode = Add(x, rootNode.LeftNode);
            else if (Comparer.Compare(x, rootNode.Element) > 0)
                rootNode.RightNode = Add(x, rootNode.RightNode);
            else
                Count--;

            return rootNode;
        }

        /// <summary>
        /// Method FindMaxElement is recursive, find max element in binary tree. 
        /// </summary>
        /// <returns>Max element in binary tree.</returns>
        private T FindMaxElement(TreeNode<T> treeNode)
        {
            if (treeNode.RightNode != null)
                return FindMaxElement(treeNode.RightNode);
            else
                return treeNode.Element;
        }

        /// <summary>
        /// Method FindMinElement is recursive, find min element in binary tree. 
        /// </summary>
        /// <returns>Min element in binary tree.</returns>
        private T FindMinElement(TreeNode<T> treeNode)
        {
            if (treeNode.LeftNode != null)
                return FindMaxElement(treeNode.LeftNode);
            else
                return treeNode.Element;
        }
                    
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        #region private class CompareAdapter

        /// <summary>
        /// Class CompareAdapter is Adapter between delegate and interface
        /// </summary>
        private class CompareAdapter : IComparer<T>
        {
            #region Field
            private readonly Comparison<T> _comparison;
            #endregion

            #region Ctor
            public CompareAdapter(Comparison<T> comparison)
            {
                _comparison = comparison;
            }
            #endregion

            #region Public Method
            /// <summary>
            /// Method Compare compare two array
            /// </summary>
            /// <param name="x">First array</param>
            /// <param name="y">Second array</param>
            public int Compare(T x, T y)
            {
                return _comparison(x, y);
            }
            #endregion
        }

        #endregion
    }
}
