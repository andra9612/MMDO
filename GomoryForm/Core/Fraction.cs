﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImpleks
{
    class Fraction : FractionCalculation
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
            numerator = Convert.ToInt32(common[0]);
            denumerator = Convert.ToInt32(common[1]);

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


    }
}
