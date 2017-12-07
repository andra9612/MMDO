using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImpleks
{
    class FirstGomory : BasicGomory
    {

        SimplexMethod simplex = new SimplexMethod();
        BinarySimplexMethod biSimplex = new BinarySimplexMethod();



        public void CalculateFirstGomory(Fraction[,] limits, Fraction[] freeMembers, Fraction[] functionFx, int integerValue)
        {
            int mainRowIndex = 0;
            bool isEnd = false;
            int counter = 0;

            var myTuple = simplex.CalculateSimlexMethod(ref functionFx, ref limits, ref freeMembers);

            Fraction[,] newLimits = new Fraction[limits.GetLength(0), limits.GetLength(1)];
            Fraction[] newFreeMembers = new Fraction[freeMembers.Length];
            Fraction[] newMarks = new Fraction[myTuple.Item1.Length];
            int[] newInBasis = new int[freeMembers.Length];

            do
            {
                if (counter == 0)
                {
                    mainRowIndex = GetIndexOfMainRow(freeMembers, myTuple.Item3, limits, integerValue);
                    var resize = GetNewCut(limits, myTuple.Item1, freeMembers, mainRowIndex);

                    newLimits = new Fraction[newLimits.GetLength(0) + 1, newLimits.GetLength(1) + 1];
                    newFreeMembers = new Fraction[newFreeMembers.Length + 1];
                    newMarks = new Fraction[newMarks.Length + 1];
                    newLimits = resize.Item1;
                    newFreeMembers = resize.Item2;
                    newMarks = resize.Item3;
                }
                else
                {
                    mainRowIndex = GetIndexOfMainRow(newFreeMembers, newInBasis, newLimits, integerValue);
                    var resize = GetNewCut(newLimits, newMarks, newFreeMembers, mainRowIndex);

                    newLimits = new Fraction[newLimits.GetLength(0) + 1, newLimits.GetLength(1) + 1];
                    newFreeMembers = new Fraction[newFreeMembers.Length + 1];
                    newMarks = new Fraction[newMarks.Length + 1];
                    newLimits = resize.Item1;
                    newFreeMembers = resize.Item2;
                    newMarks = resize.Item3;
                }

                var binari = biSimplex.CalculateBinarySimplexMethod(ref functionFx, newLimits, newFreeMembers, newMarks);

                newLimits = binari.Item4;
                newFreeMembers = binari.Item5;
                newMarks = binari.Item1;
                newInBasis = binari.Item3;

                newLimits = CutLimits(newLimits);
                newFreeMembers = CutOther(newFreeMembers);
                newMarks = CutOther(newMarks);

                isEnd = CheckExitCondition(newFreeMembers, integerValue, newInBasis);
                counter++;

            } while (!isEnd);


        }

        private Fraction[] CutOther(Fraction[] other)
        {
            for (int i = 0; i < other.Length; i++)
            {
                other[i] = Fraction.CutDown(other[i]);
            }

            return other;
        }



        private Fraction[,] CutLimits(Fraction[,] limits)
        {
            for (int i = 0; i < limits.GetLength(0); i++)
            {
                for (int j = 0; j < limits.GetLength(1); j++)
                {
                    limits[i, j] = Fraction.CutDown(limits[i, j]);
                }
            }

            return limits;
        }

        private bool CheckExitCondition(Fraction[] freeMembers, int integerValue, int[] inBasis)
        {
            int counter = 0;
            bool isInteger = true;

            for (int i = 0; i < freeMembers.Length; i++)
            {
                if (inBasis[i] < integerValue)
                {
                    counter++;
                    if (freeMembers[i].GetFloatPart() != Fraction.zero)
                        isInteger = false;
                }
            }

            if (counter <= integerValue  && isInteger == true)
                return true;

            return false;
        }

        protected override int GetIndexOfMainRow(Fraction[] freeMembers, int[] inBasis, Fraction[,] limits, int integerValue)
        {
            int result = 0;

            result = FindMaxFloatPart(freeMembers, integerValue, inBasis);

            if (result < 0)
                result = SelectMaxFromFloatParts(limits, freeMembers, integerValue, inBasis);

            if (result < 0)
                result = 0;
            return result;

        }


        private int SelectMaxFromFloatParts(Fraction[,] limits, Fraction[] freeMembers, int integerValue, int[] inBasis)
        {
            Fraction sum = Fraction.zero;
            Fraction max = new Fraction(int.MinValue, 1);
            Fraction value = Fraction.one;
            Fraction[] Counted = new Fraction[integerValue];
            int counter = 0;
            int result = 0;

            for (int i = 0; i < limits.GetLength(0); i++)
            {
                if (inBasis[i] <= integerValue && freeMembers[i].Numerator % freeMembers[i].Denumerator != 0)
                {
                    for (int j = 0; j < limits.GetLength(1); j++)
                    {
                        sum += limits[i, j].GetFloatPart();
                    }

                    value = freeMembers[i] / sum;
                    if (value > max)
                    {
                        max = value;
                        Counted[counter] = value;
                        result = i;
                        if (counter > 1 && Counted[counter] == Counted[counter - 1])
                        {
                            Counted[counter] = Fraction.zero;
                            Counted[counter - 1] = Fraction.zero;

                            max = Fraction.zero;

                            result = -1;

                        }
                        counter++;

                    }
                }

            }

            return result;
        }


        private int FindMaxFloatPart(Fraction[] freeMembers, int integerValue, int[] inBasis)
        {
            int result = 0;
            Fraction max = new Fraction(int.MinValue, 1);
            int[] newInBasis = new int[inBasis.Length];

            ///     Array.Copy(inBasis,newInBasis, inBasis.Length);
            //  newInBasis[newInBasis.Length] =


            for (int i = 0; i < freeMembers.Length; i++)
            {
                if (inBasis[i] <= integerValue)
                {
                    if (freeMembers[i].Numerator % freeMembers[i].Denumerator != 0 && max <= freeMembers[i].GetFloatPart())
                    {
                        max = freeMembers[i].GetFloatPart();
                        result = i;
                    }
                }
            }


            for (int i = 0; i < freeMembers.Length; i++)
            {
                if (inBasis[i] <= integerValue && max == freeMembers[i].GetFloatPart())
                {
                    return -1;
                }
            }

            return result;
        }

        protected override Tuple<Fraction[,], Fraction[], Fraction[]> GetNewCut(Fraction[,] limits, Fraction[] marks, Fraction[] freeMembers, int mainRowIndex)
        {

            Fraction[,] newLimits = new Fraction[limits.GetLength(0) + 1, limits.GetLength(1) + 1];
            Fraction[] newFreeMembers = new Fraction[freeMembers.Length + 1];
            Fraction[] newMarks = new Fraction[marks.Length + 1];

            newLimits = RecalculateLimits(limits, mainRowIndex);
            newFreeMembers = RecalculaeFreeMembers(freeMembers, mainRowIndex);
            newMarks = RecalculateMarks(marks);



            return Tuple.Create(newLimits, newFreeMembers, newMarks);
        }

        private Fraction[] RecalculateMarks(Fraction[] marks)
        {
            Fraction[] newMarks = new Fraction[marks.Length + 1];

            for (int i = 0; i < newMarks.Length; i++)
            {
                if (i == marks.Length)
                    newMarks[i] = Fraction.zero;
                else
                    newMarks[i] = marks[i];
            }

            return newMarks;

        }

        private Fraction[] RecalculaeFreeMembers(Fraction[] freeMembers, int mainRow)
        {
            Fraction[] newFreeMembers = new Fraction[freeMembers.Length + 1];

            for (int i = 0; i < newFreeMembers.Length; i++)
            {
                if (i == freeMembers.Length)
                    newFreeMembers[i] = freeMembers[mainRow].GetFloatPart() * (Fraction)(-1);
                else
                    newFreeMembers[i] = freeMembers[i];
            }

            return newFreeMembers;

        }

        private Fraction[,] RecalculateLimits(Fraction[,] limits, int mainRowIndex)
        {

            Fraction[,] newLimits = new Fraction[limits.GetLength(0) + 1, limits.GetLength(1) + 1];

            for (int i = 0; i < newLimits.GetLength(0); i++)
            {
                for (int j = 0; j < newLimits.GetLength(1); j++)
                {

                    if (i == limits.GetLength(0) && j != limits.GetLength(1))
                    {
                        //if (j != limits.GetLength(1))
                        newLimits[i, j] = limits[mainRowIndex, j].GetFloatPart() * (Fraction)(-1);

                    }

                    if (i == limits.GetLength(0) && j == limits.GetLength(1))
                        newLimits[i, j] = Fraction.one;

                    if (i < limits.GetLength(0) && j < limits.GetLength(1))
                    {
                        newLimits[i, j] = limits[i, j];
                    }

                    if (i != limits.GetLength(0) && j == limits.GetLength(1))
                    {
                        newLimits[i, j] = Fraction.zero;
                    }
                }
            }

            return newLimits;
        }
    }
}
