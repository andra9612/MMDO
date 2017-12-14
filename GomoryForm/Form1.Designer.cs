namespace GomoryForm
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.variablesCount = new System.Windows.Forms.NumericUpDown();
            this.limitsCount = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.countOfInteger = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.variablesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.limitsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countOfInteger)).BeginInit();
            this.SuspendLayout();
            // 
            // variablesCount
            // 
            this.variablesCount.Location = new System.Drawing.Point(84, 12);
            this.variablesCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.variablesCount.Name = "variablesCount";
            this.variablesCount.Size = new System.Drawing.Size(40, 20);
            this.variablesCount.TabIndex = 0;
            this.variablesCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // limitsCount
            // 
            this.limitsCount.Location = new System.Drawing.Point(130, 12);
            this.limitsCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.limitsCount.Name = "limitsCount";
            this.limitsCount.Size = new System.Drawing.Size(40, 20);
            this.limitsCount.TabIndex = 1;
            this.limitsCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "Згенерувати";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(270, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 20);
            this.button2.TabIndex = 3;
            this.button2.Text = "Прийняти";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // countOfInteger
            // 
            this.countOfInteger.Location = new System.Drawing.Point(351, 12);
            this.countOfInteger.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.countOfInteger.Name = "countOfInteger";
            this.countOfInteger.Size = new System.Drawing.Size(50, 20);
            this.countOfInteger.TabIndex = 4;
            this.countOfInteger.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 366);
            this.Controls.Add(this.countOfInteger);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.limitsCount);
            this.Controls.Add(this.variablesCount);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.variablesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.limitsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countOfInteger)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown variablesCount;
        private System.Windows.Forms.NumericUpDown limitsCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown countOfInteger;
    }
}

