using System;

namespace StudentInfoSystemNew
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FacNumber { get; set; }
        public UserRoles Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime ActiveTo { get; set; }

        public override string ToString()
        {
            return Username + ", "
                    + Password + ", "
                    + FacNumber + ", "
                    + Role + ", "
                    + Created + ", "
                    + ActiveTo;
        }
    }
}