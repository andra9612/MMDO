using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImpleks
{
    class SimplexMethod : BasicSimplex
    {

        private Fraction[] functionFx;

        private Fraction[] marks;

        private Fraction[,] limits;

        private Fraction[] freeMembers;


        
        public override Fraction[] GetNewBasis()
        {
            throw new NotImplementedException();
        }
    }
}
