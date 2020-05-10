using System.Linq;
using System.Windows;
using System.Windows.Controls;
using StudentInfoSystem;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowVM mwVM;
        private string userFacultNumb;
        private Student currentStudent;
        //DEbug
        public MainWindow( )
        {
           /* string userFn = "123456";
           */ InitializeComponent();
           /* this.userFacultNumb = userFn;
            this.currentStudent = null;
            mwVM = new MainWindowVM();
            this.DataContext = mwVM;
            LoadUser();*/
        } 
        /*public MainWindow( string userFn = "123456")
        {
            InitializeComponent();
            this.currentStudent = null;
            this.userFacultNumb = userFn;
            LoadUser();
        }
        public MainWindow( Student student)
        {
            InitializeComponent();
            //mwVM = new MainWindowVM();
            //mwVM.currentStudent = student;
            //LoadUser(currentStudent); 
        }*/

        private void LoadUser(Student student = null)
        {
            if (student == null || student.faculityNumber == null || student.faculityNumber.Length == 0)
            {
                clearAllFormsData();
                banAllForms();
                return;
            }
            else
            {
                //student = getUserFromData();
            }
            this.userFacultNumb = student.faculityNumber;


            txtFirstName.Text = student.firstName;
            txtSecondName.Text = student.middleName;
            txtLastName.Text = student.lastName;
            txtGroup.Text = student.group;
            txtFaculty.Text = student.faculity;
            txtFacultyNumber.Text = student.faculityNumber;
            txtSpeciality.Text = student.specialty;
            txtStream.Text = student.stream;
            txtLevel.Text = student.educationLevel.ToString(); ;
            txtStatus.Text = student.educationStatus.ToString();
            txtCourse.Text = student.educationCource.ToString();
        }

        private Student getStudentFromDataByFacNumb(string facultNumb)
        {
            return StudentData.testStudents.Where(student => student.faculityNumber == facultNumb).FirstOrDefault();
        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            clearAllFormsData();
        }

        private void clearAllFormsData()
        {
            foreach (Control ctl in StudentInfoGrid.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                    ((TextBox)ctl).Text = "";
            }

            foreach (Control ctl in PersonalInfoGrid.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                    ((TextBox)ctl).Text = "";
            }
        }

        private void BtnLoadStudent_Click(object sender, RoutedEventArgs e)
        {
            LoadUser(currentStudent);
        }
        private void BtnBanForm_Click(object sender, RoutedEventArgs e)
        {
            banAllForms();
        }

        private void banAllForms()
        {
            foreach (Control ctl in PersonalInfoGrid.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                    ((TextBox)ctl).IsEnabled = !((TextBox)ctl).IsEnabled;
            }

            foreach (Control ctl in StudentInfoGrid.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    ((TextBox)ctl).IsEnabled = !((TextBox)ctl).IsEnabled;
                }
            }
        }

    }
}
