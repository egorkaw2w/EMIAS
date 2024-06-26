using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Microsoft.Win32;

namespace PRAK10
{
    public partial class Research_Page : Page
    {

        public Research_Page()
        {
            InitializeComponent();
            RichTextBoxContent = new RichTextBox();
            LoadRtfFile();
        }

        private void LoadRtfFile()
        {
            string filePath = "тут херачим путь к ртф файлу бро";
            if (File.Exists(filePath))
            {
                var textRange = new TextRange(RichTextBoxContent.Document.ContentStart, RichTextBoxContent.Document.ContentEnd);
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    textRange.Load(stream, DataFormats.Rtf);
                }
            }
            else
            {
                MessageBox.Show("Файл не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DownloadFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Rich Text Format (*.rtf)|*.rtf",
                FileName = "документик.rtf"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                var textRange = new TextRange(RichTextBoxContent.Document.ContentStart, RichTextBoxContent.Document.ContentEnd);
                using (var stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    textRange.Save(stream, DataFormats.Rtf);
                }
            }
        }
    }
}