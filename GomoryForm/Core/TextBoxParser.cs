using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SImpleks;
using System.Windows.Forms;
using GomoryForm;

namespace GomoryForm.Core
{
    class TextBoxParser
    {

        public static Fraction[,] TexBoxToLimits(TextBox[,] limitsBox)
        {
            Fraction[,] limits = new Fraction[limitsBox.GetLength(0), limitsBox.GetLength(1)];
            for (int i = 0; i < limits.GetLength(0); i++)
            {
                for (int j = 0; j < limits.GetLength(1); j++)
                {
                    limits[i, j] = new Fraction(limitsBox[i,j].Text);
                }
            }

            return limits;

        }

        public static Fraction[] TextBoxToFunctionFx(TextBox[] functionFxBox)
        {
            Fraction[] functionFx = new Fraction[functionFxBox.Length];

            for (int i = 0; i < functionFx.Length; i++)
            {
                functionFx[i] = new Fraction(functionFxBox[i].Text);
            }

            return functionFx;
        }

    }
}
