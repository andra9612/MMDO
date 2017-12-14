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
        //ініціалізація зміних
        TextBox[,] limitBoxes;
        TextBox[] freeMembersBoxes;
        TextBox[] FunctionFx;
        FirstGomory gomory = new FirstGomory();


        //ініціалізація форми
        public Form1()
        {
            InitializeComponent();
        }


        //обрбник події що відбувається пи натискнні на кнопку генерації форми
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
        //метод що очищує форму
        private void ClearControl()
        {
            while (Controls.Count > 5)
            {
                foreach (Control x in this.Controls)
                {
                    if (x is TextBox || x is Label || x is RichTextBox)
                    {
                        x.Dispose();
                    }
                }

            }

        }

        //обробник події кліку на кнопку яка приймає значення введені в таблицю
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var gom = gomory.CalculateFirstGomory(Core.TextBoxParser.TexBoxToLimits(limitBoxes), Core.TextBoxParser.TextBoxToFunctionFx(freeMembersBoxes), Core.TextBoxParser.TextBoxToFunctionFx(FunctionFx), (int)countOfInteger.Value);

                DrawTable(gom.Item1, gom.Item2, gom.Item3, gom.Item4, gom.Item5);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        //метод генерує  вихідну таблицю.
        private void DrawTable(Fraction[,] limits, Fraction[] freeMembers, Fraction[] marks, Fraction fx, int[] inBasis)
        {
            int counter = 0;
            string end = string.Empty;
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

            //int temp;
            //for (int i = 0; i < inBasis.Length - 1; i++)
            //{
            //    for (int j = i + 1; j < inBasis.Length; j++)
            //    {
            //        if (inBasis[i] > inBasis[j])
            //        {
            //            temp = inBasis[i];
            //            inBasis[i] = inBasis[j];
            //            inBasis[j] = temp;
            //        }
            //    }
            //}

            //for (int i = inBasis.Length-1; i >= 0; i--)
            //{
            //    if(inBasis[i] < (int)countOfInteger.Value)
            //    {
            //        end += "(" + freeMembers[inBasis[i]].Numerator + "/" + freeMembers[inBasis[i]].Denumerator + " ";
            //        counter++;
            //    }

            //}

            int[] arr = new int[inBasis.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                if (inBasis[i] < (int)countOfInteger.Value)
                    arr[i] = i;
                else
                    arr[i] = -1;
            }

            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            for (int i = 0 ; i < inBasis.Length; i++)
            {
                if (arr[i]  != -1)
                {
                    end += "(" + freeMembers[arr[i]].Numerator + "/" + freeMembers[arr[i]].Denumerator + " ";
                    counter++;
                }

            }


            if (counter < (int)countOfInteger.Value)
            {
                for (int i = 0; i < (int)countOfInteger.Value - counter; i++)
                {
                    end += " ; " + 0 + "/" + 0 + " ";
                }
            }

            end += " )" +  " F(x) = " + fx.Numerator + "/" + fx.Denumerator;

            RichTextBox rich = new RichTextBox();
            rich.Location = new Point(10, lastPoint.Y + 70);
            rich.Size = new Size(200, 50);
            rich.Text = end;
            Controls.Add(rich);
           // richTextBox1.Text = end;
            //Label lable1 = new Label();
            //lable1.Location = new Point(lastPoint.X, lastPoint.Y + 70);
            //lable1.Text = end;
            //Controls.Add(lable1);

        }


    }
}
