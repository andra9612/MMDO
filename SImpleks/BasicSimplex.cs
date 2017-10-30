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

        private int[] inBsis;



        public int[] InBasis { get; set; }

        public Fraction[] FunctionFx { get; set; }

        public Fraction[] Marks { get; set; }

        public Fraction[] Limits { get; set; }

        public Fraction[] FreeMembers { get; set; }


        protected int[] FindBasis(Fraction[,] limits)
        {
            int counter = 0;

            for (int i = 0; i < limits.GetLength(1); i++)
            {
                for (int j = 0; j < limits.GetLength(0); j++)
                {
                    if (limits[j, i] == Fraction.zero)
                    {
                        counter++;
                    }
                }

                if (counter == limits.GetLength(0) - 1)
                    inBsis[i] = i;

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
