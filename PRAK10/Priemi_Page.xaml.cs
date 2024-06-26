using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Net.Http.Formatting; 

namespace EMIAS
{
    public partial class Priemi_Page : Page
    {
        private RichTextBox richTextBox;
        private WrapPanel wrapPanel;

        public Priemi_Page()
        {
            InitializeComponent();
            richTextBox = (RichTextBox)FindName("richTextBox");
            wrapPanel = (WrapPanel)FindName("wrapPanel");
            LoadRtfFile();
            LoadSpecialists();
        }

        private async void LoadRtfFile()
        {
            string rtfContent = await GetRtfContentFromAPI();
            var textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            using (var stream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(rtfContent)))
            {
                textRange.Load(stream, DataFormats.Rtf);
            }
        }

        private async Task<string> GetRtfContentFromAPI()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("URL_К_ВАШЕМУ_API_ДЛЯ_RTF");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        private async void LoadSpecialists()
        {
            List<SpecialitiesTable> specialists = await GetSpecialistsFromAPI();
            foreach (var specialist in specialists)
            {
                wrapPanel.Children.Add(CreateSpecialistCard(specialist));
            }
        }

        private async Task<List<SpecialitiesTable>> GetSpecialistsFromAPI()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:7226/api/Doctors");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<List<SpecialitiesTable>>();
            }
        }

        private UIElement CreateSpecialistCard(SpecialitiesTable specialist)
        {
            Border card = new Border
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                Margin = new Thickness(5),
                Padding = new Thickness(10),
                Background = Brushes.LightGray
            };

            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(new TextBlock { Text = specialist.Name, FontWeight = FontWeights.Bold });
            stackPanel.Children.Add(new TextBlock { Text = specialist.Specialization });
            stackPanel.Children.Add(new TextBlock { Text = specialist.ContactInfo });

            card.Child = stackPanel;
            return card;
        }
    }

    public partial class SpecialitiesTable
    {
        public int? Id { get; set; }

        public string Name { get; set; } = null!;

        public string Specialization { get; set; } = null!;

        public string ContactInfo { get; set; } = null!;
    }
}