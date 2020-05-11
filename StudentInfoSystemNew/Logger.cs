using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StudentInfoSystemNew
{
    public static class Logger
    {
        private static List<string> currentSessionActivities = new List<string>();

        public static void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
                + LoginValidation.currentUserUsername + ";"
                + LoginValidation.currentUserRole + ";"
                + activity;
            currentSessionActivities.Add(activityLine);
            if (!File.Exists("log.txt"))
            {
                File.Create("log.txt");
            }
            if (File.Exists("log.txt"))
                File.AppendAllText("log.txt", activityLine + "\r\n");
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