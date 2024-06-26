using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace PRAK10
{
    public partial class CRUDvrach : Window
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "https://localhost:7076/api/Doctor'";

        public CRUDvrach()
        {
            InitializeComponent();
            _client = new HttpClient();
            LoadDoctors();
        }

        private async void LoadDoctors()
        {
            var response = await _client.GetAsync(BaseUrl);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var doctors = JsonConvert.DeserializeObject<List<DoctorTable>>(content);
            DoctorsDataGrid.ItemsSource = doctors;
        }

        private async void Dob_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                var doctor = new DoctorTable
                {
                    Surname = SurnameTextBox.Text,
                    Name = NameTextBox.Text,
                    Patronymic = PatronymicTextBox.Text,
                    WorkAddress = WorkAddressTextBox.Text,
                    EnterPassword = PasswordTextBox.Text,
                    SpecialityId = int.Parse(SpecialityTextBox.Text)
                };

                var json = JsonConvert.SerializeObject(doctor);
                var response = await _client.PostAsync(BaseUrl, new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                LoadDoctors();
            }
        }

        private async void Izm_Click(object sender, RoutedEventArgs e)
        {
            if (DoctorsDataGrid.SelectedItem is DoctorTable selectedDoctor && ValidateInput())
            {
                selectedDoctor.Surname = SurnameTextBox.Text;
                selectedDoctor.Name = NameTextBox.Text;
                selectedDoctor.Patronymic = PatronymicTextBox.Text;
                selectedDoctor.WorkAddress = WorkAddressTextBox.Text;
                selectedDoctor.EnterPassword = PasswordTextBox.Text;
                selectedDoctor.SpecialityId = int.Parse(SpecialityTextBox.Text);

                var json = JsonConvert.SerializeObject(selectedDoctor);
                var response = await _client.PutAsync($"{BaseUrl}/{selectedDoctor.Id}", new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                LoadDoctors();
            }
        }

        private async void Del_Click(object sender, RoutedEventArgs e)
        {
            if (DoctorsDataGrid.SelectedItem is DoctorTable selectedDoctor)
            {
                var response = await _client.DeleteAsync($"{BaseUrl}/{selectedDoctor.Id}");
                response.EnsureSuccessStatusCode();
                LoadDoctors();
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            // Логика выхода из аккаунта
        }

        private bool ValidateInput()
        {
            if (!Regex.IsMatch(SurnameTextBox.Text, @"^[a-zA-Z]+$") ||
                !Regex.IsMatch(NameTextBox.Text, @"^[a-zA-Z]+$") ||
                !Regex.IsMatch(SpecialityTextBox.Text, @"^\d+$"))
            {
                MessageBox.Show("Invalid input");
                return false;
            }
            return true;
        }
    }
    public partial class DoctorTable
    {
        public int? Id { get; set; }

        public string Surname { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Patronymic { get; set; }

        public string EnterPassword { get; set; } = null!;

        public string WorkAddress { get; set; } = null!;

        public int SpecialityId { get; set; }

       
    }
}