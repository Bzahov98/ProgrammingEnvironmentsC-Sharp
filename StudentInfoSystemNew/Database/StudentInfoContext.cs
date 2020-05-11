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

        private StudentInfoContext context;
        public StudentInfoContext() : base(Properties.Settings.Default.DbConnect) {
            context = this;
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        public bool TestStudentsIfEmpty()
        {
            IEnumerable<User> queryStudents = context.Users;
            int countStudents = queryStudents.Count();

            return countStudents == 0 ? true : false;
        }
        public int getTotalStudentsCount()
        {
            IEnumerable<User> queryStudents = context.Users;
            return queryStudents.Count();
        }

        public void CopyTestStudent()
        {
            foreach (User st in UserData.TestUsers)
            {
                context.Users.Add(st);
            }

            context.SaveChanges();
        }

        private static List<User> GetRegions()
        {
            StudentInfoContext contextRegions = new StudentInfoContext();
            List<User> users = contextRegions.Users.ToList();
            return users;
        }
    }
}
