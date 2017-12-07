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
        public Tuple<Fraction[], Fraction, int[]> CalculateSimlexMethod( ref Fraction[] functionFx, ref  Fraction[,] limits, ref Fraction[] freeMembers)
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

                isEnd = CheckExitCondition(limits, marks);

            } while (!isEnd);

            return Tuple.Create(marks, Fx, InBasis);
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
            int columnIndex = 0;
            int rowIndex = 0;

            columnIndex = GetMaximumMark(marks);

            rowIndex = GetminElementToFreeMember(limits, freeMembers, columnIndex);

            CalculateTheSystem(ref limits, ref marks, ref freeMembers, rowIndex, columnIndex, ref Fx);


        }

        /// <summary>
        /// this method check 2  things for exit
        /// </summary>
        /// <param name="limits">matrix of limits</param>
        /// <param name="marks"> array of marks</param>
        /// <returns> return true or false. Thst means we need continue calculation or not</returns>
        private bool CheckExitCondition(Fraction[,] limits, Fraction[] marks)
        {
            int result = 0;
            bool isEnd = false;


            result = CheckNegativeMarks(marks);
            if (result == 0)
                result = CheckNegativeValuesUnderTheMarks(limits, marks);

            switch (result)
            {
                case 0:
                    isEnd = false;
                    break;
                case 1:
                    isEnd = true;
                    break;
                case 2:
                    isEnd = true;
                    break;
            }

            return isEnd;

        }

        /// <summary>
        /// this method check   there are negative elements under the  mark
        /// </summary>
        /// <param name="limits">matrix of limits</param>
        /// <param name="marks"> array of marks</param>
        /// <returns>return the int value/ This value means that under positive mark we has negative limits</returns>
        private int CheckNegativeValuesUnderTheMarks(Fraction[,] limits, Fraction[] marks)
        {
            int counter = 0;

            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i] > Fraction.zero)
                {
                    for (int j = 0; j < limits.GetLength(0); j++)
                    {
                        if (limits[j, i] <= Fraction.zero)
                            counter++;
                    }
                }

                if (counter == 2)
                    return 2;
                counter = 0;
            }

            return 0;
        }


        /// <summary>
        /// this method check  there are all marks is negative or not
        /// </summary>
        /// <param name="marks">array of marks</param>
        /// <returns>return the int value. This value is means that all marks are  negative or zero</returns>
        private int CheckNegativeMarks(Fraction[] marks)
        {
            int counter = 0;

            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i] <= Fraction.zero)
                    counter++;
            }

            if (counter == marks.Length)
                return 1;

            return 0;
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
            Fraction minValue = new Fraction(1000, 1);
            Fraction intermediateValue = Fraction.zero;

            int minIndex = 0;

            for (int i = 0; i < limits.GetLength(0); i++)
            {
                if (limits[i, index] > Fraction.zero)
                {
                    intermediateValue = freeMembers[i] / limits[i, index];

                    if (intermediateValue < minValue)
                    {
                        minValue = intermediateValue;
                        minIndex = i;
                    }
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
