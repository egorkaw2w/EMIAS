using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PRAK10
{
    public partial class RegisterPacient : Window
    {
        private List<Patient> patients = new List<Patient>
        {
            new Patient { Polis = "1234567890123456", Name = "Иван", Surname = "Иванов", Patronymic = "Иванович", Phone = "1234567890", Email = "ivan@example.com", RegistrationAddress = "Москва", ResidentialAddress = "Москва" },
            new Patient { Polis = "2345678901234567", Name = "Петр", Surname = "Петров", Patronymic = "Петрович", Phone = "2345678901", Email = "petr@example.com", RegistrationAddress = "Санкт-Петербург", ResidentialAddress = "Санкт-Петербург" },
            new Patient { Polis = "3456789012345678", Name = "Сидор", Surname = "Сидоров", Patronymic = "Сидорович", Phone = "3456789012", Email = "sidor@example.com", RegistrationAddress = "Казань", ResidentialAddress = "Казань" },
            new Patient { Polis = "4567890123456789", Name = "Алексей", Surname = "Алексеев", Patronymic = "Алексеевич", Phone = "4567890123", Email = "alex@example.com", RegistrationAddress = "Новосибирск", ResidentialAddress = "Новосибирск" },
            new Patient { Polis = "5678901234567890", Name = "Дмитрий", Surname = "Дмитриев", Patronymic = "Дмитриевич", Phone = "5678901234", Email = "dmitry@example.com", RegistrationAddress = "Екатеринбург", ResidentialAddress = "Екатеринбург" }
        };

        public RegisterPacient()
        {
            InitializeComponent();
        }

        private void Vrach_Click(object sender, RoutedEventArgs e)
        {
            RegisterVrach registerVrachWindow = new RegisterVrach();
            registerVrachWindow.Show();
            this.Close();
        }

        private void Voiti_Click(object sender, RoutedEventArgs e)
        {
            string polis = Polis.Text;
            if (polis.Length != 16 || !long.TryParse(polis, out _))
            {
                MessageBox.Show("Полис должен состоять из 16 цифр. Пожалуйста, повторите попытку.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var patient = patients.FirstOrDefault(p => p.Polis == polis);
                if (patient != null)
                {
                    MainWindow mainWindow = new MainWindow(patient);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный номер полиса. Пожалуйста, повторите попытку.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }

    public partial class Patient
    {
        public string Polis { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string RegistrationAddress { get; set; }
        public string ResidentialAddress { get; set; }
    }
}