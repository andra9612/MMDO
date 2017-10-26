﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImpleks
{
    class Fraction: FractionCalculation
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

        public static Fraction operator  -(Fraction first ,Fraction second)
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

            result = CutDown(result);

            return result;

        }
    }
}