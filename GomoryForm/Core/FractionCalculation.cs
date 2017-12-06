using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImpleks
{
    class FractionCalculation
    {




        /// <summary>
        /// method make a common denumerator
        /// </summary>
        /// <param name="fractions">array of fractions</param>
        /// <returns>return array of fractions with common denumerator</returns>
        protected static  void MakeACommonDenumerator(ref Fraction first, ref Fraction second)
        {
            Fraction maxFraction;
            bool isDivided = false;


            int commonMultiplier = 0;

            maxFraction = MaxDenumerator(first, second);

            if (maxFraction.Denumerator % first.Denumerator == 0 && maxFraction.Denumerator % second.Denumerator == 0)
                isDivided = true;

            if (isDivided)
            {
                first = newFraction(maxFraction.Denumerator, first);
                second = newFraction(maxFraction.Denumerator, second);
            }
            else
            {
                commonMultiplier = GetCommonMultiplier(first, second);

                first = newFraction(commonMultiplier, first);
                second = newFraction(commonMultiplier, second);
            }

        }

        /// <summary>
        /// create new fraction with new common denumerator
        /// </summary>
        /// <param name="commonDenumerator"> common denumerator for this fraction </param>
        /// <param name="fraction">some fraction</param>
        /// <returns> return a new fraction with common denumerator</returns>
        private static  Fraction newFraction(int commonDenumerator, Fraction fraction)
        {
            int multiplier = 0;

            multiplier = commonDenumerator / fraction.Denumerator;
            fraction.Denumerator = commonDenumerator;
            fraction.Numerator *= multiplier;

            return fraction;
        }

        /// <summary>
        /// this method finds  multiplie of  denumerators when it is  imposible to find common denumerator
        /// </summary>
        /// <param name="fractions">array of fractions</param>
        /// <returns>return common denumerator</returns>
        private static  int GetCommonMultiplier(Fraction first, Fraction second)
        {
            int commonMultiplier = 1;

            commonMultiplier *= first.Denumerator;
            commonMultiplier *= second.Denumerator;

            return commonMultiplier;
        }


        /// <summary>
        /// this method check that we can divide maxdenumerator on other denumerators or not
        /// </summary>
        /// <param name="maxFraction">fraction with max denumerator</param>
        /// <param name="fractions">array of  fractions</param>
        /// <returns>return true if we can  divide max fraction denumerator by other fractions denumerators
        ///  or false if we cannot divide
        /// </returns>
        private bool CheckDividing(Fraction maxFraction, Fraction[] fractions)
        {
            int counter = 0;

            for (int i = 0; i < fractions.Length; i++)
            {
                if (maxFraction.Denumerator % fractions[i].Denumerator == 0)
                    counter++;
            }

            if (counter == fractions.Length)
                return true;

            return false;
        }


        /// <summary>
        /// this method find maximum denumerator
        /// </summary>
        /// <param name="fractions"> array of  fractions</param>
        /// <returns> return max denumerator</returns>
        private static  Fraction MaxDenumerator(Fraction first, Fraction second)
        {
            Fraction maxFraction = new Fraction();

            if (first.Denumerator > second.Denumerator)
                maxFraction = first;
            else
                maxFraction = second;

            return maxFraction;
        }

        // cut down denumerator and numerator  by  the same number
        /// <summary>
        /// this method cut down denmerator and numerator by the same number
        /// </summary>
        /// <param name="fraction">some fraction</param>
        /// <returns> return result of catting down</returns>
        protected static Fraction CutDown(Fraction fraction)
        {
            int max = 1;

            for (int i = 1; i <= fraction.Denumerator; i++)
            {
                if (fraction.Denumerator % i == 0 && fraction.Numerator % i == 0 && i > max)
                    max = i;
            }

            fraction.Denumerator /= max;
            fraction.Numerator /= max;
            return fraction;
        }
    }
}
