namespace WindowsFormsApp1
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
            this.textBoxConnectionString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxQuery = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonExecuteQuery = new System.Windows.Forms.Button();
            this.buttonReadData = new System.Windows.Forms.Button();
            this.buttonUpdateData = new System.Windows.Forms.Button();
            this.buttonDeleteData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Location = new System.Drawing.Point(12, 67);
            this.textBoxConnectionString.Multiline = true;
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(1226, 28);
            this.textBoxConnectionString.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "ConnecctionString";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(17, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(267, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1060, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Get All Providers";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxQuery
            // 
            this.textBoxQuery.Location = new System.Drawing.Point(12, 131);
            this.textBoxQuery.Multiline = true;
            this.textBoxQuery.Name = "textBoxQuery";
            this.textBoxQuery.Size = new System.Drawing.Size(1042, 22);
            this.textBoxQuery.TabIndex = 4;
            this.textBoxQuery.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(14, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "SQL reqest";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1060, 131);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 22);
            this.button2.TabIndex = 6;
            this.button2.Text = "Execute request";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 171);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1007, 496);
            this.dataGridView1.TabIndex = 7;
            // 
            // buttonExecuteQuery
            // 
            this.buttonExecuteQuery.Location = new System.Drawing.Point(1038, 187);
            this.buttonExecuteQuery.Name = "buttonExecuteQuery";
            this.buttonExecuteQuery.Size = new System.Drawing.Size(200, 23);
            this.buttonExecuteQuery.TabIndex = 8;
            this.buttonExecuteQuery.Text = "ExecuteQuery";
            this.buttonExecuteQuery.UseVisualStyleBackColor = true;
            this.buttonExecuteQuery.Click += new System.EventHandler(this.buttonExecuteQuery_Click);
            // 
            // buttonReadData
            // 
            this.buttonReadData.Location = new System.Drawing.Point(1038, 216);
            this.buttonReadData.Name = "buttonReadData";
            this.buttonReadData.Size = new System.Drawing.Size(200, 23);
            this.buttonReadData.TabIndex = 9;
            this.buttonReadData.Text = "ReadData";
            this.buttonReadData.UseVisualStyleBackColor = true;
            this.buttonReadData.Click += new System.EventHandler(this.buttonReadData_Click);
            // 
            // buttonUpdateData
            // 
            this.buttonUpdateData.Location = new System.Drawing.Point(1038, 246);
            this.buttonUpdateData.Name = "buttonUpdateData";
            this.buttonUpdateData.Size = new System.Drawing.Size(200, 23);
            this.buttonUpdateData.TabIndex = 10;
            this.buttonUpdateData.Text = "UpdateData";
            this.buttonUpdateData.UseVisualStyleBackColor = true;
            this.buttonUpdateData.Click += new System.EventHandler(this.buttonUpdateData_Click);
            // 
            // buttonDeleteData
            // 
            this.buttonDeleteData.Location = new System.Drawing.Point(1038, 275);
            this.buttonDeleteData.Name = "buttonDeleteData";
            this.buttonDeleteData.Size = new System.Drawing.Size(200, 23);
            this.buttonDeleteData.TabIndex = 11;
            this.buttonDeleteData.Text = "DeleteData";
            this.buttonDeleteData.UseVisualStyleBackColor = true;
            this.buttonDeleteData.Click += new System.EventHandler(this.buttonDeleteData_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 679);
            this.Controls.Add(this.buttonDeleteData);
            this.Controls.Add(this.buttonUpdateData);
            this.Controls.Add(this.buttonReadData);
            this.Controls.Add(this.buttonExecuteQuery);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxQuery);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxConnectionString);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxConnectionString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonExecuteQuery;
        private System.Windows.Forms.Button buttonReadData;
        private System.Windows.Forms.Button buttonUpdateData;
        private System.Windows.Forms.Button buttonDeleteData;
    }
}

