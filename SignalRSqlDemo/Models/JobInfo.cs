using System;

namespace SignalRSqlDemo.Models
{
    public class JobInfo
    {
        public int JobId { get; set; }
        public string Name { get; set; }
        //public DateTime LastExecutionDate { get; set; }
        public string Status { get; set; }
    }
}