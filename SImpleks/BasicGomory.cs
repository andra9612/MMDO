using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImpleks
{
    abstract class BasicGomory
    {
        protected abstract int GetIndexOfMainRow(Fraction[] freeMembers, int[] inBasis, Fraction[,] limits, int integerValues);
        protected abstract Tuple<Fraction[,], Fraction[], Fraction[]> GetNewCut(Fraction[,] limits,Fraction[] freeMembers,Fraction[] marks, int mainRowIndex);



    }
}
