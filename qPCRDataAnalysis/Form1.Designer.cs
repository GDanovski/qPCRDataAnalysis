namespace qPCRDataAnalysis
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Export = new System.Windows.Forms.Button();
            this.button_switchXY = new System.Windows.Forms.Button();
            this.button_Process = new System.Windows.Forms.Button();
            this.button_Load = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_Gene2 = new System.Windows.Forms.ComboBox();
            this.comboBox_Condition2 = new System.Windows.Forms.ComboBox();
            this.comboBox_TimePoint2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_Gene1 = new System.Windows.Forms.ComboBox();
            this.comboBox_Condition1 = new System.Windows.Forms.ComboBox();
            this.comboBox_TimePoint1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.button_DeleteColumn = new System.Windows.Forms.Button();
            this.button_deleteRow = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_deleteRow);
            this.panel1.Controls.Add(this.button_DeleteColumn);
            this.panel1.Controls.Add(this.button_Export);
            this.panel1.Controls.Add(this.button_switchXY);
            this.panel1.Controls.Add(this.button_Process);
            this.panel1.Controls.Add(this.button_Load);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 450);
            this.panel1.TabIndex = 0;
            // 
            // button_Export
            // 
            this.button_Export.Location = new System.Drawing.Point(236, 290);
            this.button_Export.Name = "button_Export";
            this.button_Export.Size = new System.Drawing.Size(88, 23);
            this.button_Export.TabIndex = 5;
            this.button_Export.Text = "Export";
            this.button_Export.UseVisualStyleBackColor = true;
            this.button_Export.Click += new System.EventHandler(this.button_Export_Click);
            // 
            // button_switchXY
            // 
            this.button_switchXY.Location = new System.Drawing.Point(50, 319);
            this.button_switchXY.Name = "button_switchXY";
            this.button_switchXY.Size = new System.Drawing.Size(87, 23);
            this.button_switchXY.TabIndex = 4;
            this.button_switchXY.Text = "switchXY";
            this.button_switchXY.UseVisualStyleBackColor = true;
            this.button_switchXY.Click += new System.EventHandler(this.button_switchXY_Click);
            // 
            // button_Process
            // 
            this.button_Process.Location = new System.Drawing.Point(143, 290);
            this.button_Process.Name = "button_Process";
            this.button_Process.Size = new System.Drawing.Size(87, 23);
            this.button_Process.TabIndex = 3;
            this.button_Process.Text = "Process";
            this.button_Process.UseVisualStyleBackColor = true;
            this.button_Process.Click += new System.EventHandler(this.button_Process_Click);
            // 
            // button_Load
            // 
            this.button_Load.Location = new System.Drawing.Point(49, 290);
            this.button_Load.Name = "button_Load";
            this.button_Load.Size = new System.Drawing.Size(88, 23);
            this.button_Load.TabIndex = 2;
            this.button_Load.Text = "Load";
            this.button_Load.UseVisualStyleBackColor = true;
            this.button_Load.Click += new System.EventHandler(this.button_Load_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_Gene2);
            this.groupBox2.Controls.Add(this.comboBox_Condition2);
            this.groupBox2.Controls.Add(this.comboBox_TimePoint2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(353, 120);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reference:";
            // 
            // comboBox_Gene2
            // 
            this.comboBox_Gene2.FormattingEnabled = true;
            this.comboBox_Gene2.Location = new System.Drawing.Point(85, 79);
            this.comboBox_Gene2.Name = "comboBox_Gene2";
            this.comboBox_Gene2.Size = new System.Drawing.Size(262, 21);
            this.comboBox_Gene2.TabIndex = 6;
            // 
            // comboBox_Condition2
            // 
            this.comboBox_Condition2.FormattingEnabled = true;
            this.comboBox_Condition2.Location = new System.Drawing.Point(85, 52);
            this.comboBox_Condition2.Name = "comboBox_Condition2";
            this.comboBox_Condition2.Size = new System.Drawing.Size(262, 21);
            this.comboBox_Condition2.TabIndex = 5;
            // 
            // comboBox_TimePoint2
            // 
            this.comboBox_TimePoint2.FormattingEnabled = true;
            this.comboBox_TimePoint2.Location = new System.Drawing.Point(85, 25);
            this.comboBox_TimePoint2.Name = "comboBox_TimePoint2";
            this.comboBox_TimePoint2.Size = new System.Drawing.Size(262, 21);
            this.comboBox_TimePoint2.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Gene:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Condition:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Time Point:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_Gene1);
            this.groupBox1.Controls.Add(this.comboBox_Condition1);
            this.groupBox1.Controls.Add(this.comboBox_TimePoint1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 118);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters:";
            // 
            // comboBox_Gene1
            // 
            this.comboBox_Gene1.FormattingEnabled = true;
            this.comboBox_Gene1.Location = new System.Drawing.Point(85, 82);
            this.comboBox_Gene1.Name = "comboBox_Gene1";
            this.comboBox_Gene1.Size = new System.Drawing.Size(262, 21);
            this.comboBox_Gene1.TabIndex = 5;
            // 
            // comboBox_Condition1
            // 
            this.comboBox_Condition1.FormattingEnabled = true;
            this.comboBox_Condition1.Location = new System.Drawing.Point(85, 55);
            this.comboBox_Condition1.Name = "comboBox_Condition1";
            this.comboBox_Condition1.Size = new System.Drawing.Size(262, 21);
            this.comboBox_Condition1.TabIndex = 4;
            // 
            // comboBox_TimePoint1
            // 
            this.comboBox_TimePoint1.FormattingEnabled = true;
            this.comboBox_TimePoint1.Location = new System.Drawing.Point(85, 28);
            this.comboBox_TimePoint1.Name = "comboBox_TimePoint1";
            this.comboBox_TimePoint1.Size = new System.Drawing.Size(262, 21);
            this.comboBox_TimePoint1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gene:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Condition:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time Point:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(384, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(614, 212);
            this.panel2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(610, 170);
            this.dataGridView1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(610, 38);
            this.panel3.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(14, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Results table:";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.dataGridView2);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(384, 212);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(614, 238);
            this.panel4.TabIndex = 3;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 38);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(610, 196);
            this.dataGridView2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel5.Controls.Add(this.label8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(610, 38);
            this.panel5.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(14, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "StDev.S table:";
            // 
            // button_DeleteColumn
            // 
            this.button_DeleteColumn.Location = new System.Drawing.Point(143, 319);
            this.button_DeleteColumn.Name = "button_DeleteColumn";
            this.button_DeleteColumn.Size = new System.Drawing.Size(88, 23);
            this.button_DeleteColumn.TabIndex = 6;
            this.button_DeleteColumn.Text = "Delete Column";
            this.button_DeleteColumn.UseVisualStyleBackColor = true;
            this.button_DeleteColumn.Click += new System.EventHandler(this.button_DeleteColumn_Click);
            // 
            // button_deleteRow
            // 
            this.button_deleteRow.Location = new System.Drawing.Point(236, 319);
            this.button_deleteRow.Name = "button_deleteRow";
            this.button_deleteRow.Size = new System.Drawing.Size(88, 23);
            this.button_deleteRow.TabIndex = 7;
            this.button_deleteRow.Text = "Delete Row";
            this.button_deleteRow.UseVisualStyleBackColor = true;
            this.button_deleteRow.Click += new System.EventHandler(this.button_deleteRow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 450);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(1014, 489);
            this.Name = "Form1";
            this.Text = "qPCRDataAnalysis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Gene2;
        private System.Windows.Forms.ComboBox comboBox_Condition2;
        private System.Windows.Forms.ComboBox comboBox_TimePoint2;
        private System.Windows.Forms.ComboBox comboBox_Gene1;
        private System.Windows.Forms.ComboBox comboBox_Condition1;
        private System.Windows.Forms.ComboBox comboBox_TimePoint1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_Load;
        private System.Windows.Forms.Button button_Process;
        private System.Windows.Forms.Button button_switchXY;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_Export;
        private System.Windows.Forms.Button button_DeleteColumn;
        private System.Windows.Forms.Button button_deleteRow;
    }
}

