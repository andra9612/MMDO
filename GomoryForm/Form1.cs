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
                if (i == FunctionFx.Length-1)
                {
                    Label lable = new Label();
                    lable.Location = new Point((i + 1 )* 60 + 10, 60);
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

            lastPoint = limitBoxes[limitBoxes.GetLength(0)-1, limitBoxes.GetLength(1)-1].Location;

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
            while (Controls.Count > 4)
            {
                foreach (Control x in this.Controls)
                {
                    if (x is TextBox)
                    {
                        x.Dispose();
                    }
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fraction fr = Fraction.zero;

            fr.Parse("13/5");
        }
    }
}
