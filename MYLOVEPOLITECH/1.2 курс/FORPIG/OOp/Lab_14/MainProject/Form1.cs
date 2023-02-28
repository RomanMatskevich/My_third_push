using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProject
{
    public partial class Form1 : Form
    {
        private int ChosenMode;
        public Form1()
        {
            InitializeComponent();
        }

        private void AddPath(string path)
        {
            if (ListBoxFiles.Items.IndexOf(path) == -1)
            {
                ListBoxFiles.Items.Add(path);
            }
        }

        private void AddPaths(params string[] path)
        {
            foreach (string str in path)
            {
                AddPath(str);
            }
        }

        private void UnzipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelPassword.Visible = false;
            textBoxPassword.Visible = false;
            if (ListBoxFiles.Items.Count != 0)
            {
                ChosenMode = 2;
            }
        }

        private void ArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelPassword.Visible = false;
            textBoxPassword.Visible = false;
            labelSuccess.Visible = false;
            if (ListBoxFiles.Items.Count != 0)
            {
                ChosenMode = 1;
            }
        }

        private void DecryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelPassword.Visible = true;
            textBoxPassword.Visible = true;
            labelSuccess.Visible = false;
            if (ListBoxFiles.Items.Count != 0)
            {
                ChosenMode = 4;
            }
        }

        private void EncryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelPassword.Visible = true;
            textBoxPassword.Visible = true;
            labelSuccess.Visible = false;
            if (ListBoxFiles.Items.Count != 0)
            {
                ChosenMode = 3;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelPassword.Visible = false;
            textBoxPassword.Visible = false;
            labelSuccess.Visible = false;
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            DialogResult dialogResult = fileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                foreach (string file in fileDialog.FileNames)
                {
                    AddPath(file);
                }
            }
            labelSuccess.Visible = false;
            labelPassword.Visible = false;
            textBoxPassword.Visible = false;
        }

        private void ListBoxFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (Directory.Exists(file))//или есть
                {
                    AddPaths(Directory.GetFiles(file));
                }
                else
                {
                    AddPath(file);
                }
            }
        }

        private void ListBoxFiles_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ListBoxFiles.Items.Clear();
            labelSuccess.Visible = false;
            labelPassword.Visible = false;
            textBoxPassword.Visible = false;
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            try
            {
                string password = textBoxPassword.Text;
                string[] sourceFile = new string[ListBoxFiles.Items.Count];
                byte[] sourceFileByte = File.ReadAllBytes((string)ListBoxFiles.Items[0]);
                switch (ChosenMode)
                {
                    case 1:
                        for (int i = 0; i < ListBoxFiles.Items.Count; i++)
                        {
                            sourceFile[i] = (string)ListBoxFiles.Items[i];
                        }
                        Archive.ArchiveFile(sourceFile, ListBoxFiles.Items.Count);
                        ListBoxFiles.Items.Clear();
                        break;
                    case 2:
                        for (int i = 0; i < ListBoxFiles.Items.Count; i++)
                        {
                            sourceFile[i] = (string)ListBoxFiles.Items[i];
                            Archive.Unzip(sourceFile, ListBoxFiles.Items.Count);
                        }
                        ListBoxFiles.Items.Clear();
                        break;
                    case 3:
                        for (int i = 0; i < ListBoxFiles.Items.Count; i++)
                        {
                            string temp = Encrypt.CheckEncrypted((string)ListBoxFiles.Items[i]);
                            if (temp != (string)ListBoxFiles.Items[i])
                            {
                                sourceFileByte = File.ReadAllBytes((string)ListBoxFiles.Items[i]);
                                byte[] enCryptFile = Encrypt.EncryptFile(sourceFileByte, password);
                                string sourceFileName = Encrypt.CheckEncrypted((string)ListBoxFiles.Items[i]);
                                File.WriteAllBytes(sourceFileName, enCryptFile);
                                if (sourceFileName != (string)ListBoxFiles.Items[i])
                                {
                                    File.Delete((string)ListBoxFiles.Items[i]);
                                }
                            }
                        }
                        ListBoxFiles.Items.Clear();
                        break;
                    case 4:
                        for (int i = 0; i < ListBoxFiles.Items.Count; i++)
                        {
                            string tmp = Encrypt.CheckDecrypted((string)ListBoxFiles.Items[i]);
                            if (tmp != (string)ListBoxFiles.Items[i])
                            {
                                sourceFileByte = File.ReadAllBytes((string)ListBoxFiles.Items[i]);
                                byte[] enCryptFile = Encrypt.DecryptFile(sourceFileByte, password);
                                string sourceFileName = Encrypt.CheckDecrypted((string)ListBoxFiles.Items[i]);
                                File.WriteAllBytes(sourceFileName, enCryptFile);
                                if (sourceFileName != (string)ListBoxFiles.Items[i])
                                {
                                    File.Delete((string)ListBoxFiles.Items[i]);
                                }
                            }
                        }
                        ListBoxFiles.Items.Clear();
                        break;
                    default:
                        MessageBox.Show("Не обрано функцію");
                        break;
                }
                labelSuccess.Visible = true;
                labelPassword.Visible = false;
                textBoxPassword.Visible = false;
                textBoxPassword.Text = null;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
