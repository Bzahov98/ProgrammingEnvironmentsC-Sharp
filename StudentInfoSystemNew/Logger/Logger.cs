using StudentInfoSystemNew.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StudentInfoSystemNew
{
    public static class Logger
    {
        public static String logFileName = "log.txt";
        private static List<string> currentSessionActivities = new List<string>();

        public static void LogActivity(string activity, User user)
        {
            DateTime dateNow = DateTime.Now;
            string activityLine = dateNow + ";"
                + LoginValidation.currentUserUsername + ";"
                + LoginValidation.currentUserRole + ";"
                + "by " + user.Username + ";"
                + activity;
            currentSessionActivities.Add(activityLine);
            logIntoFile(activityLine);
            logIntoDb  (activityLine,user,dateNow);
        }

        public static void logIntoFile(String activityLine) {
            if (!File.Exists(logFileName))
            {
                File.Create(logFileName);
            }
            if (File.Exists(logFileName))
                File.AppendAllText(logFileName, activityLine + "\r\n");
        }
        public static void logIntoDb(String activityLine, User user, DateTime dateNow) {
            StudentInfoContext context = new StudentInfoContext();
            context.Logs.Add(new Log(activityLine,dateNow/*,user*/));
            context.SaveChanges();
        }

        public static DateTime GetLastLogInInfo(string username)
        {
            DateTime resultDateTime = DateTime.Now;
            foreach (var record in ReadFrom("log.txt"))
            {
                if (record.Contains("Login"))
                {
                    if (record.Contains(username))
                    {
                        String[] splitted = record.Split(';');
                        DateTime.TryParse(splitted[0], out resultDateTime);
                    }
                }
            }

            return resultDateTime;
        }

        private static IEnumerable<string> ReadFrom(string filename)
        {
            string line;
            using (var reader = File.OpenText(filename))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        public static string GetCurrentSessionActivities()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var activities in currentSessionActivities)
            {
                sb.Append(activities);
            }
            return sb.ToString();
        }
    }
}