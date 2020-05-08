using PS_37_Bzahov;

namespace StudentInfoSystem
{
    class StudentValidation
    {
        public Student getStudentDataByUser(User user)
        {
            if (user.FacNumber == null || StudentData.isUserExistByFacNumber(user.FacNumber))
            {

            }
            return null;
        }
    }
}
