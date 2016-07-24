using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicGenericMatrix
{
    interface ISumSymmetricDiagonal<T>
    {
        Matrix<T> AddSymmetricDiagonal(SymmetricMatrix<T> symmetricMatrix, DiagonalMatrix<T> diagonalMatrix);
    }
}
