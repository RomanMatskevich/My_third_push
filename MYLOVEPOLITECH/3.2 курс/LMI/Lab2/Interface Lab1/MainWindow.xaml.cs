using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Interface_Lab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        /// <summary>
        /// Is current editing file was saved
        /// </summary>
        public bool IsSaved = false;

        public double[] FontSizes
        {
            get
            {
                return new double[] { 3.0, 4.0, 5.0, 6.0, 8.0, 
                10.0, 12.0, 14.0, 16.0,  18.0, 
                20.0, 22.0, 24.0, 26.0, 28.0, 30.0,32.0, 34.0, 36.0, 38.0, 40.0, 44.0, 48.0, 52.0, 56.0,
                60.0, 64.0, 68.0, 72.0, 76.0,80.0, 88.0, 96.0, 104.0, 112.0, 120.0, 128.0, 136.0, 144.0
                };
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            _fontSize.ItemsSource = FontSizes;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            btnSave_Click(sender, e);
            doc1.Document.Blocks.Clear();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Document files (*.rtf)|*.rtf";
            var result = dlg.ShowDialog();
            if (result.Value)
            {
                TextRange t = new TextRange(doc1.Document.ContentStart, doc1.Document.ContentEnd);
                FileStream file = new FileStream(dlg.FileName, FileMode.Open);
                t.Load(file, DataFormats.Rtf);
            }
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = "unknown.rtf";
            // set filters - this can be done in properties as well
            savefile.Filter = "Document files (*.rtf)|*.rtf";
            if (savefile.ShowDialog() == true)
            {
                TextRange t = new TextRange(doc1.Document.ContentStart, doc1.Document.ContentEnd);
                this.Title = this.Title + " " + savefile.FileName;
                FileStream file = new FileStream(savefile.FileName, FileMode.Create);
                t.Save(file, System.Windows.DataFormats.Rtf);
                file.Close();
            }
           
            IsSaved = true;
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (IsSaved == false)
                if (MessageBox.Show("Do you want save changes ?", "Message", MessageBoxButton.YesNo) ==
                MessageBoxResult.Yes)
                //Если была нажата кнопка Yes, вызываем метод Save
                {
                    this.btnSave_Click(sender, e);
                }
            this.Close();
        }

        private void rtbInput_Changed(object sender, RoutedEventArgs e)
        {
            tb_cursorPos.Text = ("" + doc1.CaretPosition);
        }



        void ApplyPropertyValueToSelectedText(DependencyProperty formattingProperty, object value)
        {
            if (value == null)
                return;
            doc1.Selection.ApplyPropertyValue(formattingProperty, value);
        }

        private void FontFamili_SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                FontFamily editValue = (FontFamily)e.AddedItems[0];
                ApplyPropertyValueToSelectedText(TextElement.FontFamilyProperty, editValue);
            }
            catch (Exception) { }
        }

        private void FontSize_SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ApplyPropertyValueToSelectedText(TextElement.FontSizeProperty, e.AddedItems[0]);
            }
            catch (Exception) { }
        }

        private void FontColor_SelectionChange(object sender, RoutedEventArgs e)
        {
            try
            {
                if (doc1.Selection.GetPropertyValue(ForegroundProperty).ToString() == "#FF000000")
                {
                    doc1.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, "#FFFF0000");
                    return;
                }
                if (doc1.Selection.GetPropertyValue(ForegroundProperty).ToString() == "#FFFF0000")
                {
                    doc1.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, "#FF000000");
                    return;
                }

                doc1.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, "#FF000000");
            }
            catch (Exception) { }
        }
        
        private void doc1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextPointer tp0 = doc1.CaretPosition.DocumentStart;
            TextPointer tp1 = doc1.CaretPosition.DocumentEnd;
            tb_cursorPos.Text = (new TextRange(tp1, tp0).Text.Length.ToString());
        }
    }
}
