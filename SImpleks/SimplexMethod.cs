using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImpleks
{
    sealed class SimplexMethod : BasicSimplex
    {
        /// <summary>
        /// Method that makes all calculation in simplex method
        /// </summary>
        /// <param name="functionFx"> elements of objective function</param>
        /// <param name="limits"> matrix element f limits</param>
        /// <param name="freeMembers">free members  of limits</param>
        public void CalculateSimlexMethod(Fraction[] functionFx, Fraction[,] limits, Fraction[] freeMembers)
        {
            int[] InBasis = FindBasis(limits);
            Fraction[] marks = CalculateMarks(limits, freeMembers, functionFx, InBasis);
            GetNewBasis(ref limits, ref freeMembers, ref functionFx, ref marks, ref InBasis);
        }

        public override void GetNewBasis(ref Fraction[,] limits, ref Fraction[] freeMembers, ref Fraction[] functionFx, ref Fraction[] marks, ref int[] InBasis)
        {
            int columnIndex = 0;
            int rowIndex = 0;

            columnIndex = GetMaximumMark(marks);

            rowIndex = GetminElementToFreeMember(limits, freeMembers, columnIndex);

            CalculateTheSystem(ref limits, ref marks, ref freeMembers, rowIndex, columnIndex);


        }


        private int CheckExitCondition(Fraction[,] limits ,  Fraction[] marks)
        {
            int result = 0;

            for (int i = 0; i < marks.Length; i++)
            {
                ///if(marks[i] <= Fraction.zero)

            }

            return result;

        }


        /// <summary>
        /// this method calculate relation of limits to free members by some index
        /// </summary>
        /// <param name="limits">matrix of limits</param>
        /// <param name="freeMembers">array of free members</param>
        /// <param name="index">index of calculated column</param>
        /// <returns>return index of minimum relation of limits to free members</returns>
        private int GetminElementToFreeMember(Fraction[,] limits, Fraction[] freeMembers, int index)
        {
            Fraction minValue = new Fraction(int.MaxValue, 1);
            Fraction intermediateValue = Fraction.zero;

            int minIndex = 0;

            for (int i = 0; i < limits.GetLength(0); i++)
            {
                intermediateValue = freeMembers[i] / limits[i, index];

                if (intermediateValue < minValue)
                {
                    minValue = intermediateValue;
                    minIndex = i;
                }
            }

            return minIndex;
        }


        /// <summary>
        /// method that find index of maximum mark
        /// </summary>
        /// <param name="marks">array of the marks</param>
        /// <returns>return index of maximum mark</returns>
        private int GetMaximumMark(Fraction[] marks)
        {
            Fraction max = new Fraction(int.MinValue, 1);
            int index = 0;

            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i] > max)
                {
                    max = marks[i];
                    index = i;
                }
            }

            return index;
        }
    }
}
