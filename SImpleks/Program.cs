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
            //Fraction[,] limits =
            //{
            //    { (Fraction)(-1), (Fraction)1, (Fraction)1, (Fraction)0, (Fraction)0},
            //    {(Fraction)(-1), (Fraction)3, (Fraction)0, (Fraction)1, (Fraction)0},
            //     {(Fraction)5, (Fraction)1, (Fraction)0, (Fraction)0, (Fraction)1}
            //};

            //Fraction[] freeMembers = { (Fraction)2, (Fraction)10, (Fraction)30 };

            //Fraction[] functionFx = { (Fraction)10, (Fraction)(-15), (Fraction)0, (Fraction)0, (Fraction)0 };

            //SimplexMethod sm = new SimplexMethod();

            // sm.CalculateSimlexMethod(functionFx, limits, freeMembers);

            //            Fraction[,] limits =
            //{
            //                { (Fraction)(-3), (Fraction)(-1), (Fraction)1, (Fraction)0,(Fraction)0},
            //                {(Fraction)(-4), (Fraction)(-3), (Fraction)0, (Fraction)1, (Fraction)0},
            //                {(Fraction)1, (Fraction)2, (Fraction)0, (Fraction)0, (Fraction)1}
            //            };

            //            Fraction[] freeMembers = { (Fraction)(-3), (Fraction)(-6), (Fraction)3 };

            //            Fraction[] functionFx = { (Fraction)2, (Fraction)1, (Fraction)0, (Fraction)0, (Fraction)0};

            //            BinarySimplexMethod bs = new BinarySimplexMethod();

            //   bs.CalculateBinarySimplexMethod(functionFx,limits,freeMembers);

            Fraction first = new Fraction(-3, 2);
            Fraction result = first.GetFloatPart();


            Console.ReadKey();
        }
    }
}