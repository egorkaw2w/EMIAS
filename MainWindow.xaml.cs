using EMIAS;
using System.Windows;
using System.Windows.Controls;

namespace PRAK10
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Content_menu.Content = new Profile_User();
        }

        private void List_Main_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is TreeViewItem selectedItem)
            {
                switch (selectedItem.Header)
                {
                    case "Приёмы":
                        Content_menu.Content = new Priemi_Page();
                        break;
                    case "Исследования":
                        Content_menu.Content = new Research_Page();
                        break;
                    default:
                        Content_menu.Content = new Profile_User();
                        break;
                }
            }
        }
    }
}