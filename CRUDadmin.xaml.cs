using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace PRAK10
{
    public partial class CRUDadmin : Window
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "http://yourapiurl/api/AdminTables";

        public CRUDadmin()
        {
            InitializeComponent();
            _client = new HttpClient();
            LoadAdmins();
        }

        private async void LoadAdmins()
        {
            var response = await _client.GetAsync(BaseUrl);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var admins = JsonConvert.DeserializeObject<List<AdminTable>>(content);
            ((DataGrid)FindName("AdminDataGrid")).ItemsSource = admins;
        }

        private async void Dob_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                var admin = new AdminTable
                {
                    Surname = ((TextBox)FindName("SurnameTextBox")).Text,
                    Name = ((TextBox)FindName("NameTextBox")).Text,
                    Patronymic = ((TextBox)FindName("PatronymicTextBox")).Text,
                    EnterPassword = ((TextBox)FindName("PasswordTextBox")).Text
                };

                var json = JsonConvert.SerializeObject(admin);
                var response = await _client.PostAsync(BaseUrl, new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                LoadAdmins();
            }
        }

        private async void Izm_Click(object sender, RoutedEventArgs e)
        {
            if (((DataGrid)FindName("AdminDataGrid")).SelectedItem is AdminTable selectedAdmin && ValidateInput())
            {
                selectedAdmin.Surname = ((TextBox)FindName("SurnameTextBox")).Text;
                selectedAdmin.Name = ((TextBox)FindName("NameTextBox")).Text;
                selectedAdmin.Patronymic = ((TextBox)FindName("PatronymicTextBox")).Text;
                selectedAdmin.EnterPassword = ((TextBox)FindName("PasswordTextBox")).Text;

                var json = JsonConvert.SerializeObject(selectedAdmin);
                var response = await _client.PutAsync($"{BaseUrl}/{selectedAdmin.Id}", new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                LoadAdmins();
            }
        }

        private async void Del_Click(object sender, RoutedEventArgs e)
        {
            if (((DataGrid)FindName("AdminDataGrid")).SelectedItem is AdminTable selectedAdmin)
            {
                var response = await _client.DeleteAsync($"{BaseUrl}/{selectedAdmin.Id}");
                response.EnsureSuccessStatusCode();
                LoadAdmins();
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            // Логика выхода из аккаунта
        }

        private bool ValidateInput()
        {
            if (!Regex.IsMatch(((TextBox)FindName("SurnameTextBox")).Text, @"^[a-zA-Z]+$") ||
                !Regex.IsMatch(((TextBox)FindName("NameTextBox")).Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Invalid input");
                return false;
            }
            return true;
        }
    }
    public partial class AdminTable
    {
        public int? Id { get; set; }

        public string Surname { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Patronymic { get; set; }

        public string EnterPassword { get; set; } = null!;
    }
}