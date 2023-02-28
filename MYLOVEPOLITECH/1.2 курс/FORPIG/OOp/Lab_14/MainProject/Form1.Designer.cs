namespace MainProject
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
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.діяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnzipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EncryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DecryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.ListBoxFiles = new System.Windows.Forms.ListBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelSuccess = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddFile.Location = new System.Drawing.Point(16, 33);
            this.buttonAddFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(167, 60);
            this.buttonAddFile.TabIndex = 0;
            this.buttonAddFile.Text = "Додати";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelete.Location = new System.Drawing.Point(16, 126);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(167, 60);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "Видалити";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.діяToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1067, 28);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip1";
            // 
            // діяToolStripMenuItem
            // 
            this.діяToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ArchiveToolStripMenuItem,
            this.UnzipToolStripMenuItem,
            this.EncryptToolStripMenuItem,
            this.DecryptToolStripMenuItem});
            this.діяToolStripMenuItem.Name = "діяToolStripMenuItem";
            this.діяToolStripMenuItem.Size = new System.Drawing.Size(45, 24);
            this.діяToolStripMenuItem.Text = "Дія";
            // 
            // ArchiveToolStripMenuItem
            // 
            this.ArchiveToolStripMenuItem.Name = "ArchiveToolStripMenuItem";
            this.ArchiveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ArchiveToolStripMenuItem.Text = "Архівувати";
            this.ArchiveToolStripMenuItem.Click += new System.EventHandler(this.ArchiveToolStripMenuItem_Click);
            // 
            // UnzipToolStripMenuItem
            // 
            this.UnzipToolStripMenuItem.Name = "UnzipToolStripMenuItem";
            this.UnzipToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.UnzipToolStripMenuItem.Text = "Розархівувати";
            this.UnzipToolStripMenuItem.Click += new System.EventHandler(this.UnzipToolStripMenuItem_Click);
            // 
            // EncryptToolStripMenuItem
            // 
            this.EncryptToolStripMenuItem.Name = "EncryptToolStripMenuItem";
            this.EncryptToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.EncryptToolStripMenuItem.Text = "Зашифрувати";
            this.EncryptToolStripMenuItem.Click += new System.EventHandler(this.EncryptToolStripMenuItem_Click);
            // 
            // DecryptToolStripMenuItem
            // 
            this.DecryptToolStripMenuItem.Name = "DecryptToolStripMenuItem";
            this.DecryptToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.DecryptToolStripMenuItem.Text = "Розшифрувати";
            this.DecryptToolStripMenuItem.Click += new System.EventHandler(this.DecryptToolStripMenuItem_Click);
            // 
            // buttonExecute
            // 
            this.buttonExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExecute.Location = new System.Drawing.Point(16, 479);
            this.buttonExecute.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(167, 60);
            this.buttonExecute.TabIndex = 3;
            this.buttonExecute.Text = "Виконати";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // ListBoxFiles
            // 
            this.ListBoxFiles.AllowDrop = true;
            this.ListBoxFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListBoxFiles.FormattingEnabled = true;
            this.ListBoxFiles.ItemHeight = 29;
            this.ListBoxFiles.Location = new System.Drawing.Point(191, 30);
            this.ListBoxFiles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ListBoxFiles.Name = "ListBoxFiles";
            this.ListBoxFiles.Size = new System.Drawing.Size(875, 526);
            this.ListBoxFiles.TabIndex = 4;
            this.ListBoxFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBoxFiles_DragDrop);
            this.ListBoxFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBoxFiles_DragEnter);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBoxPassword.Location = new System.Drawing.Point(16, 258);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(165, 23);
            this.textBoxPassword.TabIndex = 5;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassword.Location = new System.Drawing.Point(36, 225);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(105, 29);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Пароль:";
            // 
            // labelSuccess
            // 
            this.labelSuccess.AutoSize = true;
            this.labelSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSuccess.ForeColor = System.Drawing.Color.Green;
            this.labelSuccess.Location = new System.Drawing.Point(16, 348);
            this.labelSuccess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSuccess.Name = "labelSuccess";
            this.labelSuccess.Size = new System.Drawing.Size(136, 39);
            this.labelSuccess.TabIndex = 7;
            this.labelSuccess.Text = "Готово!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.labelSuccess);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.ListBoxFiles);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAddFile);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem діяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UnzipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EncryptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DecryptToolStripMenuItem;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.ListBox ListBoxFiles;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelSuccess;
    }
}

