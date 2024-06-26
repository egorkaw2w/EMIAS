using Newtonsoft.Json;
using PRAK10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EMIAS
{
    /// <summary>
    /// Логика взаимодействия для Profile_User.xaml
    /// </summary>
    public partial class Profile_User : Page
    {
        private readonly HttpClient httpClient = new HttpClient();

        public Profile_User()
        {
            InitializeComponent();
            LoadUserData();
        }

        private async void LoadUserData()
        {
            try
            {
                var response = await httpClient.GetAsync("https://yourapiurl/api/PatientTables/1");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var patient = JsonConvert.DeserializeObject<PatientTable>(json);
                    UpdateUI(patient);
                }
                else
                {
                    MessageBox.Show("Failed to load user data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void UpdateUI(PatientTable patient)
        {
            ((TextBlock)FindName("PatientOms")).Text = patient.Oms.ToString();
            ((TextBlock)FindName("PatientName")).Text = $"{patient.Surname} {patient.Name} {patient.Patronymic}";
            ((TextBlock)FindName("PatientBirthDate")).Text = patient.BirthDate.ToString("dd.MM.yyyy");
        }
    }
}
