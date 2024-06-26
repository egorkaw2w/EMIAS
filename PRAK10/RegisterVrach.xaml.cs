using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PRAK10
{
    public partial class RegisterVrach : Window
    {
        private List<Doctor> doctors = new List<Doctor>
        {
            new Doctor { Id = 1, Password = "pass1", Name = "Андрей", Surname = "Андреев", Patronymic = "Андреевич", Speciality = "Хирург" },
            new Doctor { Id = 2, Password = "pass2", Name = "Борис", Surname = "Борисов", Patronymic = "Борисович", Speciality = "Терапевт" },
            new Doctor { Id = 3, Password = "pass3", Name = "Виктор", Surname = "Викторов", Patronymic = "Викторович", Speciality = "Офтальмолог" },
            new Doctor { Id = 4, Password = "pass4", Name = "Григорий", Surname = "Григорьев", Patronymic = "Григорьевич", Speciality = "Дерматолог" },
            new Doctor { Id = 5, Password = "pass5", Name = "Денис", Surname = "Денисов", Patronymic = "Денисович", Speciality = "Невролог" }
        };

        public RegisterVrach()
        {
            InitializeComponent();
        }

        private void Pacient_Click(object sender, RoutedEventArgs e)
        {
            RegisterPacient registerPacientWindow = new RegisterPacient();
            registerPacientWindow.Show();
            this.Close();
        }

        private void Voiti_Click(object sender, RoutedEventArgs e)
        {
            string numberSotrud = NumberSotrud.Text;
            string parol = Parol.Password;

            if (!int.TryParse(numberSotrud, out int id))
            {
                MessageBox.Show("Неверный формат номера сотрудника.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var doctor = doctors.FirstOrDefault(d => d.Id == id && d.Password == parol);
            if (doctor != null)
            {
                CRUDvrach crudVrachWindow = new CRUDvrach(doctor);
                crudVrachWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный номер сотрудника или пароль. Пожалуйста, попробуйте еще раз.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    public partial class Doctor
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Speciality { get; set; }
    }
}