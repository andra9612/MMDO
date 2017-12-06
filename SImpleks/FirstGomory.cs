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

            var myTuple = simplex.CalculateSimlexMethod(ref functionFx, ref limits, ref freeMembers);

            mainRowIndex = GetIndexOfMainRow(freeMembers, myTuple.Item3, limits, integerValue);



        }

        protected override int GetIndexOfMainRow(Fraction[] freeMembers, int[] inBasis, Fraction[,] limits, int integerValue)
        {

            int result = 0;

            result = FindMaxFloatPart(freeMembers, integerValue, inBasis);

            //if (result < 0)
            result = SelectMaxFromFloatParts(limits, freeMembers, integerValue, inBasis);

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
                    if(value > max)
                    {
                        max = value;
                        Counted[counter] = value;
                        result = i;
                        if (counter > 1 && Counted[counter] == Counted[counter-1])
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

        private int GetMaximum(Fraction[] Counted, int result)
        {
            for (int i = 0; i < Counted.Length; i++)
            {
                if()
            }
        }

        private int FindMaxFloatPart(Fraction[] freeMembers, int integerValue, int[] inBasis)
        {
            int result = 0;
            Fraction max = new Fraction(int.MinValue, 1);

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

        protected override void GetNewCut(Fraction[] limits, Fraction[] freeMembers)
        {
            throw new NotImplementedException();
        }

    }
}
