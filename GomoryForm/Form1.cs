using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SImpleks;

namespace GomoryForm
{
    public partial class Form1 : Form
    {
        int count = 0;
        TextBox[,] limitBoxes;
        TextBox[] freeMembersBoxes;
        TextBox[] FunctionFx;
        FirstGomory gomory = new FirstGomory();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ClearControl();

            limitBoxes = new TextBox[(int)limitsCount.Value, (int)variablesCount.Value];
            freeMembersBoxes = new TextBox[(int)limitsCount.Value];
            FunctionFx = new TextBox[(int)variablesCount.Value];
            Point lastPoint = new Point(0, 0);

            for (int i = 0; i < FunctionFx.Length; i++)
            {
                FunctionFx[i] = new TextBox();
                FunctionFx[i].Location = new Point(i * 60 + 10, 60);
                FunctionFx[i].Size = new Size(50, 20);
                Controls.Add(FunctionFx[i]);
                if (i == FunctionFx.Length - 1)
                {
                    Label lable = new Label();
                    lable.Location = new Point((i + 1) * 60 + 10, 60);
                    lable.Text = "   ----->    min";
                    Controls.Add(lable);
                }
            }



            for (int i = 0; i < limitBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < limitBoxes.GetLength(1); j++)
                {
                    limitBoxes[i, j] = new TextBox();
                    limitBoxes[i, j].Location = new Point(j * 60 + 10, i * 30 + 100);

                    limitBoxes[i, j].Size = new Size(50, 20);
                    Controls.Add(limitBoxes[i, j]);
                }
            }

            lastPoint = limitBoxes[limitBoxes.GetLength(0) - 1, limitBoxes.GetLength(1) - 1].Location;

            for (int i = 0; i < limitBoxes.GetLength(0); i++)
            {
                freeMembersBoxes[i] = new TextBox();
                freeMembersBoxes[i].Location = new Point(lastPoint.X + 80, i * 30 + 100);
                freeMembersBoxes[i].Size = new Size(50, 20);
                Controls.Add(freeMembersBoxes[i]);
            }

        }

        private void ClearControl()
        {
            while (Controls.Count > 5)
            {
                foreach (Control x in this.Controls)
                {
                    if (x is TextBox || x is Label)
                    {
                        x.Dispose();
                    }
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //          Fraction[,] limits =
            //{
            //                                  { (Fraction)4, (Fraction)1, (Fraction)1, (Fraction)0},
            //                                  {(Fraction)(-2), (Fraction)1, (Fraction)0, (Fraction)1}
            //                              };

            //          Fraction[] freeMembers = { (Fraction)6, (Fraction)4 };

            //          Fraction[] functionFx = { (Fraction)(-1), (Fraction)1, (Fraction)0, (Fraction)0 };

            //          FirstGomory gomory = new FirstGomory();


            //            Fraction[,] limits =
            //{
            //                { (Fraction)(-1), (Fraction)3, (Fraction)1, (Fraction)0},
            //                {(Fraction)7, (Fraction)1, (Fraction)0, (Fraction)1}
            //            };

            //            Fraction[] freeMembers = { (Fraction)6, (Fraction)35 };

            //            Fraction[] functionFx = { (Fraction)(-7), (Fraction)(-9), (Fraction)0, (Fraction)0 };

            //            FirstGomory gomory = new FirstGomory();

            // var gom = gomory.CalculateFirstGomory(limits, freeMembers, functionFx, 2);
             var gom = gomory.CalculateFirstGomory(Core.TextBoxParser.TexBoxToLimits(limitBoxes), Core.TextBoxParser.TextBoxToFunctionFx(freeMembersBoxes), Core.TextBoxParser.TextBoxToFunctionFx(FunctionFx), (int)countOfInteger.Value);

            DrawTable(gom.Item1, gom.Item2, gom.Item3, gom.Item4);


        }

        private void DrawTable(Fraction[,] limits, Fraction[] freeMembers, Fraction[] marks, Fraction fx)
        {

            Point lastPoint = new Point(0, 0);

            ClearControl();
            Label[,] limitLables = new Label[limits.GetLength(0), limits.GetLength(1)];
            Label[] freeMemberLable = new Label[freeMembers.Length];
            Label[] markLables = new Label[marks.Length];

            for (int i = 0; i < limitLables.GetLength(0); i++)
            {
                for (int j = 0; j < limitLables.GetLength(1); j++)
                {
                    limitLables[i, j] = new Label();
                    limitLables[i, j].Location = new Point(j * 60 + 10, i * 30 + 100);
                    limitLables[i, j].Size = new Size(50, 20);
                    limitLables[i, j].Text = limits[i, j].Numerator + "/" + limits[i, j].Denumerator;
                    Controls.Add(limitLables[i, j]);
                }
            }

            lastPoint = limitLables[limitLables.GetLength(0) - 1, limitLables.GetLength(1) - 1].Location;

            for (int i = 0; i < limitLables.GetLength(0); i++)
            {
                freeMemberLable[i] = new Label();
                freeMemberLable[i].Location = new Point(lastPoint.X + 80, i * 30 + 100);
                freeMemberLable[i].Size = new Size(50, 20);
                freeMemberLable[i].Text = freeMembers[i].Numerator + "/" + freeMembers[i].Denumerator;
                Controls.Add(freeMemberLable[i]);
            }

            for (int i = 0; i < markLables.Length; i++)
            {
                markLables[i] = new Label();
                markLables[i].Location = new Point(i * 60 + 10, lastPoint.Y + 40);
                markLables[i].Size = new Size(50, 20);
                markLables[i].Text = marks[i].Numerator + "/" + marks[i].Denumerator;
                Controls.Add(markLables[i]);
                if (i == markLables.Length - 1)
                {
                    Label lable = new Label();
                    lable.Location = new Point(lastPoint.X + 75, lastPoint.Y + 40);
                    lable.Text = fx.Numerator + "/" + fx.Denumerator;
                    Controls.Add(lable);
                }
            }

        }


    }
}
