using System;
using System.IO;

namespace PS_37_Bzahov
{
    class Program
    {
        static void DisplayError(string errorMessage)
        {
            Console.WriteLine("!!! " + errorMessage + " !!!");
        }

        static void ShowAdministratorMenu()
        {
            while (true)
            {


                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine();
                Console.WriteLine("Изберете опция Choose:");
                Console.WriteLine("0: Изход");
                Console.WriteLine("1: Промяна на роля на потребител");
                Console.WriteLine("2: Промяна на активност на потребител");
                Console.WriteLine("3: Списък на потребителите");
                Console.WriteLine("4: Преглед на лог на активност");
                Console.WriteLine("5: Преглед на текуща активност");

                int option;

                if (!int.TryParse(Console.ReadLine(), out option) || option < 0 || option > 5)
                {
                    Console.WriteLine("Моля изберете отново!");
                    continue;
                }

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Изход...");
                        return;
                    case 1:
                        ChangeUserRole();
                        break;
                    case 2:
                        ChangeUserActiveTo();
                        break;
                    case 3:
                        foreach (var user in UserData.TestUsers)
                            Console.WriteLine(user.ToString());
                        break;
                    case 4:
                        StreamReader reader = new StreamReader("log.txt");
                        Console.WriteLine(reader.ReadToEnd());
                        reader.Close();
                        break;
                    case 5:
                        Console.WriteLine(Logger.GetCurrentSessionActivities());
                        break;
                }
            }
        }

        static void ChangeUserRole()
        {
            Console.Write("Въведете име на потребител: ");
            string username = Console.ReadLine();
            Console.WriteLine("Роли: 0-ANONYMOUS, 1-ADMIN, 2-INSPECTOR, 3-PROFESSOR, 4-STUDENT");
            Console.Write("Въведете новата роля: ");
            int role;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out role) || role < 0 || role > 4)
                {
                    Console.WriteLine("Моля изберете отново!");
                    continue;
                }
                else
                    break;
            }
            UserData.AssignUserRole(username, (UserRoles)role);
        }

        static void ChangeUserActiveTo()
        {
            Console.Write("Въведете име на потребител: ");
            string username = Console.ReadLine();
            Console.Write("Въведете новата дата: ");
            DateTime activeTo;
            while (true)
            {
                if (!DateTime.TryParse(Console.ReadLine(), out activeTo))
                {
                    Console.WriteLine("Моля изберете отново!");
                    continue;
                }
                else
                    break;
            }
            UserData.SetUserActiveTo(username, activeTo);
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Потребителско име: ");
            string username = Console.ReadLine();
            Console.Write("Парола: ");
            string password = Console.ReadLine();
            var validation = new LoginValidation(username, password, DisplayError);
            User user = null;
            if (validation.ValidateUserInput(ref user))
            {
                Console.WriteLine("Потребител:" + user.ToString());
                Console.Write("Роля: ");

                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("Анонимен");
                        break;
                    case UserRoles.ADMIN:
                        Console.WriteLine("Администратор");
                        ShowAdministratorMenu();
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("Инспектор");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("Професор");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("Студент");
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}
