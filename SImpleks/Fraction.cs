using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImpleks
{
    class Fraction
    {


        private int numerator;
        private int denumerator;

        public int Numerator
        {
            get
            {
                return numerator;
            }
            set
            {
                numerator = value;
            }
        }

        public int Denumerator
        {
            get
            {
                return denumerator;
            }
            set
            {
                denumerator = value;
            }
        }

        public Fraction(int numerator, int denumerator)
        {
            this.numerator = numerator;
            this.denumerator = denumerator;
        }



        //public string Dividing(params string[] values)
        //{
        //    int[] numerator = new int[values.Length];
        //    int[] denumerator = new int[values.Length];

        //    int finalNumerator = 1;
        //    int finalDenumerator = 1;

        //    Parse(values, ref numerator, ref denumerator);

        //    finalNumerator = numerator[0];
        //    finalDenumerator = denumerator[0];
        //    for (int i = 1; i < values.Length; i++)
        //    {
        //        finalNumerator *= denumerator[i];
        //        finalDenumerator *= numerator[i];
        //    }

        //    CheckForReduction(ref finalNumerator, ref finalDenumerator);

        //    return string.Format("{0}/{1}", finalNumerator, finalDenumerator);
        //}

        //public string Multiplication(params string[] values)
        //{
        //    int[] numerator = new int[values.Length];
        //    int[] denumerator = new int[values.Length];

        //    int finalNumerator = 1;
        //    int finalDenumerator = 1;

        //    Parse(values, ref numerator, ref denumerator);

        //    for (int i = 0; i < values.Length; i++)
        //    {
        //        finalNumerator *= numerator[i];
        //        finalDenumerator *= denumerator[i];
        //    }

        //    CheckForReduction(ref finalNumerator, ref finalDenumerator);

        //    return string.Format("{0}/{1}", finalNumerator, finalDenumerator);
        //}
        //public string Plus(params string[] values)
        //{
        //    int[] numerator = new int[values.Length];
        //    int[] denumerator = new int[values.Length];

        //    int result = 0;

        //    Parse(values, ref numerator, ref denumerator);

        //    MakeACommonDenumerator(ref numerator, ref denumerator);

        //    for (int i = 0; i < values.Length; i++)
        //    {
        //        result += numerator[i];
        //    }

        //    CheckForReduction(ref result, ref denumerator[0]);

        //    return string.Format("{0}/{1}", result, denumerator[0]);
        //}

        //private void CheckForReduction(ref int result, ref int denumerator)
        //{
        //    int max = int.MinValue;
        //    int min = int.MaxValue;

        //    bool isMinus = false;

        //    if (result < 0)
        //    {
        //        result *= -1;
        //        isMinus = true;
        //    }

        //    if (result > denumerator)
        //        min = denumerator;
        //    else
        //        min = result;

        //    if ((denumerator % result) == 0)
        //    {
        //        denumerator /= result;
        //        result /= result;
        //    }
        //    else
        //    {
        //        if ((result % denumerator) == 0)
        //        {
        //            result /= denumerator;
        //            denumerator /= denumerator;
        //        }
        //        else
        //        {
        //            for (int i = 1; i < min; i++)
        //            {
        //                if (((result % i) == 0) && ((denumerator % i) == 0) && i > max)
        //                {
        //                    max = i;
        //                }
        //            }
        //        }

        //        if (max > 0)
        //        {
        //            result /= max;
        //            denumerator /= max;
        //        }


        //    }

        //    if (isMinus)
        //        result *= -1;

        //}

        //private void MakeACommonDenumerator(ref int[] numerator, ref int[] denumerator)
        //{
        //    int[] uniqueArray;
        //    int maxValue = 0;
        //    int counter = 0;
        //    int commonDenumerator = 0;

        //    uniqueArray = FindUniqueElements(denumerator);

        //    maxValue = uniqueArray.Max();

        //    for (int i = 0; i < uniqueArray.Length; i++)
        //    {
        //        if (maxValue % uniqueArray[i] == 0)
        //        {
        //            counter++;
        //        }
        //    }


        //    if (counter == uniqueArray.Length)
        //    {
        //        for (int i = 0; i < numerator.Length; i++)
        //        {
        //            numerator[i] = (maxValue / denumerator[i]) * numerator[i];
        //            denumerator[i] = maxValue;
        //        }
        //    }
        //    else
        //    {
        //        commonDenumerator = maxValue;

        //        for (int i = 0; i < uniqueArray.Length; i++)
        //        {
        //            if (maxValue != uniqueArray[i])
        //                commonDenumerator *= uniqueArray[i];
        //        }

        //        for (int i = 0; i < numerator.Length; i++)
        //        {
        //            numerator[i] = (commonDenumerator / denumerator[i]) * numerator[i];
        //            denumerator[i] = commonDenumerator;

        //        }
        //    }

        //}

        //private int[] FindUniqueElements(int[] denumerator)
        //{
        //    bool isUnique = true;

        //    int counter = 0;

        //    int[] intermediateArray = new int[denumerator.Length];

        //    for (int i = 0; i < denumerator.Length; i++)
        //    {
        //        for (int j = 0; j < denumerator.Length; j++)
        //        {
        //            if (denumerator[i] == denumerator[j] && i != j && i > j)
        //                isUnique = false;
        //        }

        //        if (isUnique)
        //        {
        //            intermediateArray[counter] = denumerator[i];
        //            counter++;
        //        }
        //        isUnique = true;

        //    }

        //    Array.Resize(ref intermediateArray, counter);

        //    return intermediateArray;
        //}

        //private void Parse(string[] values, ref int[] numerator, ref int[] denumerator)
        //{
        //    int counter = 0;
        //    string intermediate = string.Empty;
        //    int[] fraction = new int[2];

        //    string common = string.Empty;


        //    for (int i = 0; i < values.Length; i++)
        //    {
        //        common = values[i];
        //        for (int j = 0; j < common.Length; j++)
        //        {
        //            if (common[j] != '/')
        //            {
        //                intermediate += common[j];
        //            }
        //            if (common[j] == '/' || j == common.Length - 1)
        //            {
        //                if (counter == 0)
        //                    numerator[i] = Convert.ToInt32(intermediate);
        //                else
        //                    denumerator[i] = Convert.ToInt32(intermediate);

        //                counter++;
        //                intermediate = string.Empty;
        //            }
        //        }

        //        counter = 0;
        //    }

        //}

    }
}
