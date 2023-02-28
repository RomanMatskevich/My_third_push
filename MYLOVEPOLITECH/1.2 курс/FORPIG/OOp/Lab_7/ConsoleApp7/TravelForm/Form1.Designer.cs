
namespace TravelForm
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
            this.textBoxVivod = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rozrahuvaty = new System.Windows.Forms.Button();
            this.guide = new System.Windows.Forms.CheckBox();
            this.winter = new System.Windows.Forms.RadioButton();
            this.summer = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxCountry = new System.Windows.Forms.ComboBox();
            this.country = new System.Windows.Forms.Label();
            this.days = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tourists = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxVivod
            // 
            this.textBoxVivod.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBoxVivod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxVivod.ForeColor = System.Drawing.Color.Red;
            this.textBoxVivod.Location = new System.Drawing.Point(145, 145);
            this.textBoxVivod.Name = "textBoxVivod";
            this.textBoxVivod.Size = new System.Drawing.Size(108, 20);
            this.textBoxVivod.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(12, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 25);
            this.label6.TabIndex = 26;
            this.label6.Text = "Вартість:";
            // 
            // rozrahuvaty
            // 
            this.rozrahuvaty.Location = new System.Drawing.Point(279, 145);
            this.rozrahuvaty.Name = "rozrahuvaty";
            this.rozrahuvaty.Size = new System.Drawing.Size(162, 35);
            this.rozrahuvaty.TabIndex = 25;
            this.rozrahuvaty.Text = "Розрахувати";
            this.rozrahuvaty.UseVisualStyleBackColor = true;
            this.rozrahuvaty.Click += new System.EventHandler(this.rozrahuvaty_Click);
            // 
            // guide
            // 
            this.guide.AutoSize = true;
            this.guide.Location = new System.Drawing.Point(303, 115);
            this.guide.Name = "guide";
            this.guide.Size = new System.Drawing.Size(144, 24);
            this.guide.TabIndex = 24;
            this.guide.Text = "Туристичний Гід";
            this.guide.UseVisualStyleBackColor = true;
            // 
            // winter
            // 
            this.winter.AutoSize = true;
            this.winter.Location = new System.Drawing.Point(303, 78);
            this.winter.Name = "winter";
            this.winter.Size = new System.Drawing.Size(66, 24);
            this.winter.TabIndex = 23;
            this.winter.Text = "Зима";
            this.winter.UseVisualStyleBackColor = true;
            // 
            // summer
            // 
            this.summer.AutoSize = true;
            this.summer.Checked = true;
            this.summer.Location = new System.Drawing.Point(304, 48);
            this.summer.Name = "summer";
            this.summer.Size = new System.Drawing.Size(59, 24);
            this.summer.TabIndex = 22;
            this.summer.TabStop = true;
            this.summer.Text = "Літо";
            this.summer.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(303, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 28);
            this.label5.TabIndex = 21;
            this.label5.Text = "Пора Року";
            // 
            // comboBoxCountry
            // 
            this.comboBoxCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCountry.FormattingEnabled = true;
            this.comboBoxCountry.Items.AddRange(new object[] {
            "Болгарія",
            "Німеччина",
            "Польща"});
            this.comboBoxCountry.Location = new System.Drawing.Point(145, 93);
            this.comboBoxCountry.Name = "comboBoxCountry";
            this.comboBoxCountry.Size = new System.Drawing.Size(125, 28);
            this.comboBoxCountry.TabIndex = 20;
            // 
            // country
            // 
            this.country.AutoSize = true;
            this.country.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.country.Location = new System.Drawing.Point(12, 93);
            this.country.Name = "country";
            this.country.Size = new System.Drawing.Size(76, 25);
            this.country.TabIndex = 19;
            this.country.Text = "Країіна";
            // 
            // days
            // 
            this.days.AutoSize = true;
            this.days.Location = new System.Drawing.Point(12, 20);
            this.days.Name = "days";
            this.days.Size = new System.Drawing.Size(103, 20);
            this.days.TabIndex = 28;
            this.days.Text = "Кількість днів";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(145, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 27);
            this.textBox1.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Кількість туристів";
            // 
            // tourists
            // 
            this.tourists.Location = new System.Drawing.Point(145, 52);
            this.tourists.Name = "tourists";
            this.tourists.Size = new System.Drawing.Size(125, 27);
            this.tourists.TabIndex = 31;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(451, 187);
            this.Controls.Add(this.tourists);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.days);
            this.Controls.Add(this.textBoxVivod);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rozrahuvaty);
            this.Controls.Add(this.guide);
            this.Controls.Add(this.winter);
            this.Controls.Add(this.summer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxCountry);
            this.Controls.Add(this.country);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxVivod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button rozrahuvaty;
        private System.Windows.Forms.CheckBox guide;
        private System.Windows.Forms.RadioButton winter;
        private System.Windows.Forms.RadioButton summer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxCountry;
        private System.Windows.Forms.Label country;
        private System.Windows.Forms.Label days;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tourists;
    }
}

