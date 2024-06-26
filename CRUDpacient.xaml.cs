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
        private const string BaseUrl = "http://yourapiurl/api/PatientTables";

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
            var patients = JsonConvert.DeserializeObject<List<PatientTable>>(content);
            ((DataGrid)FindName("PatientDataGrid")).ItemsSource = patients;
        }

        private async void Dob_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                var patient = new PatientTable
                {
                    Oms = long.Parse(((TextBox)FindName("OmsTextBox")).Text),
                    Surname = ((TextBox)FindName("SurnameTextBox")).Text,
                    Name = ((TextBox)FindName("NameTextBox")).Text,
                    Patronymic = ((TextBox)FindName("PatronymicTextBox")).Text,
                    BirthDate = DateOnly.Parse(((TextBox)FindName("BirthDateTextBox")).Text),
                    Address = ((TextBox)FindName("AddressTextBox")).Text,
                    LivingAddress = ((TextBox)FindName("LivingAddressTextBox")).Text,
                    Phone = ((TextBox)FindName("PhoneTextBox")).Text,
                    Email = ((TextBox)FindName("EmailTextBox")).Text,
                    Nickname = ((TextBox)FindName("NicknameTextBox")).Text
                };

                var json = JsonConvert.SerializeObject(patient);
                var response = await _client.PostAsync(BaseUrl, new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                LoadPatients();
            }
        }

        private async void Izm_Click(object sender, RoutedEventArgs e)
        {
            if (((DataGrid)FindName("PatientDataGrid")).SelectedItem is PatientTable selectedPatient && ValidateInput())
            {
                selectedPatient.Oms = long.Parse(((TextBox)FindName("OmsTextBox")).Text);
                selectedPatient.Surname = ((TextBox)FindName("SurnameTextBox")).Text;
                selectedPatient.Name = ((TextBox)FindName("NameTextBox")).Text;
                selectedPatient.Patronymic = ((TextBox)FindName("PatronymicTextBox")).Text;
                selectedPatient.BirthDate = DateOnly.Parse(((TextBox)FindName("BirthDateTextBox")).Text);
                selectedPatient.Address = ((TextBox)FindName("AddressTextBox")).Text;
                selectedPatient.LivingAddress = ((TextBox)FindName("LivingAddressTextBox")).Text;
                selectedPatient.Phone = ((TextBox)FindName("PhoneTextBox")).Text;
                selectedPatient.Email = ((TextBox)FindName("EmailTextBox")).Text;
                selectedPatient.Nickname = ((TextBox)FindName("NicknameTextBox")).Text;

                var json = JsonConvert.SerializeObject(selectedPatient);
                var response = await _client.PutAsync($"{BaseUrl}/{selectedPatient.Oms}", new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                LoadPatients();
            }
        }

        private async void Del_Click(object sender, RoutedEventArgs e)
        {
            if (((DataGrid)FindName("PatientDataGrid")).SelectedItem is PatientTable selectedPatient)
            {
                var response = await _client.DeleteAsync($"{BaseUrl}/{selectedPatient.Oms}");
                response.EnsureSuccessStatusCode();
                LoadPatients();
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            // Логика выхода из аккаунта
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
    public class PatientTable
    {
        public long Oms { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Address { get; set; }
        public string LivingAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
    }
}