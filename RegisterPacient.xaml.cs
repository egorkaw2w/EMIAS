using System;
using System.Windows;

namespace PRAK10
{
    public partial class RegisterPacient : Window
    {
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
            if (polis.Length != 16 || !Int64.TryParse(polis, out _))
            {
                MessageBox.Show("Полис должен состоять из 16 цифр. Пожалуйста, повторите попытку.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                
            }
        }
    }
}