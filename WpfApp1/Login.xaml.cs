using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PS_37_Bzahov;
using WpfApp1;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnLoginStudent_Click(object sender, RoutedEventArgs e)
        {
            String username = txtFirstName.Text;
            if (String.IsNullOrEmpty(username))
            {
                MessageBox.Show("Името не може да е празно");
                return;
            }

            String password = txtPassword.Text;
            if (String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Паролата не може да е празнa");
                return;
            }

            User user = UserData.IsUserPassCorrect(username, password);
            if (user == null)
            {
                MessageBox.Show("Грешно име или парола");
                return;
            }

            //MainWindow mainForm = new MainWindow(getUserFromData(user.FacNumber));
            
            MainWindowVM.studentFromLogin = getUserFromData(user.FacNumber);
            MainWindow mainForm = new MainWindow();
            mainForm.Show();
            this.Close();
        }

        private Student getUserFromData(string userFacultNumb)
        {
            return StudentData.testStudents.Where(student => student.faculityNumber == userFacultNumb).FirstOrDefault();
        }
    }
}
