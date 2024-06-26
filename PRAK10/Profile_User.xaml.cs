using PRAK10;
using System.Windows.Controls;
using System.Windows;
using DocumentFormat.OpenXml.Drawing;
using ThemeLibrary2;

namespace EMIAS
{
    public partial class Profile_User : Page
    {
        private Patient currentPatient;

        public Profile_User(Patient patient)
        {
            InitializeComponent();
            currentPatient = patient;
            UpdateUI(currentPatient);
        }

        private void UpdateUI(Patient patient)
        {
            ((TextBlock)FindName("PatientOms")).Text = patient.Polis;
            ((TextBlock)FindName("PatientName")).Text = $"{patient.Surname} {patient.Name} {patient.Patronymic}";
            ((TextBlock)FindName("PatientPhone")).Text = patient.Phone;
            ((TextBlock)FindName("PatientEmail")).Text = patient.Email;
            ((TextBlock)FindName("PatientRegistrationAddress")).Text = patient.RegistrationAddress;
            ((TextBlock)FindName("PatientResidentialAddress")).Text = patient.ResidentialAddress;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegisterPacient pac = new RegisterPacient();
            pac.Show();
            if (Application.Current.MainWindow != null)
            {
                Application.Current.MainWindow.Close();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ThemeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                if (Enum.TryParse(selectedItem.Tag.ToString(), out Theme selectedTheme))
                {
                    ThemeManager.ChangeTheme(selectedTheme);
                }
            }
        }
    }
}