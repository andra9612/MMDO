using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImpleks
{
    abstract class BasicSimplex
    {




        /// <summary>
        /// tis method find basis variables
        /// </summary>
        /// <param name="limits"> matrix of limits</param>
        /// <returns> return array  of index basis variables</returns>
        protected int[] FindBasis(Fraction[,] limits)
        {
            int counter = 0;
            int basisCounter = 0;

            int[] InBasis = new int[limits.GetLength(0)];

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
                {
                    InBasis[basisCounter] = i;
                    basisCounter++;
                }

                counter = 0;
            }


            return InBasis;
        }


        /// <summary>
        /// this method calculate marks
        /// </summary>
        /// <param name="limits"> matrix of limits</param>
        /// <param name="freeMembers"> array of free members</param>
        /// <param name="functionFx"> element of objective function</param>
        /// <param name="inBasis">array of indexes that  belong to basis</param>
        /// <returns>return array of marks</returns>
        protected Fraction[] CalculateMarks(Fraction[,] limits, Fraction[] freeMembers, Fraction[] functionFx, int[] inBasis)
        {

            Fraction[] marks = new Fraction[functionFx.Length];


            for (int i = 0; i < limits.GetLength(1); i++)
            {

                marks[i] = Fraction.zero;

                for (int j = 0; j < limits.GetLength(0); j++)
                {
                    marks[i] = marks[i] + functionFx[inBasis[j]] * limits[j, i];
                }

                marks[i] = marks[i] - functionFx[i];
            }

            return marks;
        }

        protected void CalculateTheSystem(ref Fraction[,] limits, ref Fraction[] marks, ref Fraction[] freeMembers, int rowIndex, int columnIndex)
        {

        }


        /// <summary>
        /// this method will override in child classes. It's calculete new  limits, marks, free members
        /// </summary>
        /// <param name="limits">matrix of limits</param>
        /// <param name="freeMembers"> array of free members</param>
        /// <param name="functionFx">element of objective function</param>
        /// <param name="marks">array of the marks</param>
        /// <param name="InBasis">array of indexes that  belong to basis</param>
        /// <returns></returns>
        public abstract Fraction[,] GetNewBasis(Fraction[,] limits, Fraction[] freeMembers, Fraction[] functionFx, Fraction[] marks, int[] InBasis);

    }
}
