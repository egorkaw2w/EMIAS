using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PRAK10
{
    /// <summary>
    /// Логика взаимодействия для RegisterVrach.xaml
    /// </summary>
    public partial class RegisterVrach : Window
    {
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

            if (numberSotrud == "12345" && parol == "password")
            {
                CRUDvrach crudVrachWindow = new CRUDvrach();
                crudVrachWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный номер сотрудника или пароль. Пожалуйста, попробуйте еще раз.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
