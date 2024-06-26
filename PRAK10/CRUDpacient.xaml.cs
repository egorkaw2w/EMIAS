using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace PRAK10
{
    public partial class CRUDpacient : Window
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "https://localhost:7226/api/Patients";

        public CRUDpacient()
        {
            InitializeComponent();
            _client = new HttpClient();
            LoadPatients();
        }

        private async void LoadPatients()
        {
            var response = await _client.GetAsync(BaseUrl);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var patients = JsonConvert.DeserializeObject<List<Patient>>(content);
            ((DataGrid)FindName("PatientDataGrid")).ItemsSource = patients;
        }

        private async void Dob_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                var patient = new Patient
                {
                    Oms = long.Parse(((TextBox)FindName("OmsTextBox")).Text),
                    Surname = ((TextBox)FindName("SurnameTextBox")).Text,
                    Name = ((TextBox)FindName("NameTextBox")).Text,
                    Patronymic = ((TextBox)FindName("PatronymicTextBox")).Text,
                    PatientBirthDate = DateOnly.Parse(((TextBox)FindName("BirthDateTextBox")).Text),
                    PatientAddress = ((TextBox)FindName("AddressTextBox")).Text,
                    PatientLivingAddress = ((TextBox)FindName("LivingAddressTextBox")).Text,
                    Phone = ((TextBox)FindName("PhoneTextBox")).Text,
                    Email = ((TextBox)FindName("EmailTextBox")).Text,
                    PatientNickName = ((TextBox)FindName("NicknameTextBox")).Text
                };

                var json = JsonConvert.SerializeObject(patient);
                var response = await _client.PostAsync(BaseUrl, new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                LoadPatients();
            }
        }

        private async void Izm_Click(object sender, RoutedEventArgs e)
        {
            if (((DataGrid)FindName("PatientDataGrid")).SelectedItem is Patient selectedPatient && ValidateInput())
            {
                selectedPatient.Oms = long.Parse(((TextBox)FindName("OmsTextBox")).Text);
                selectedPatient.Surname = ((TextBox)FindName("SurnameTextBox")).Text;
                selectedPatient.Name = ((TextBox)FindName("NameTextBox")).Text;
                selectedPatient.Patronymic = ((TextBox)FindName("PatronymicTextBox")).Text;
                selectedPatient.PatientBirthDate = DateOnly.Parse(((TextBox)FindName("BirthDateTextBox")).Text);
                selectedPatient.PatientAddress = ((TextBox)FindName("AddressTextBox")).Text;
                selectedPatient.PatientLivingAddress = ((TextBox)FindName("LivingAddressTextBox")).Text;
                selectedPatient.Phone = ((TextBox)FindName("PhoneTextBox")).Text;
                selectedPatient.Email = ((TextBox)FindName("EmailTextBox")).Text;
                selectedPatient.PatientNickName = ((TextBox)FindName("NicknameTextBox")).Text;

                var json = JsonConvert.SerializeObject(selectedPatient);
                var response = await _client.PutAsync($"{BaseUrl}/{selectedPatient.Oms}", new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                LoadPatients();
            }
        }

        private async void Del_Click(object sender, RoutedEventArgs e)
        {
            if (((DataGrid)FindName("PatientDataGrid")).SelectedItem is Patient selectedPatient)
            {
                var response = await _client.DeleteAsync($"{BaseUrl}/{selectedPatient.Oms}");
                response.EnsureSuccessStatusCode();
                LoadPatients();
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {

        }
        private bool ValidateInput()
        {
            if (!Regex.IsMatch(((TextBox)FindName("OmsTextBox")).Text, @"^\d+$") ||
                !Regex.IsMatch(((TextBox)FindName("SurnameTextBox")).Text, @"^[a-zA-Z]+$") ||
                !Regex.IsMatch(((TextBox)FindName("NameTextBox")).Text, @"^[a-zA-Z]+$") ||
                !Regex.IsMatch(((TextBox)FindName("PatronymicTextBox")).Text, @"^[a-zA-Z]*$") ||
                !Regex.IsMatch(((TextBox)FindName("BirthDateTextBox")).Text, @"^\d{4}-\d{2}-\d{2}$") ||
                !Regex.IsMatch(((TextBox)FindName("AddressTextBox")).Text, @"^[a-zA-Z0-9\s]+$") ||
                !Regex.IsMatch(((TextBox)FindName("LivingAddressTextBox")).Text, @"^[a-zA-Z0-9\s]*$") ||
                !Regex.IsMatch(((TextBox)FindName("PhoneTextBox")).Text, @"^\+?\d{1,3}[-.\s]?\(?\d{1,3}\)?[-.\s]?\d{1,4}[-.\s]?\d{1,4}$") ||
                !Regex.IsMatch(((TextBox)FindName("EmailTextBox")).Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$") ||
                !Regex.IsMatch(((TextBox)FindName("NicknameTextBox")).Text, @"^[a-zA-Z0-9_]*$"))
            {
                MessageBox.Show("Invalid input");
                return false;
            }
            return true;
        }
    }
    public partial class Patient
    {
        public int? IdPatient { get; set; }

        public long Oms { get; set; }

        public string PatientSurname { get; set; } = null!;

        public string PatientName { get; set; } = null!;

        public string? PatientMiddleName { get; set; }

        public DateOnly PatientBirthDate { get; set; }

        public string PatientAddress { get; set; } = null!;

        public string? PatientLivingAddress { get; set; }

        public string? PatientPhoneNumber { get; set; }

        public string? PatientEmail { get; set; }

        public string? PatientNickName { get; set; }
    }
}