using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    public class Archive
    {
		public static void ArchiveFile(string[] sourceFile, int count)
		{
			string archiveDirection = Path.GetFullPath(sourceFile[0]);
			string tempFolderDirection = Path.GetDirectoryName(sourceFile[0]) + "\\ForArchive";
			Directory.CreateDirectory(tempFolderDirection);
			for (int i = 0; i < count; i++)
			{
				try
				{
					File.Copy(sourceFile[i], tempFolderDirection + "\\" + Path.GetFileName(sourceFile[i]), true);
				}
				catch
				{
					MessageBox.Show("Error");
				}
			}
			ZipFile.CreateFromDirectory(tempFolderDirection, archiveDirection + ".gzar");
			Directory.Delete(tempFolderDirection, true);
		}

		public static void Unzip(string[] sourceFile, int count)
		{
			for (int i = 0; i < count; i++)
			{
				string archDirectory = Path.GetFullPath(sourceFile[i]);
				string startDirectory = Path.GetDirectoryName(sourceFile[i]);
				Directory.CreateDirectory(startDirectory);
				try
				{
					ZipFile.ExtractToDirectory(archDirectory, startDirectory);
				}
				catch
				{
					MessageBox.Show("Error");
				}
			}
		}
	}
}
