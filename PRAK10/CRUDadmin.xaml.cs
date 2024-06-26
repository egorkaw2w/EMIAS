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
        private const string BaseUrl = "https://localhost:7226/api/Administrators";

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
            var admins = JsonConvert.DeserializeObject<List<Administrator>>(content);
            ((DataGrid)FindName("AdminDataGrid")).ItemsSource = admins;
        }

        private async void Dob_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                var admin = new Administrator
                {
                    AdminSurname = ((TextBox)FindName("SurnameTextBox")).Text,
                    AdminName = ((TextBox)FindName("NameTextBox")).Text,
                    AdminMiddleName = ((TextBox)FindName("PatronymicTextBox")).Text,
                    AdminEnterLogin = ((TextBox)FindName("PasswordTextBox")).Text
                };

                var json = JsonConvert.SerializeObject(admin);
                var response = await _client.PostAsync(BaseUrl, new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                LoadAdmins();
            }
        }

        private async void Izm_Click(object sender, RoutedEventArgs e)
        {
            if (((DataGrid)FindName("AdminDataGrid")).SelectedItem is Administrator selectedAdmin && ValidateInput())
            {
                selectedAdmin.AdminSurname = ((TextBox)FindName("SurnameTextBox")).Text;
                selectedAdmin.AdminName = ((TextBox)FindName("NameTextBox")).Text;
                selectedAdmin.AdminMiddleName = ((TextBox)FindName("PatronymicTextBox")).Text;
                selectedAdmin.AdminEnterLogin = ((TextBox)FindName("PasswordTextBox")).Text;

                var json = JsonConvert.SerializeObject(selectedAdmin);
                var response = await _client.PutAsync($"{BaseUrl}/{selectedAdmin.IdAdministrator}", new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                LoadAdmins();
            }
        }

        private async void Del_Click(object sender, RoutedEventArgs e)
        {
            if (((DataGrid)FindName("AdminDataGrid")).SelectedItem is Administrator selectedAdmin)
            {
                var response = await _client.DeleteAsync($"{BaseUrl}/{selectedAdmin.IdAdministrator}");
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
    public partial class Administrator
    {
        public int? IdAdministrator { get; set; }

        public string AdminSurname { get; set; } = null!;

        public string AdminName { get; set; } = null!;

        public string? AdminMiddleName { get; set; }
        public string AdminEnterLogin { get; set; } = null!;

        public string AdminEnterPassword { get; set; } = null!;
    }
}