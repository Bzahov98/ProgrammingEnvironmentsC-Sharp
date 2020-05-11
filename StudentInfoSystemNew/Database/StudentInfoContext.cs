using StudentInfoSystemNew.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystemNew
{
    class StudentInfoContext : DbContext
    {
        public StudentInfoContext context;
        public StudentInfoContext() : base(Properties.Settings.Default.DbConnect) {
            context = this;
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }

       
        public int getTotalStudentsCount()
        {
            IEnumerable<Student> queryStudents = context.Students;
            return queryStudents.Count();
        }   

        public int getTotalUsersCount()
        {
            IEnumerable<User> queryUsers = context.Users;
            return queryUsers.Count();
        }

        public int getTotalLogsCount()
        {
            IEnumerable<Log> queryLogs = context.Logs;
            return queryLogs.Count();
        }

        public bool TestLogsIfEmpty()
        {
            return getTotalLogsCount() == 0;
        }
        public bool TestStudentsIfEmpty()
        {
            return getTotalStudentsCount() == 0;
        }

        public bool TestUsersIfEmpty()
        {
            return getTotalUsersCount() == 0;
        }

        public void CopyTestUsers()
        {
            foreach (User u in UserData.TestUsers)
            {
                context.Users.Add(u);
            }
            Logger.LogActivity("Copy Test Users", LoginValidation.currentUser);

            context.SaveChanges();
        }
        public void CopyTestStudents()
        {
            foreach (Student st in StudentData.testStudents)
            {
                context.Students.Add(st);
            }
            Logger.LogActivity("Copy Test students" , LoginValidation.currentUser);

            context.SaveChanges();
        }
        public void CopyCurrentLogs()
        {
            foreach (Log log in Logger.getLogsFromFile())
            {
                context.Logs.Add(log);
            }
           // Logger.LogActivity("Copy Test Logs" , LoginValidation.currentUser);

            context.SaveChanges();
        }

        public void deleteStudent(string facultNumb) {
            Student delObj =
            (from st in context.Students
             where st.faculityNumber == facultNumb
             select st
             ).First();
            Logger.LogActivity("Remove student"+ delObj.firstName + "facNumb" + delObj.faculityNumber, LoginValidation.currentUser);
            context.Students.Remove(delObj);
            context.SaveChanges();
        }
        private static List<User> GetRegions()
        {
            List<User> users = new StudentInfoContext().context.Users.ToList();
            return users;
        }

    }
}
