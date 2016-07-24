using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLogicBook;

namespace ClassLibraryLogicBookNUnit
{
    public class SortBookYear : IComparer<Book>
    {
        /// <summary>
        /// Method Compare sorting books ascending Year field
        /// </summary>
        public int Compare(Book lhsBook, Book rhsBook)
        {
            if (lhsBook == null && rhsBook == null)
                return 0;

            if (ReferenceEquals(lhsBook, null))
                throw new ArgumentNullException(nameof(lhsBook));
            if (ReferenceEquals(rhsBook, null))
                throw new ArgumentNullException(nameof(rhsBook));

            if (lhsBook.Year > rhsBook.Year)
                return 1;
            if (lhsBook.Year < rhsBook.Year)
                return -1;

            return 0;
        }
    }
}
