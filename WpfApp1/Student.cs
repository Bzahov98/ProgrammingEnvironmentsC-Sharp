using System;

namespace StudentInfoSystem
{
    public class Student
    {   
        public Student(string firstName, string middleName, string lastName, string faculity, string specialty, EducationStatus educationStatus, EducationLevel educationLevel, string faculityNumber, EducationCource educationCource, string stream, string group)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.faculity = faculity;
            this.specialty = specialty;
            this.educationStatus = educationStatus;
            this.educationLevel = educationLevel;
            this.faculityNumber = faculityNumber;
            this.educationCource = educationCource;
            this.stream = stream;
            this.group = group;
        }

        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string faculity { get; set; }
        public string specialty { get; set; }
        public EducationStatus educationStatus { get; set; }
        public EducationLevel educationLevel { get; set; }
        public String faculityNumber { get; set; }
        public EducationCource educationCource { get; set; }
        public string stream { get; set; }
        public string group { get; set; }

      /*  public DateTime AuthenticationDueDate { get; set; }
        public DateTime FinalPaymentDueDate { get; set; }
*/


    }
}
