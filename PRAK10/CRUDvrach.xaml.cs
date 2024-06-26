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
        private const string BaseUrl = "https://localhost:7226/api/Doctors";

        public CRUDvrach(Doctor doctor)
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
            var doctors = JsonConvert.DeserializeObject<List<Doctor>>(content);
            DoctorsDataGrid.ItemsSource = doctors;
        }

        private async void Dob_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                var doctor = new Doctor
                {
                    Surname = SurnameTextBox.Text,
                    Name = NameTextBox.Text,
                    Patronymic = PatronymicTextBox.Text,
                    WorkAddress = WorkAddressTextBox.Text,
                    DoctorEnterLogin = PasswordTextBox.Text,
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
            if (DoctorsDataGrid.SelectedItem is Doctor selectedDoctor && ValidateInput())
            {
                selectedDoctor.Surname = SurnameTextBox.Text;
                selectedDoctor.Name = NameTextBox.Text;
                selectedDoctor.Patronymic = PatronymicTextBox.Text;
                selectedDoctor.WorkAddress = WorkAddressTextBox.Text;
                selectedDoctor.DoctorEnterLogin = PasswordTextBox.Text;
                selectedDoctor.SpecialityId = int.Parse(SpecialityTextBox.Text);

                var json = JsonConvert.SerializeObject(selectedDoctor);
                var response = await _client.PutAsync($"{BaseUrl}/{selectedDoctor.Id}", new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                LoadDoctors();
            }
        }

        private async void Del_Click(object sender, RoutedEventArgs e)
        {
            if (DoctorsDataGrid.SelectedItem is Doctor selectedDoctor)
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
    public partial class Doctor
    {
        public int? IdDoctor { get; set; }

        public string DoctorSurname { get; set; } = null!;

        public string DoctorName { get; set; } = null!;

        public string? DoctorMiddleName { get; set; }

        public int? SpecialityId { get; set; }
        public string DoctorEnterLogin { get; set; } = null!;

        public string DoctorEnterPassword { get; set; } = null!;

        public string WorkAddress { get; set; } = null!;
    }
}