using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImpleks
{
    abstract class BasicSimplex
    {


        private Fraction[] functionFx;

        private Fraction[] marks;

        private Fraction[,] limits;

        private Fraction[] freeMembers;

        private Fraction[] inBsis;



        public Fraction[] InBasis { get; set; }

        public Fraction[] FunctionFx { get; set; }

        public Fraction[] Marks { get; set; }

        public Fraction[] Limits { get; set; }

        public Fraction[] FreeMembers { get; set; }


        protected Fraction[] FindBasis(Fraction[,] limits)
        {
            int counter = 0;

            for (int j = 0; j < limits.GetLength(1); j++)
            {
                for (int i= 0; i < limits.GetLength(0); i++)
                {
                    if (limits[i, j] == (Fraction)0)
                        counter++;
                }

                if (counter == limits.GetLength(1) - 1)
                    InBasis[j] = limits[j, 0];
                    counter = 0;
            }

            return InBasis;
        }

        protected Fraction[] CalculateMarks(Fraction[,] limits, Fraction[] freemembers, Fraction[] functionFx)
        {

            Fraction[] marks = new Fraction[functionFx.Length];

            for (int i = 0; i < functionFx.Length; i++)
            {
                for (int j = 0; j < freemembers.Length; j++)
                {
                    marks[i] += limits[j, i] * freeMembers[j];
                }

                marks[i] -= functionFx[i];

            }

            return marks;
        }



        /// <summary>
        /// transition to a new basis
        /// </summary>
        /// <returns></returns>
        public abstract Fraction[] GetNewBasis();






    }
}
