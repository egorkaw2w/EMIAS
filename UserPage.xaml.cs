using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace EMIAS
{
    public partial class UserPage : Page
    {
        private readonly HttpClient httpClient = new HttpClient();

        public UserPage()
        {
            InitializeComponent();
            LoadDoctors();
            LoadAppointments();
        }

        private async void LoadDoctors()
        {
            try
            {
                var response = await httpClient.GetAsync("https://yourapiurl/api/doctors");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var doctors = JsonConvert.DeserializeObject<List<Doctor>>(json);
                    DoctorsList.ItemsSource = doctors;
                }
                else
                {
                    MessageBox.Show("Failed to load doctors data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private async void LoadAppointments()
        {
            try
            {
                var response = await httpClient.GetAsync("https://yourapiurl/api/appointments");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var appointments = JsonConvert.DeserializeObject<List<Appointment>>(json);
                    ActiveAppointmentsList.ItemsSource = appointments;
                    ArchivedAppointmentsList.ItemsSource = appointments;
                }
                else
                {
                    MessageBox.Show("Failed to load appointments data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }

    public class Doctor
    {
        public string Name { get; set; }
    }

    public class Appointment
    {
        public DateTime Date { get; set; }
    }
}