using System;
using System.Collections.Generic;

namespace StudentInfoSystem
{
    class StudentData
    {

        private const string Message = "Missing student with that facultet number";
        public static List<Student> testStudents_ = new List<Student>();
        public static List<Student> testStudents
        {
            get
            {
                loadTestStudentData();
                return testStudents_;
            }
            private set { }
        }

        public static Student findUserByFacNumber(String facNumb)
        {
            Student result = testStudents.Find(user => user.faculityNumber == facNumb);
            if (result == null)
            {
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                throw new Exception(Message);
#pragma warning restore CA1303 // Do not pass literals as localized parameters
            }
            return result;
        }

        public static Boolean isUserExistByFacNumber(String facNumber)
        {
            try
            {
                findUserByFacNumber(facNumber);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static void loadTestStudentData()
        {
            testStudents_.Add(new Student("Student1", "Student1", "Student1", "FKST", "KSI", EducationStatus.AUTHENTICATED,
               EducationLevel.BACHELOR, "123456", EducationCource.FOURTH, "9", "37"/*, DateTime.MaxValue, DateTime.MaxValue*/));
            testStudents_.Add(new Student("Student2", "Student2", "Student2", "FKST", "KSI", EducationStatus.AUTHENTICATED,
                EducationLevel.MASTER, "1213", EducationCource.THIRD, "9", "37"/*, DateTime.MaxValue, DateTime.MaxValue*/));
        }
    }
}
