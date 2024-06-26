using System;
using System.Net.Http;
using System.Text;
using System.Windows;
using Newtonsoft.Json;

namespace PRAK10
{
    /// <summary>
    /// Логика взаимодействия для RegisterVrach.xaml
    /// </summary>
    public partial class RegisterVrach : Window
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public RegisterVrach()
        {
            InitializeComponent();
        }

        private void Pacient_Click(object sender, RoutedEventArgs e)
        {
            RegisterPacient registerPacientWindow = new RegisterPacient();
            registerPacientWindow.Show();
            this.Close();
        }

        private async void Voiti_Click(object sender, RoutedEventArgs e)
        {
            string numberSotrud = NumberSotrud.Text;
            string parol = Parol.Password;

            int? id = int.TryParse(numberSotrud, out int parsedId) ? (int?)parsedId : null;

            if (!id.HasValue)
            {
                MessageBox.Show("Неверный формат номера сотрудника.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var request = new { Id = id, EnterPassword = parol };
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7076/api/DoctorAuth/login", content);
            if (response.IsSuccessStatusCode)
            {
                CRUDvrach crudVrachWindow = new CRUDvrach();
                crudVrachWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный номер сотрудника или пароль. Пожалуйста, попробуйте еще раз.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}