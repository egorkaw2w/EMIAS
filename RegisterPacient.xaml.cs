using System;
using System.Net.Http;
using System.Text;
using System.Windows;
using Newtonsoft.Json;

namespace PRAK10
{
    public partial class RegisterPacient : Window
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public RegisterPacient()
        {
            InitializeComponent();
        }

        private void Vrach_Click(object sender, RoutedEventArgs e)
        {
            RegisterVrach registerVrachWindow = new RegisterVrach();
            registerVrachWindow.Show();
            this.Close();
        }

        private async void Voiti_Click(object sender, RoutedEventArgs e)
        {
            string polis = Polis.Text;
            if (polis.Length != 16 || !long.TryParse(polis, out _))
            {
                MessageBox.Show("Полис должен состоять из 16 цифр. Пожалуйста, повторите попытку.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var request = new { Polis = polis };
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7076/Auth/login", content);
                if (response.IsSuccessStatusCode)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный номер полиса. Пожалуйста, повторите попытку.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}