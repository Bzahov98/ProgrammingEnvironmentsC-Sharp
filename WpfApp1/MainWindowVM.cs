using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StudentInfoSystem
{
    
   class MainWindowVM : INotifyPropertyChanged
    {
        public static Student studentFromLogin;
       public MainWindowVM() {
            currentStudent = studentFromLogin;
            updateUser();
            activateAllViews();

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
                    _currentStudent.educationStatus = value.educationStatus;
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
