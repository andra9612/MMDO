using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImpleks
{
    class Fraction 
    {
        public static Fraction zero = new Fraction(0, 1);
        public static Fraction one = new Fraction(1, 1);

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

        public static explicit operator Fraction(int v)
        {
            return new Fraction(v);
        }



        public int Denumerator
        {
            get
            {
                return denumerator;
            }
            set
            {
                if (value > 0)
                    denumerator = value;
            }
        }

        public Fraction(int numerator, int denumerator)
        {
            this.numerator = numerator;
            this.denumerator = denumerator;
        }

        public Fraction()
        {
            numerator = 1;
            denumerator = 1;
        }

        public Fraction(int value)
        {
            numerator = value;
            denumerator = 1;
        }

        public Fraction(string value)
        {

            string[] common = new string[2];
            common = value.Split('/');
            if (common.Length > 1)
            {
                numerator = Convert.ToInt32(common[0]);
                denumerator = Convert.ToInt32(common[1]);
            }
            else
            {
                numerator = Convert.ToInt32(common[0]);
                denumerator = 1;

            }
        }


        public static Fraction operator +(Fraction first, Fraction second)
        {
            Fraction result = new Fraction();
            MakeACommonDenumerator(ref first, ref second);
            result.denumerator = first.denumerator;

            result.numerator = first.numerator + second.numerator;

            result = CutDown(result);
            return result;

        }

        public static Fraction operator -(Fraction first, Fraction second)
        {
            Fraction result = new Fraction();
            MakeACommonDenumerator(ref first, ref second);
            result.denumerator = first.denumerator;

            result.numerator = first.numerator - second.numerator;

            result = CutDown(result);
            return result;
        }

        public static Fraction operator *(Fraction first, Fraction second)
        {
            Fraction result = new Fraction();

            result.numerator = first.numerator * second.numerator;
            result.denumerator = second.denumerator * first.denumerator;

            result = CutDown(result);

            return result;
        }

        public static Fraction operator /(Fraction first, Fraction second)
        {
            Fraction result = new Fraction();

            result.numerator = first.numerator * second.denumerator;
            result.denumerator = first.denumerator * second.numerator;

            if(result.denumerator < 0)
            {
                result.denumerator *= -1;
                result.numerator *= -1;
            }

            result = CutDown(result);

            return result;

        }

        public static bool operator <(Fraction first, Fraction second)
        {
            MakeACommonDenumerator(ref first, ref second);

            if (first.numerator < second.numerator)
                return true;

            return false;
        }

        public static bool operator >(Fraction first, Fraction second)
        {
            MakeACommonDenumerator(ref first, ref second);

            if (first.numerator > second.numerator)
                return true;

            return false;
        }

        public static bool operator ==(Fraction first, Fraction second)
        {
            MakeACommonDenumerator(ref first, ref second);


            if (first.numerator == second.numerator)
                return true;

            return false;
        }

        public static bool operator !=(Fraction first, Fraction second)
        {
            MakeACommonDenumerator(ref first, ref second);

            if (first.numerator != second.numerator)
                return true;

            return false;
        }


        public static bool operator <=(Fraction first, Fraction second)
        {
            MakeACommonDenumerator(ref first, ref second);

            if (first.numerator <= second.numerator)
                return true;

            return false;
        }


        public static bool operator >=(Fraction first, Fraction second)
        {
            MakeACommonDenumerator(ref first, ref second);

            if (first.numerator >= second.numerator)
                return true;

            return false;
        }

        public Fraction GetFloatPart()
        {
            Fraction result;
            Fraction value = new Fraction(numerator, denumerator);
            int integerPart = 0;

            integerPart = numerator / denumerator;
            if (value < zero)
                integerPart -= 1;
            result = new Fraction(integerPart);

            result = value - result;

            return result;
        }

        public  void Parse(string values)
        {
            string[] common = new string[2];
            common = values.Split('/');
            if(common.Length > 1)
            {
                numerator = Convert.ToInt32(common[0]);
                denumerator = Convert.ToInt32(common[1]);
            }
            else
            {
                numerator = Convert.ToInt32(common[0]);
                denumerator = 1;

            }

            //for (int i = 0; i < values.Length; i++)
            //{
            //    common = values[i];
            //    for (int j = 0; j < common.Length; j++)
            //    {
            //        if (common[j] != '/')
            //        {
            //            intermediate += common[j];
            //        }
            //        if (common[j] == '/' || j == common.Length - 1)
            //        {
            //            if (counter == 0)
            //                numerator[i] = Convert.ToInt32(intermediate);
            //            else
            //                denumerator[i] = Convert.ToInt32(intermediate);

            //            counter++;
            //            intermediate = string.Empty;
            //        }
            //    }

            //    counter = 0;
            //}

        }


        protected static void MakeACommonDenumerator(ref Fraction first, ref Fraction second)
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
        private static Fraction newFraction(int commonDenumerator, Fraction fraction)
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
        private static int GetCommonMultiplier(Fraction first, Fraction second)
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
        private static Fraction MaxDenumerator(Fraction first, Fraction second)
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
        public static Fraction CutDown(Fraction fraction)
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
