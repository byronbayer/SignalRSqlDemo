using SignalRSqlDemo.Hubs;
using SignalRSqlDemo.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SignalRSqlDemo
{
    public class JobInfoRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["JobConnection"].ConnectionString;

        public IEnumerable<JobInfo> GetData()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"SELECT [JobID],[Name],[Status] FROM [dbo].[JobInfo]", connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;

                    var dependency = new SqlDependency(command);
                    dependency.OnChange += dependency_OnChange;

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var jobInfos = reader.Cast<IDataRecord>()
                            .Select(
                                x =>
                                    new JobInfo
                                    {
                                        JobId = x.GetInt32(0),
                                        Name = x.GetString(1),
                                        Status = x.GetString(2)
                                    })
                            .ToList();
                        return jobInfos;
                    }
                }
            }
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            JobHub.Show();
        }
    }
}