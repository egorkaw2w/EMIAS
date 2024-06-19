using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace C_mainproject2
{
    public partial class MainWindow : Window
    {
        public List<Appointment> Appointments { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            LoadAppointments();
            DataContext = this;
        }

        private void LoadAppointments()
        {
            Appointments = new List<Appointment>
            {
                new Appointment { PatientName = "Иванов Иван Иванович", AppointmentTime = DateTime.Now.AddMinutes(10) },
                new Appointment { PatientName = "Петров Петр Петрович", AppointmentTime = DateTime.Now.AddMinutes(20) },
                new Appointment { PatientName = "Сидоров Сидор Сидорович", AppointmentTime = DateTime.Now.AddMinutes(30) },
            };
        }

        private void StartAppointment_Click(object sender, RoutedEventArgs e)
        {
            var appointment = (sender as Button)?.DataContext as Appointment;
            if (appointment != null)
            {
                MessageBox.Show($"Прием начат для пациента {appointment.PatientName}!");
            }
        }

        private void EndAppointment_Click(object sender, RoutedEventArgs e)
        {
            var appointment = (sender as Button)?.DataContext as Appointment;
            if (appointment != null)
            {
                appointment.IsCompleted = true;
                MessageBox.Show($"Прием завершен для пациента {appointment.PatientName}!");
                PatientsListBox.Items.Refresh(); // Обновление отображения списка пациентов
            }
        }
    }
}
