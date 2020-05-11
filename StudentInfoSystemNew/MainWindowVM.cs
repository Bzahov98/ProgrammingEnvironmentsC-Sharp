using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace StudentInfoSystemNew
{
    
   class MainWindowVM : INotifyPropertyChanged
    {
        public static Student studentFromLogin;
       public MainWindowVM() {
            
            currentStudent = studentFromLogin;
            updateUser();
            activateAllViews();
            FillStudStatusChoices();

        }
        private Student _currentStudent;
        public Student currentStudent {
            get { return _currentStudent; }
            set
            {
                if (value != null) {
                    _currentStudent = value;
                    _currentStudent.firstName = value.firstName;
                    _currentStudent.middleName = value.middleName;
                    _currentStudent.lastName = value.lastName;

                    _currentStudent.faculity = value.faculity;
                    _currentStudent.specialty = value.specialty;
                    _currentStudent.educationLevel = value.educationLevel;
                    //_currentStudent.educationStatus = value.educationStatus;
                    _currentStudent.faculityNumber = value.faculityNumber;
                    
                    _currentStudent.educationCource = value.educationCource;
                    _currentStudent.stream = value.stream;
                    _currentStudent.group = value.group;
                    updateUser();
                }
            }
        }

        public void updateUser() {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Student"));
        }
        public void activateAllViews() {
            isEnabled = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("isEnabled"));
        }
        public void deactivateAllViews() {
            isEnabled = false;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("isEnabled"));
        }


        public List<string> StudStatusChoices { get; set; }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery =
                @"SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)

                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }
        private bool _isEnabled = false;
        public bool isEnabled {
            get => _isEnabled;
            set => _isEnabled = value;
        }


        public event PropertyChangedEventHandler PropertyChanged;



        public void updateStudentInfo()
        {
           // currentStudent.
        }
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }

}
