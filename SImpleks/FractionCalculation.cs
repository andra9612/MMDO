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
        /// method of  calculating the  sum of the several fractions
        /// </summary>
        /// <param name="fractions"></param>
        /// <returns> to return a  new fraction. The sum of all fractions</returns>

        public static Fraction Plus(params Fraction[] fractions)
        {
            FractionCalculation calculation = new FractionCalculation();

            Fraction commonFraction = new Fraction(0, 1);

            fractions = calculation.MakeACommonDenumerator(fractions);

            commonFraction.Denumerator = fractions[0].Denumerator;

            for (int i = 0; i < fractions.Length; i++)
            {
                commonFraction.Numerator += fractions[i].Numerator;
            }

            commonFraction = calculation.CutDown(commonFraction);
            return commonFraction;

        }

        /// <summary>
        /// method division is division few fractions.  Ferst fraction in array is divided by other 
        /// </summary>
        /// <param name="fractions"></param>
        /// <returns> return fraction after division</returns>
        public static Fraction Division(params Fraction[] fractions)
        {
            FractionCalculation calculation = new FractionCalculation();

            Fraction result = fractions[0];

            for (int i = 1; i < fractions.Length; i++)
            {
                result.Numerator *= fractions[i].Denumerator;
                result.Denumerator *= fractions[i].Numerator;
            }

            result = calculation.CutDown(result);

            return result;

        }

        /// <summary>
        /// the method multiplies several fractions
        /// </summary>
        /// <param name="fractions"> array of  fractions</param>
        /// <returns>returns the multiplication result</returns>
        public static Fraction Multiple(params Fraction[] fractions)
        {
            FractionCalculation calculation = new FractionCalculation();

            Fraction result = new Fraction(1, 1);

            for (int i = 0; i < fractions.Length; i++)
            {
                result.Numerator *= fractions[i].Numerator;
                result.Denumerator *= fractions[i].Denumerator;
            }

            result = calculation.CutDown(result);

            return result;
        }

        /// <summary>
        /// method make a common denumerator
        /// </summary>
        /// <param name="fractions">array of fractions</param>
        /// <returns>return array of fractions with common denumerator</returns>
        private Fraction[] MakeACommonDenumerator(Fraction[] fractions)
        {
            Fraction maxFraction;

            int commonMultiplier = 0;

            maxFraction = MaxDenumerator(fractions);

            bool isDivided;

            isDivided = CheckDividing(maxFraction, fractions);

            if (isDivided)
            {
                for (int i = 0; i < fractions.Length; i++)
                {
                    fractions[i] = newFraction(maxFraction.Denumerator, fractions[i]);
                }
            }
            else
            {
                commonMultiplier = GetCommonMultiplier(fractions);

                for (int i = 0; i < fractions.Length; i++)
                {
                    fractions[i] = newFraction(commonMultiplier, fractions[i]);
                }

            }

            return fractions;
        }

        /// <summary>
        /// create new fraction with new common denumerator
        /// </summary>
        /// <param name="commonDenumerator"> common denumerator for this fraction </param>
        /// <param name="fraction">some fraction</param>
        /// <returns> return a new fraction with common denumerator</returns>
        private Fraction newFraction(int commonDenumerator, Fraction fraction)
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
        private int GetCommonMultiplier(Fraction[] fractions)
        {
            int commonMultiplier = 1;

            for (int i = 0; i < fractions.Length; i++)
            {
                commonMultiplier *= fractions[i].Denumerator;
            }

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
        private Fraction MaxDenumerator(Fraction[] fractions)
        {
            Fraction maxFraction = new Fraction(1, int.MinValue);

            for (int i = 0; i < fractions.Length; i++)
            {
                if (fractions[i].Denumerator > maxFraction.Denumerator)
                    maxFraction = fractions[i];
            }

            return maxFraction;
        }

        // cut down denumerator and numerator  by  the same number
        /// <summary>
        /// this method cut down denmerator and numerator by the same number
        /// </summary>
        /// <param name="fraction">some fraction</param>
        /// <returns> return result of catting down</returns>
        private Fraction CutDown(Fraction fraction)
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
