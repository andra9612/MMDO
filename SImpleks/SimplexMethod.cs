using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImpleks
{
    sealed class SimplexMethod : BasicSimplex
    {

        public  void CalculateSimlexMethod(Fraction[] functionFx, Fraction[,] limits, Fraction[] freeMembers)
        {
            InBasis = FindBasis(limits);
            Marks = CalculateMarks(limits, freeMembers, functionFx);

        }


        public override Fraction[] GetNewBasis()
        {
            throw new NotImplementedException();
        }
    }
}
