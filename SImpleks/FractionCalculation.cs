using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImpleks
{
    class FractionCalculation
    {

        
        // add few fractions 
        
        public static Fraction Add(params Fraction[] fractions)
        {
            FractionCalculation calculation = new FractionCalculation();

            Fraction commonFraction = new Fraction(0,1);

            fractions = calculation.MakeACommonDenumerator(fractions);

            commonFraction.Denumerator = fractions[0].Denumerator;

            for (int i = 0; i < fractions.Length; i++)
            {
                commonFraction.Numerator += fractions[i].Numerator;
            }

            commonFraction = calculation.CutDown(commonFraction);
            return commonFraction;

        }
        //make common denumerator
        private Fraction[] MakeACommonDenumerator(  Fraction[] fractions)
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

        //create new fraction with new common denumerator
        private Fraction newFraction(int commonDenumerator, Fraction fraction)
        {
            int multiplier = 0;

            multiplier = commonDenumerator / fraction.Denumerator;
            fraction.Denumerator = commonDenumerator;
            fraction.Numerator *= multiplier;

            return fraction;
        }
        //find common multiplier for case when cannot find commondenumerator
        private int GetCommonMultiplier(Fraction[] fractions)
        {
            int commonMultiplier = 1;

            for (int i = 0; i < fractions.Length; i++)
            {
                commonMultiplier *= fractions[i].Denumerator;
            }

            return commonMultiplier;
        }


        //check thst we can divide max denumerator with variable  denumerator for making commondenumerator
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


        // find max denumerator
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
