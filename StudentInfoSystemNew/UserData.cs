using System;
using System.Collections.Generic;

namespace StudentInfoSystemNew
{
    public static class UserData
    {
        private static List<User> testUsers;

        public static List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return testUsers;
            }
            set { }
        }

        private static void ResetTestUserData()
        {
            if (testUsers == null)
            {
                testUsers = new List<User>();
                testUsers.Add(new User
                {
                    Username = "admin",
                    Password = "admin",
                    FacNumber = "0000",
                    Role = UserRoles.ADMIN,
                    Created = DateTime.Now,
                    ActiveTo = DateTime.MaxValue
                });
                testUsers.Add(new User
                {
                    Username = "student1",
                    Password = "student1",
                    FacNumber = "123456",
                    Role = UserRoles.STUDENT,
                    Created = DateTime.Now,
                    ActiveTo = DateTime.MaxValue
                });
                testUsers.Add(new User
                {
                    Username = "student2",
                    Password = "student2",
                    FacNumber = "22222",
                    Role = UserRoles.STUDENT,
                    Created = DateTime.Now,
                    ActiveTo = DateTime.MaxValue
                });
            }
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            foreach (var user in TestUsers)
                if (user.Username.Equals(username) && user.Password.Equals(password))
                    return user;
            return null;
        }

        public static void SetUserActiveTo(string username, DateTime activeTo)
        {
            foreach (var user in TestUsers)
                if (user.Username.Equals(username))
                {
                    user.ActiveTo = activeTo;
                    Logger.LogActivity("Промяна на активност на " + username);
                    break;
                }
        }

        public static void AssignUserRole(string username, UserRoles role)
        {
            foreach (var user in TestUsers)
                if (user.Username.Equals(username))
                {
                    user.Role = role;
                    Logger.LogActivity("Промяна на роля на " + username);
                    break;
                }
        }
    }
}