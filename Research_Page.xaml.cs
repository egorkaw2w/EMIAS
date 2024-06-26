using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Microsoft.Win32;

namespace EMIAS
{
    public partial class Research_Page : Page
    {
        private RichTextBox RichTextBoxContent;

        public Research_Page()
        {
            InitializeComponent();
            RichTextBoxContent = new RichTextBox();
            LoadRtfFile();
        }

        private async void LoadRtfFile()
        {
            string rtfContent = await GetRtfContentFromAPI();
            var textRange = new TextRange(RichTextBoxContent.Document.ContentStart, RichTextBoxContent.Document.ContentEnd);
            using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(rtfContent)))
            {
                textRange.Load(stream, DataFormats.Rtf);
            }
        }

        private async Task<string> GetRtfContentFromAPI()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("URL_К_ВАШЕМУ_API");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        private void DownloadFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Rich Text Format (*.rtf)|*.rtf",
                FileName = "document.rtf"
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