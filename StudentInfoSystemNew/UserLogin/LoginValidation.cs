using System;

namespace StudentInfoSystemNew
{
    public class LoginValidation
    {
        private string username;
        private string password;
        private string errorMessage;

        public static string currentUserUsername { get; private set; }
        public static  User currentUser { get; private set; }

        public static UserRoles currentUserRole { get; private set; }

        public delegate void ActionOnError(string errorMessage);

        private ActionOnError errorFunc;

        public LoginValidation(string username, string password, ActionOnError errorFunc)
        {
            this.username = username;
            this.password = password;
            this.errorFunc = errorFunc;
        }

        public bool ValidateUserInput(ref User user)
        {
            bool emptyUserName;
            emptyUserName = username.Equals(string.Empty);
            if (emptyUserName == true)
            {
                errorMessage = "Не е посочено потребителско име";
                errorFunc(errorMessage);
                currentUserUsername = username;
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }
            if (username.Length < 5)
            {
                errorMessage = "Потребителското име не може да бъде по-късо от 5 символа";
                errorFunc(errorMessage);
                currentUserUsername = username;
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }
            bool emptyPassword;
            emptyPassword = password.Equals(string.Empty);
            if (emptyPassword == true)
            {
                errorMessage = "Не е посочена парола";
                errorFunc(errorMessage);
                currentUserUsername = username;
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }
            if (password.Length < 5)
            {
                errorMessage = "Паролата не може да бъде по-къса от 5 символа";
                errorFunc(errorMessage);
                currentUserUsername = username;
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }
            user = UserData.IsUserPassCorrect(username, password);
            if (user != null)
            {
                currentUserUsername = user.Username;
                currentUser = user;
                currentUserRole = user.Role;
                DateTime lastLogIn = Logger.GetLastLogInInfo(user.Username);
                TimeSpan differenceFromLastLogIn = DateTime.Now.Subtract(lastLogIn);
                Console.WriteLine("Успешен Login, Последно си влизал преди "
                    + differenceFromLastLogIn.Days + " Дни, "
                    + differenceFromLastLogIn.Hours + " Часове, "
                    + differenceFromLastLogIn.Minutes + " Минути, "
                    + differenceFromLastLogIn.Seconds + " Секунди, ");
                Logger.LogActivity("Успешен Login", user);
                return true;
            }
            else
            {
                errorMessage = "Потребителят не беше открит";
                errorFunc(errorMessage);
                currentUserUsername = username;
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }
        }
    }
}