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
            Fraction[,] limits =
            {
                {(Fraction)1, (Fraction)(-2), (Fraction)3, (Fraction)(-4), (Fraction)0, (Fraction)0, (Fraction)1},
                {(Fraction)3, (Fraction)(-1), (Fraction)(-1), (Fraction)2, (Fraction)1, (Fraction)0, (Fraction)0},
                {(Fraction)1, (Fraction)5, (Fraction)1, (Fraction)3, (Fraction)0, (Fraction)1, (Fraction)0}
            };

            int[] a = new int[4] { 1, 2, 3, 4 };

            Fraction[] freeMembers = { (Fraction)4, (Fraction)3, (Fraction)4 };

            Fraction[] functionFx = { (Fraction)2, (Fraction)3, (Fraction)0, (Fraction)(-1), (Fraction)0, (Fraction)0 };

            SimplexMethod sm = new SimplexMethod();

            sm.CalculateSimlexMethod(functionFx, limits, freeMembers);


            Console.ReadKey();
        }
    }
}