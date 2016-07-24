using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLogicBook;

namespace ClassLibraryLogicBookNUnit
{
    public class SortBookPages : IComparer<Book>
    {
        /// <summary>
        /// Method Compare sorting books ascending Pages field
        /// </summary>
        public int Compare(Book lhsBook, Book rhsBook)
        {
            if (ReferenceEquals(lhsBook, null))
                throw new ArgumentNullException(nameof(lhsBook));
            if (ReferenceEquals(rhsBook, null))
                throw new ArgumentNullException(nameof(rhsBook));

            if (lhsBook.Pages > rhsBook.Pages)
                return 1;
            if (lhsBook.Pages < rhsBook.Pages)
                return -1;

            return 0;
        }
    }
}
