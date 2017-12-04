using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImpleks
{
    sealed class BinarySimplexMethod : BasicSimplex
    {

        public void CalculateBinarySimplexMethod(Fraction[] functionFx, Fraction[,] limits, Fraction[] freeMembers)
        {
            bool isEnd = false;
            int[] InBasis = FindBasis(limits);
            Fraction[] marks;
            Fraction Fx;
            marks = CalculateMarks(limits, freeMembers, functionFx, InBasis);
            Fx = FindBasicFx(functionFx, freeMembers, InBasis);
            do
            {
                //InBasis = FindBasis(limits);

                GetNewBasis(ref limits, ref freeMembers, ref functionFx, ref marks, ref InBasis, ref Fx);
                InBasis = FindBasis(limits);
                // Fx = FindBasicFx(functionFx, freeMembers, InBasis);

                isEnd = CheckExitCondition(limits, marks, freeMembers);

            } while (!isEnd);
        }

        private bool CheckExitCondition(Fraction[,] limits, Fraction[] marks, Fraction[] freeMembers)
        {
            int result = 0;

            result = CheckNegativeValue(freeMembers);

            if (result == 1)
                return true;

            return false;
        }

        private int CheckNegativeValue(Fraction[] freeMembers)
        {
            int counter = 0;

            for (int i = 0; i < freeMembers.Length; i++)
            {
                if (freeMembers[i] >= Fraction.zero)
                    counter++;
            }

            if (counter == freeMembers.Length)
                return 1;

            return 0;
        }

        /// <summary>
        /// this method calculate new basis and recalculate all system
        /// </summary>
        /// <param name="limits">matrix of limits</param>
        /// <param name="freeMembers">array of free members</param>
        /// <param name="functionFx"> array  of elements of  target function </param>
        /// <param name="marks">array of marks</param>
        /// <param name="InBasis">int  array of indexes of basis values</param>
        /// <param name="Fx">value of  functionFx</param>
        public override void GetNewBasis(ref Fraction[,] limits, ref Fraction[] freeMembers, ref Fraction[] functionFx, ref Fraction[] marks, ref int[] InBasis, ref Fraction Fx)
        {
            int rowIndex = 0;
            int columnIndex = 0;

            rowIndex = MinNegativeFreeMember(freeMembers);
            columnIndex = MinimumReferenceLimitsToMarks(limits, marks, rowIndex);

            CalculateTheSystem(ref limits, ref marks, ref freeMembers, rowIndex, columnIndex, ref Fx);

        }

        /// <summary>
        /// this method find minimum reference betweene marks and limits
        /// </summary>
        /// <param name="limits">matrix of limits</param>
        /// <param name="marks">array of marks</param>
        /// <param name="rowIndex">index of chosen row</param>
        /// <returns>index of chosen column</returns>
        private int MinimumReferenceLimitsToMarks(Fraction[,] limits, Fraction[] marks, int rowIndex)
        {
            Fraction min = new Fraction(1000, 1);
            Fraction divider = Fraction.zero;

            int result = 0;

            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i] < Fraction.zero && limits[rowIndex, i] < Fraction.zero)
                {
                    divider = marks[i] / limits[rowIndex, i];
                    if (divider < min)
                    {
                        min = divider;
                        result = i;
                    }

                }
            }

            return result;

        }

        /// <summary>
        /// this method find minimun negative  free member
        /// </summary>
        /// <param name="freeMembers">array of free members</param>
        /// <returns>index of minimum negative free member</returns>
        private int MinNegativeFreeMember(Fraction[] freeMembers)
        {
            Fraction min = Fraction.zero;
            int result = 0;

            for (int i = 0; i < freeMembers.Length; i++)
            {
                if (freeMembers[i] < Fraction.zero && freeMembers[i] < min)
                {
                    min = freeMembers[i];
                    result = i;
                }
            }

            return result;

        }

    }
}
