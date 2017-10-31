using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImpleks
{
    sealed class BinarySimplexMethod : BasicSimplex
    {
        public override Fraction[,] GetNewBasis(Fraction[,] limits, Fraction[] freeMembers, Fraction[] functionFx, Fraction[] marks, int[] InBasis)
        {
            throw new NotImplementedException();
        }
    }
}
