using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImpleks
{
    class Program
    {
        static void Main(string[] args)
        {

            Fraction first = new Fraction(3,2);
            Fraction second = new Fraction(3,6);
            Fraction third = new Fraction(3,9);

            Fraction result = FractionCalculation.Add(first,second,third);

            Console.Write("n: {0}\n d:{1}", result.Numerator, result.Denumerator);

            Console.ReadKey();
                 
        }
    }
}