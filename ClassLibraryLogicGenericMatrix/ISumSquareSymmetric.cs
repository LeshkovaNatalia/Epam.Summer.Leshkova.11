using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicGenericMatrix
{
    interface ISumSquareSymmetric<T>
    {
        Matrix<T> AddSquareSymmetric(SquareMatrix<T> squareMatrix, SymmetricMatrix<T> symmetricMatrix);
    }
}
