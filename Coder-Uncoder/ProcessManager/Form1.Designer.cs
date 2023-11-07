namespace ProcessManager
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
            this.PowerPointBTN = new System.Windows.Forms.Button();
            this.ExcelBTN = new System.Windows.Forms.Button();
            this.WordBTN = new System.Windows.Forms.Button();
            this.ConductorBTN = new System.Windows.Forms.Button();
            this.CalculatorBTN = new System.Windows.Forms.Button();
            this.NotebookBTN = new System.Windows.Forms.Button();
            this.PrioretetProsBTN = new System.Windows.Forms.Button();
            this.StopProsBTN = new System.Windows.Forms.Button();
            this.dataGridViewProcesses = new System.Windows.Forms.DataGridView();
            this.comboBoxPros = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcesses)).BeginInit();
            this.SuspendLayout();
            // 
            // PowerPointBTN
            // 
            this.PowerPointBTN.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PowerPointBTN.Location = new System.Drawing.Point(615, 132);
            this.PowerPointBTN.Name = "PowerPointBTN";
            this.PowerPointBTN.Size = new System.Drawing.Size(137, 31);
            this.PowerPointBTN.TabIndex = 8;
            this.PowerPointBTN.Text = "M.PowerPoint";
            this.PowerPointBTN.UseVisualStyleBackColor = true;
            this.PowerPointBTN.Click += new System.EventHandler(this.PowerPointBTN_Click);
            // 
            // ExcelBTN
            // 
            this.ExcelBTN.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExcelBTN.Location = new System.Drawing.Point(615, 40);
            this.ExcelBTN.Name = "ExcelBTN";
            this.ExcelBTN.Size = new System.Drawing.Size(137, 31);
            this.ExcelBTN.TabIndex = 7;
            this.ExcelBTN.Text = "M.Excel";
            this.ExcelBTN.UseVisualStyleBackColor = true;
            this.ExcelBTN.Click += new System.EventHandler(this.ExcelBTN_Click);
            // 
            // WordBTN
            // 
            this.WordBTN.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WordBTN.Location = new System.Drawing.Point(615, 85);
            this.WordBTN.Name = "WordBTN";
            this.WordBTN.Size = new System.Drawing.Size(137, 31);
            this.WordBTN.TabIndex = 6;
            this.WordBTN.Text = "M.Word";
            this.WordBTN.UseVisualStyleBackColor = true;
            this.WordBTN.Click += new System.EventHandler(this.WordBTN_Click);
            // 
            // ConductorBTN
            // 
            this.ConductorBTN.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConductorBTN.Location = new System.Drawing.Point(768, 40);
            this.ConductorBTN.Name = "ConductorBTN";
            this.ConductorBTN.Size = new System.Drawing.Size(137, 31);
            this.ConductorBTN.TabIndex = 5;
            this.ConductorBTN.Text = "Провідник";
            this.ConductorBTN.UseVisualStyleBackColor = true;
            this.ConductorBTN.Click += new System.EventHandler(this.ConductorBTN_Click);
            // 
            // CalculatorBTN
            // 
            this.CalculatorBTN.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CalculatorBTN.Location = new System.Drawing.Point(768, 132);
            this.CalculatorBTN.Name = "CalculatorBTN";
            this.CalculatorBTN.Size = new System.Drawing.Size(137, 31);
            this.CalculatorBTN.TabIndex = 4;
            this.CalculatorBTN.Text = "Калькулятор";
            this.CalculatorBTN.UseVisualStyleBackColor = true;
            this.CalculatorBTN.Click += new System.EventHandler(this.CalculatorBTN_Click);
            // 
            // NotebookBTN
            // 
            this.NotebookBTN.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NotebookBTN.Location = new System.Drawing.Point(768, 85);
            this.NotebookBTN.Name = "NotebookBTN";
            this.NotebookBTN.Size = new System.Drawing.Size(137, 31);
            this.NotebookBTN.TabIndex = 3;
            this.NotebookBTN.Text = "Блокнот";
            this.NotebookBTN.UseVisualStyleBackColor = true;
            this.NotebookBTN.Click += new System.EventHandler(this.NotebookBTN_Click);
            // 
            // PrioretetProsBTN
            // 
            this.PrioretetProsBTN.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PrioretetProsBTN.Location = new System.Drawing.Point(679, 253);
            this.PrioretetProsBTN.Name = "PrioretetProsBTN";
            this.PrioretetProsBTN.Size = new System.Drawing.Size(186, 31);
            this.PrioretetProsBTN.TabIndex = 6;
            this.PrioretetProsBTN.Text = "Змінити пріоретет";
            this.PrioretetProsBTN.UseVisualStyleBackColor = true;
            // 
            // StopProsBTN
            // 
            this.StopProsBTN.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StopProsBTN.Location = new System.Drawing.Point(12, 253);
            this.StopProsBTN.Name = "StopProsBTN";
            this.StopProsBTN.Size = new System.Drawing.Size(204, 31);
            this.StopProsBTN.TabIndex = 4;
            this.StopProsBTN.Text = "Зупинка процесу";
            this.StopProsBTN.UseVisualStyleBackColor = true;
            // 
            // dataGridViewProcesses
            // 
            this.dataGridViewProcesses.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridViewProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProcesses.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewProcesses.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewProcesses.Name = "dataGridViewProcesses";
            this.dataGridViewProcesses.Size = new System.Drawing.Size(597, 225);
            this.dataGridViewProcesses.TabIndex = 0;
            // 
            // comboBoxPros
            // 
            this.comboBoxPros.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxPros.FormattingEnabled = true;
            this.comboBoxPros.Items.AddRange(new object[] {
            "0",
            "8",
            "16",
            "24",
            "32"});
            this.comboBoxPros.Location = new System.Drawing.Point(694, 208);
            this.comboBoxPros.Name = "comboBoxPros";
            this.comboBoxPros.Size = new System.Drawing.Size(156, 29);
            this.comboBoxPros.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(915, 288);
            this.Controls.Add(this.comboBoxPros);
            this.Controls.Add(this.PrioretetProsBTN);
            this.Controls.Add(this.PowerPointBTN);
            this.Controls.Add(this.StopProsBTN);
            this.Controls.Add(this.ExcelBTN);
            this.Controls.Add(this.dataGridViewProcesses);
            this.Controls.Add(this.WordBTN);
            this.Controls.Add(this.NotebookBTN);
            this.Controls.Add(this.ConductorBTN);
            this.Controls.Add(this.CalculatorBTN);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Менеджер процесів";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcesses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button NotebookBTN;
        private System.Windows.Forms.Button PowerPointBTN;
        private System.Windows.Forms.Button ExcelBTN;
        private System.Windows.Forms.Button WordBTN;
        private System.Windows.Forms.Button ConductorBTN;
        private System.Windows.Forms.Button CalculatorBTN;
        private System.Windows.Forms.DataGridView dataGridViewProcesses;
        private System.Windows.Forms.Button PrioretetProsBTN;
        private System.Windows.Forms.Button StopProsBTN;
        private System.Windows.Forms.ComboBox comboBoxPros;
    }
}

