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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Hello_Click(object sender, RoutedEventArgs e)
        {
            string message = string.Empty;
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    if (((TextBox)item).Text.Length < 2)
                    {
                        MessageBox.Show("Името ти трябва да е по-дълго от един символ");
                        return;
                    }
                    message = message + ((TextBox)item).Text + ", ";
                }
            }
            message = message.TrimEnd(new char[] { ' ', ',' });
            MessageBox.Show("Здрасти!!! " + message + " Това е програма на Visual Studio  2020!");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Сигурен ли сте, че искате да излезете?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyMessage anotherWindow = new MyMessage();
            anotherWindow.Show();
            //MessageBox.Show("Hello, Windows Presentation Foundation!");
        }

   
    }
}
