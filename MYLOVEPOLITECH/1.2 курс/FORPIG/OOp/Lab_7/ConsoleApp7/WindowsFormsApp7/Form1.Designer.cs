
namespace WindowsFormsApp7
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.shirina = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.visota = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxMaterial = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.odnokamerni = new System.Windows.Forms.RadioButton();
            this.dvokamerni = new System.Windows.Forms.RadioButton();
            this.pidvikonia = new System.Windows.Forms.CheckBox();
            this.rozrahuvaty = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxVivod = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Розміри вікна";
            // 
            // shirina
            // 
            this.shirina.Location = new System.Drawing.Point(113, 41);
            this.shirina.Name = "shirina";
            this.shirina.Size = new System.Drawing.Size(125, 27);
            this.shirina.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Висота(см)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ширина(см)";
            // 
            // visota
            // 
            this.visota.Location = new System.Drawing.Point(113, 75);
            this.visota.Name = "visota";
            this.visota.Size = new System.Drawing.Size(125, 27);
            this.visota.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Матеріал";
            // 
            // comboBoxMaterial
            // 
            this.comboBoxMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMaterial.FormattingEnabled = true;
            this.comboBoxMaterial.Items.AddRange(new object[] {
            "Дерево",
            "Метал",
            "Металопластик"});
            this.comboBoxMaterial.Location = new System.Drawing.Point(113, 117);
            this.comboBoxMaterial.Name = "comboBoxMaterial";
            this.comboBoxMaterial.Size = new System.Drawing.Size(125, 28);
            this.comboBoxMaterial.TabIndex = 6;
            this.comboBoxMaterial.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(304, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 28);
            this.label5.TabIndex = 7;
            this.label5.Text = "Склопакет";
            // 
            // odnokamerni
            // 
            this.odnokamerni.AutoSize = true;
            this.odnokamerni.Checked = true;
            this.odnokamerni.Location = new System.Drawing.Point(300, 44);
            this.odnokamerni.Name = "odnokamerni";
            this.odnokamerni.Size = new System.Drawing.Size(137, 24);
            this.odnokamerni.TabIndex = 8;
            this.odnokamerni.TabStop = true;
            this.odnokamerni.Text = "Однокамерний";
            this.odnokamerni.UseVisualStyleBackColor = true;
            // 
            // dvokamerni
            // 
            this.dvokamerni.AutoSize = true;
            this.dvokamerni.Location = new System.Drawing.Point(300, 71);
            this.dvokamerni.Name = "dvokamerni";
            this.dvokamerni.Size = new System.Drawing.Size(127, 24);
            this.dvokamerni.TabIndex = 9;
            this.dvokamerni.Text = "Двокамерний";
            this.dvokamerni.UseVisualStyleBackColor = true;
            // 
            // pidvikonia
            // 
            this.pidvikonia.AutoSize = true;
            this.pidvikonia.Location = new System.Drawing.Point(300, 109);
            this.pidvikonia.Name = "pidvikonia";
            this.pidvikonia.Size = new System.Drawing.Size(108, 24);
            this.pidvikonia.TabIndex = 10;
            this.pidvikonia.Text = "Підвіконня";
            this.pidvikonia.UseVisualStyleBackColor = true;
            // 
            // rozrahuvaty
            // 
            this.rozrahuvaty.Location = new System.Drawing.Point(300, 166);
            this.rozrahuvaty.Name = "rozrahuvaty";
            this.rozrahuvaty.Size = new System.Drawing.Size(162, 35);
            this.rozrahuvaty.TabIndex = 11;
            this.rozrahuvaty.Text = "Розрахувати";
            this.rozrahuvaty.UseVisualStyleBackColor = true;
            this.rozrahuvaty.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(13, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Вартість:";
            // 
            // textBoxVivod
            // 
            this.textBoxVivod.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBoxVivod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxVivod.ForeColor = System.Drawing.Color.Red;
            this.textBoxVivod.Location = new System.Drawing.Point(113, 167);
            this.textBoxVivod.Name = "textBoxVivod";
            this.textBoxVivod.Size = new System.Drawing.Size(125, 20);
            this.textBoxVivod.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(474, 213);
            this.Controls.Add(this.textBoxVivod);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rozrahuvaty);
            this.Controls.Add(this.pidvikonia);
            this.Controls.Add(this.dvokamerni);
            this.Controls.Add(this.odnokamerni);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxMaterial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.visota);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shirina);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(492, 260);
            this.MinimumSize = new System.Drawing.Size(492, 260);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox shirina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox visota;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxMaterial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton odnokamerni;
        private System.Windows.Forms.RadioButton dvokamerni;
        private System.Windows.Forms.CheckBox pidvikonia;
        private System.Windows.Forms.Button rozrahuvaty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxVivod;
    }
}

