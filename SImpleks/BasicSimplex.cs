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
            bool isOne = false;

            int[] InBasis = new int[limits.GetLength(0)];

            for (int i = 0; i < limits.GetLength(1); i++)
            {
                for (int j = 0; j < limits.GetLength(0); j++)
                {
                    if (limits[j, i] == Fraction.zero)
                    {
                        counter++;
                    }
                    else if (limits[j, i] == Fraction.one && isOne == false)
                        isOne = true;
                }

                if (counter == limits.GetLength(0) - 1 && isOne)
                {
                    InBasis[basisCounter] = i;
                    basisCounter++;
                    isOne = false;
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


        /// <summary>
        /// this method recalculate system. Recalculate limits, free members  and marks
        /// </summary>
        /// <param name="limits">matrix of limits</param>
        /// <param name="marks">array of marks</param>
        /// <param name="freeMembers">array of free members</param>
        /// <param name="rowIndex">row index of chosen element</param>
        /// <param name="columnIndex">column index  of chosen element</param>
        protected void CalculateTheSystem(ref Fraction[,] limits, ref Fraction[] marks, ref Fraction[] freeMembers, int rowIndex, int columnIndex, ref Fraction Fx)
        {
            Fraction divider = limits[rowIndex, columnIndex];

            limits = RecalculateChosenRow(limits, rowIndex, divider);
            freeMembers = RecalculateFreeMembers(limits, freeMembers, divider, rowIndex, columnIndex);
            limits = RecalculateLimits(limits, columnIndex, rowIndex);
            marks = RecalculateMarks(limits, marks, rowIndex, columnIndex, ref Fx, freeMembers);
        }




        /// <summary>
        /// this method recalculate array of free members
        /// </summary>
        /// <param name="limits">matrix of  limits</param>
        /// <param name="freeMembers">array of free members</param>
        /// <param name="divider">divider of chosen row</param>
        /// <param name="rowIndex">row index of chosen element</param>
        /// <param name="columnIndex">column index of chosen element</param>
        /// <returns>return array of recalculating free members</returns>
        private Fraction[] RecalculateFreeMembers(Fraction[,] limits, Fraction[] freeMembers, Fraction divider, int rowIndex, int columnIndex)
        {
            Fraction multiplier = Fraction.zero;

            freeMembers[rowIndex] = freeMembers[rowIndex] / divider;

            for (int i = 0; i < limits.GetLength(0); i++)
            {
                if (i != rowIndex)
                    freeMembers[i] = freeMembers[i] + (freeMembers[rowIndex] * limits[i, columnIndex] * (Fraction)(-1));
            }

            return freeMembers;

        }

        /// <summary>
        /// this method recalculate marks
        /// </summary>
        /// <param name="limits">matrix of limits</param>
        /// <param name="marks">array of  marks</param>
        /// <param name="rowIndex"> row index of chosen element</param>
        /// <param name="columnIndex">column index of chosen element</param>
        /// <returns>return array of recalculating marks</returns>
        private Fraction[] RecalculateMarks(Fraction[,] limits, Fraction[] marks, int rowIndex, int columnIndex, ref Fraction Fx, Fraction[] freeMembers)
        {

            Fraction divider = marks[columnIndex];

            for (int i = 0; i < limits.GetLength(1); i++)
            {
                marks[i] = marks[i] + limits[rowIndex, i] * divider * (Fraction)(-1);
            }

            Fx = Fx + freeMembers[rowIndex] * divider * (Fraction)(-1);

            return marks;
        }



        /// <summary>
        /// this method recalculate matrix of limits
        /// </summary>
        /// <param name="limits"> matrix of limits</param>
        /// <param name="columnIndex">column index of chosen element</param>
        /// <param name="rowIndex"> row index of choosen element </param>
        /// <returns> return recalculating matrix o limits</returns>
        private Fraction[,] RecalculateLimits(Fraction[,] limits, int columnIndex, int rowIndex)
        {
            Fraction multiplier = Fraction.zero;

            for (int i = 0; i < limits.GetLength(0); i++)
            {
                multiplier = limits[i, columnIndex] * (Fraction)(-1);

                for (int j = 0; j < limits.GetLength(1); j++)
                {

                    if (i != rowIndex)
                    {
                        limits[i, j] = limits[i, j] + limits[rowIndex, j] * multiplier;
                    }
                }
            }

            return limits;
        }


        /// <summary>
        /// this  method recalculate over chosen row
        /// </summary>
        /// <param name="limits">matrix of limits</param>
        /// <param name="rowIndex">row index of over chosen element</param>
        /// <param name="divider"> divider of over  chosen row</param>
        /// <returns>return matrix of limits with recalculating chosen row</returns>
        private Fraction[,] RecalculateChosenRow(Fraction[,] limits, int rowIndex, Fraction divider)
        {
            for (int i = 0; i < limits.GetLength(1); i++)
            {
                limits[rowIndex, i] = limits[rowIndex, i] / divider;
            }

            return limits;
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
        public abstract void GetNewBasis(ref Fraction[,] limits, ref Fraction[] freeMembers, ref Fraction[] functionFx, ref Fraction[] marks, ref int[] InBasis, ref Fraction Fx);

        protected Fraction FindBasicFx(Fraction[] functionFx, Fraction[] freeMembers, int[] InBasis)
        {
            Fraction Fx = Fraction.zero;

            for (int i = 0; i < freeMembers.Length; i++)
            {
                Fx = Fx + freeMembers[i] * functionFx[InBasis[i]];
            }

            return Fx;
        }

    }

}