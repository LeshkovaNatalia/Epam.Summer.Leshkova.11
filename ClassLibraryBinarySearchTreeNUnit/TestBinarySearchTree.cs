using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLogicBinarySearchTree;
using ClassLibraryLogicBook;
using ClassLibraryLogicBookNUnit;
using NUnit.Framework;

namespace ClassLibraryBinarySearchTreeNUnit
{
    [TestFixture]
    public class TestBinarySearchTree
    {
        #region Data

        private IEnumerable<TestCaseData> BooksComparator
        {
            get
            {
                yield return new TestCaseData(new BinarySearchTree<Book>(books), new List<Book>(new Book[] { books[2], books[1], books[0] }));
                yield return new TestCaseData(new BinarySearchTree<Book>(books, new SortBookYear()), new List<Book>(new Book[] { books[2], books[0], books[1] }));
                yield return new TestCaseData(new BinarySearchTree<Book>(books, (x, y) => x.Pages.CompareTo(y.Pages)), new List<Book>(new Book[] { books[2], books[0], books[1] }));
                yield return new TestCaseData(new BinarySearchTree<Book>(books, new SortBookAuthor()), new List<Book>(new Book[] { books[1], books[2], books[0] }));
            }
        }

        private IEnumerable<TestCaseData> StringComparator
        {
            get
            {
                yield return new TestCaseData(new BinarySearchTree<string>(new[] { "One", "Two", "Three", "Four", "Five" }), new List<string>( new string[] { "Five", "Four", "One", "Three", "Two" }));
                yield return new TestCaseData(new BinarySearchTree<string>(new[] { "One", "Two", "Three", "Four", "Five" }, (x, y) => x.Length.CompareTo(y.Length)), new List<string>(new string[] { "One", "Four", "Three" }));
            }
        }

        private readonly Book[] books = new Book[3]
        {
            new Book("Richter", "CLR via C#", 2013, 896),
            new Book("Albahari", "C# 5.0 in nutshell", 2014, 1008),
            new Book("Bertrand Meyer", "Basics of Object Oriented Programming", 2005, 500)
        };

        private readonly BinarySearchTree<int> treeOfInt = new BinarySearchTree<int>(new[] { 8, 10, 4, 9, 3, 4 });
        
        private readonly Point2D[] points = new Point2D[3]
        {
            new Point2D(1, 2), new Point2D(3, 4), new Point2D(0, 8) 
        
        };

        #endregion

        #region Test int

        [Test]
        public void TestBST_BSTFindElements_ReturnElement()
        {
            int expected = 3;
            int actual = treeOfInt.Find(3);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestBST_BSTPreorderElements_ReturnElement()
        {
            List<int> expected = new List<int>(new[] {8, 4, 3, 10, 9});
            List<int> actual = new List<int>(treeOfInt.Count);
            
            foreach (var element in BinarySearchTree<int>.Preorder(treeOfInt.RootNode))
                actual.Add(element);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestBST_BSTInorderElements_ReturnElement()
        {
            List<int> expected = new List<int>(new[] { 3, 4, 8, 9, 10 });
            List<int> actual = new List<int>(treeOfInt.Count);

            foreach (var element in BinarySearchTree<int>.Inorder(treeOfInt.RootNode))
                actual.Add(element);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestBST_BSTPostorderElements_ReturnElement()
        {
            List<int> expected = new List<int>(new[] { 3, 4, 9, 10, 8 });
            List<int> actual = new List<int>(treeOfInt.Count);

            foreach (var element in BinarySearchTree<int>.Postorder(treeOfInt.RootNode))
                actual.Add(element);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestBST_BSTFindMinElements_ReturnElement()
        {
            int actual = treeOfInt.MinElement();
            int expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestBST_BSTFindMaxElements_ReturnMaxElement()
        {
            int actual = treeOfInt.MaxElement();
            int expected = 10;
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Test string

        [Test, TestCaseSource("StringComparator")]
        public void TestBST_BSTStrInorderElements_ReturnElement(BinarySearchTree<string> stringTree, List<string> expected)
        {
            List<string> actual = new List<string>(stringTree.Count);

            foreach (var element in BinarySearchTree<string>.Inorder(stringTree.RootNode))
                actual.Add(element);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Test Book

        [Test, TestCaseSource("BooksComparator")]
        public void TestBST_BSTBookElements_ReturnDefaultComparatorTree(BinarySearchTree<Book> tree, List<Book> expected)
        {
            List<Book> actual = new List<Book>(tree.Count);

            foreach (var element in BinarySearchTree<Book>.Inorder(tree.RootNode))
                actual.Add(element);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Test Point2D

        [Test]
        public void TestBST_BSTPointElements_ReturnComparisonPointTree()
        {
            var tree = new BinarySearchTree<Point2D>(points, (point, point1) => point.X.CompareTo(point1.X));

            List<Point2D> expected = new List<Point2D>(new Point2D[] {points[2], points[0], points[1]});

            List<Point2D> actual = new List<Point2D>(tree.Count);

            foreach (var element in BinarySearchTree<Point2D>.Inorder(tree.RootNode))
                actual.Add(element);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestBST_BSTPointElements_ReturnPointTree()
        {
            var tree = new BinarySearchTree<Point2D>(points);
        }

        #endregion
    }
}
