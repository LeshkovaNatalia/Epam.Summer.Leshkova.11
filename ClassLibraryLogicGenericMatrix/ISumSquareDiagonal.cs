using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicGenericMatrix
{
    interface ISumSquareDiagonal<T>
    {
        Matrix<T> AddSquareDiagonal(SquareMatrix<T> squareMatrix, DiagonalMatrix<T> diagonalMatrix);
    }
}
