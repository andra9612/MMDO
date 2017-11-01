using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImpleks
{
    sealed class BinarySimplexMethod : BasicSimplex
    {
       
        public override void GetNewBasis(ref Fraction[,] limits, ref Fraction[] freeMembers, ref Fraction[] functionFx, ref Fraction[] marks, ref int[] InBasis)
        {
            throw new NotImplementedException();
        }

    
    }
}
