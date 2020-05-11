using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystemNew.Model
{
   public class Log
    {
        public Log() { }

        public Log(string activityLine, DateTime logTime)
        {
            this.activityLine = activityLine;
            this.logTime = logTime;
        }

        public Log(string activityLine, DateTime logTime, int? userId) : this(activityLine, logTime)
        {
            //this.userId = userId;
        }

        public string activityLine { get; set; }

        public DateTime logTime { get; set; }

        public int LogId { get; set; }
        //public int? userId { get; set; }


    }
}
